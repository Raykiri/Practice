using UnityEngine;
using System.Collections;

public class cyborgBugMovement : MonoBehaviour {
    
	public  float         speed;
	public  float         ChooseDirectionTime;
	public  int           randomDirection;
	public  Vector3       target;
	private float         TimerDown;
    private bugFindScript bugFind;

	void Start () 
	{
        bugFind = gameObject.GetComponent<bugFindScript>();
    }
	void Update () 
	{
		speed = GameObject.Find ("Player").GetComponent<Player>().Mass / 7.5f;
		if(!bugFind.enemyFound)
		{
			if(TimerDown > 0)
			{
				TimerDown -= Time.deltaTime;
			}
			if(TimerDown < 1)
			{
				ChooseDirection ();
				TimerDown = ChooseDirectionTime;
			}
			move ();
		}
        else if (bugFind.enemyFound)
        {
            FollowTarget(gameObject.GetComponent<bugFindScript>().target);
        }		
	}
	void ChooseDirection()
	{
		randomDirection = Random.Range (1, 5);
	}
	public void moveUp()
	{
		transform.Translate (0, Time.deltaTime * speed, 0);
	}
	public void moveDown()
	{
		transform.Translate (0, -Time.deltaTime * speed, 0);
	}
	public void moveLeft()
	{
		transform.Translate (-Time.deltaTime * speed, 0, 0);		
	}
	public void moveRight()
	{
		transform.Translate (Time.deltaTime * speed, 0, 0);
	}
	void move()
	{
		if (randomDirection == 1) 
		{
			moveUp ();
		} 
		else if (randomDirection == 2) 
		{
			moveDown ();
		} 
		else if (randomDirection == 3) 
		{
			moveLeft ();
		} 
		else if (randomDirection == 4) 
		{
			moveRight ();
		}
	}
    void FollowTarget(GameObject target)
    {
        if (target != null)
        {
            Vector3 heading   = target.transform.position - gameObject.transform.position;
            float   distance  = heading.magnitude;
            Vector3 direction = heading / distance;
            gameObject.transform.Translate
            (
                new Vector3(
                    direction.x * speed * Time.deltaTime * (gameObject.GetComponent<bugFindScript>().targetBigger ? -1 : 1),
                    direction.y * speed * Time.deltaTime * (gameObject.GetComponent<bugFindScript>().targetBigger ? -1 : 1),
                    direction.z * speed * Time.deltaTime * (gameObject.GetComponent<bugFindScript>().targetBigger ? -1 : 1))
            );
        }
        else
        {
            bugFind.enemyFound = false;
        }
    }
}
