using UnityEngine;
using System.Collections;
using System;

public class EnemyControler : MonoBehaviour {

    public  Sprite[]   displayOnMap;
    public  Enemy      enemy;
    public  GameObject target;
    public  bool       targetFound;
    private Player     player;
    private float      timerDown;
    private int        direction;
    private const int  sizeConst = 50;

    void Start ()
    {
        enemy       = new Enemy();
        player      = GameObject.Find("Player").GetComponent<Player>();
        enemy.Mass  = UnityEngine.Random.Range(player.Mass * 0.75f, player.Mass * 1.5f);
        targetFound = false;
        player      = GameObject.Find("Player").GetComponent<Player>();
    }
	
	void Update ()
    {
        SetStats();
        Movement();
        SetDisplayOnMap();
    }

    void SetStats()
    {
        enemy.Speed = player.Mass / 7.5f;
        float size  = enemy.Mass / sizeConst;
        gameObject.transform.localScale = new Vector3(size, size, size);
    }

    void Movement()
    {
        if (!targetFound && target == null)
        {
            if (timerDown > 0)
            {
                timerDown -= Time.deltaTime;
            }
            if (timerDown <= 0)
            {
                direction = ChooseDirection();
                timerDown = 5;
            }
            move();
        }
        else
        {
            Follow(target);
        }
    }

    int ChooseDirection()
    {
        return UnityEngine.Random.Range(0, 4);
    }
    void moveUp()
    {
        transform.Translate(0, Time.deltaTime * enemy.Speed, 0);
    }
    void moveDown()
    {
        transform.Translate(0, -Time.deltaTime * enemy.Speed, 0);
    }
    void moveLeft()
    {
        transform.Translate(-Time.deltaTime * enemy.Speed, 0, 0);
    }
    void moveRight()
    {
        transform.Translate(Time.deltaTime * enemy.Speed, 0, 0);
    }
    void move()
    {
        switch (direction)
        {
            case 0:
                moveUp();
                break;
            case 1:
                moveDown();
                break;
            case 2:
                moveLeft();
                break;
            case 3:
                moveRight();
                break;
            default:
                Debug.LogError("Direction not found " + direction);
                break;
        }
    }
    
    void OnCollisionEnter2D (Collision2D obj)
    {
        string tag = obj.gameObject.tag;
        if (tag == "Player")
        {
            if(obj.gameObject.GetComponent<Player>().Mass > enemy.Mass)
            {                
                player.Mass       += enemy.Mass * 0.02f * GameObject.Find("SaveManager").GetComponent<SaveManager>().growthSpeed;
                player.Experience += enemy.Mass * 0.02f * GameObject.Find("SaveManager").GetComponent<SaveManager>().researchSpeed;
                Destroy(gameObject);
            }
            else
            {
                player.Mass = 50;
                GameObject.Find("pauseController").GetComponent<pauseScript>().gameOver        = true;
                gameObject.transform.Find("SightRange").GetComponent<SightScript>().enemyFound = false;
            }
        }
        else if (tag == "Enemy")
        {
            Enemy otherEnemy = obj.gameObject.GetComponent<EnemyControler>().enemy;
            if(obj.gameObject.GetComponent<EnemyControler>().enemy.Mass < enemy.Mass)
            {
                enemy.Mass += otherEnemy.Mass * 0.1f;
                targetFound = false;
                target = null;
                gameObject.transform.Find("SightRange").GetComponent<SightScript>().enemyFound = false;
                Destroy(obj.gameObject);
            }
        }
        else Debug.LogError("Tag not found: " + tag);
    }

    void Follow(GameObject target)
    {
        if (target != null)
        {
            int negativeDirection;
            if (target.transform.tag == "Enemy")
            {
                negativeDirection = enemy.Mass > target.GetComponent<EnemyControler>().enemy.Mass ? 1 : -1;
            }
            else if (target.transform.tag == "Player")
            {
                negativeDirection = enemy.Mass > target.GetComponent<Player>().Mass ? 1 : -1;
            }
            else negativeDirection = 1;

            Vector3 heading   = target.transform.position - gameObject.transform.position;
            float   distance  = heading.magnitude;
            Vector3 direction = heading / distance;
            gameObject.transform.Translate(new Vector3(direction.x * enemy.Speed * Time.deltaTime * negativeDirection, 
                                                       direction.y * enemy.Speed * Time.deltaTime * negativeDirection, 0));
        }
        else
        {
            transform.Find("SightRange").GetComponent<SightScript>().enemyFound = false;
            targetFound = false;
        }
    }
    void SetDisplayOnMap()
    {
        if (player.Mass <= enemy.Mass)
        {
            gameObject.transform.Find("onMap").GetComponent<SpriteRenderer>().sprite = displayOnMap[0];
        }
        else
        {
            gameObject.transform.Find("onMap").GetComponent<SpriteRenderer>().sprite = displayOnMap[1];
        }
    }
    void OnDestroy()
    {
        try
        {
            GameObject.Find("enemySpawner").GetComponent<enemySpawner>().enemyCount--;
        }
        catch(NullReferenceException e)
        {
            Debug.LogWarning("\"enemySpawner\" not found" + e.StackTrace);
        }
    }
}
