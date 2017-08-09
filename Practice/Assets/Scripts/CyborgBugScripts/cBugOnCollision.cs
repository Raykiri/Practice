using UnityEngine;

public class cBugOnCollision : MonoBehaviour 
{
	public  int            behavior;
    public  Sprite         red, green;
	public  float          cBugMass;
    private float          scaleX, scaleY;
    private float          playerMass;
    private float          growthSpeed;
    private float          researchSpeed;
    private GameObject     player;
	private pauseScript    pauseScript;
    private enemySpawner   spawnerScript;
    private levelSystem    levelSystem;
    private GameObject     pause;
    private SpriteRenderer thisGameObjectSprite;
    private SaveManager    sm;

    void Start () 
	{
        player               = GameObject.Find("Player");
        levelSystem          = player.GetComponent<levelSystem>();
        spawnerScript        = GameObject.Find("enemySpawner").GetComponent<enemySpawner>();
        playerMass           = player.GetComponent<Player>().Mass;
		pause                = GameObject.Find ("pauseController");
		pauseScript          = pause.GetComponent<pauseScript> ();
        thisGameObjectSprite = gameObject.transform.Find("onMap").GetComponent<SpriteRenderer>();
        sm                   = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        growthSpeed          = sm.growthSpeed;
		behavior             = Random.Range (1, 3);
        cBugMass             = Random.Range(10 * playerMass / 50, 100 * playerMass / 50);
        if (growthSpeed <= 0)   growthSpeed = 1;
        if (researchSpeed <= 0) researchSpeed = 1;
        spawnerScript.enemyCount++;
    }
	void Update () 
	{
        CheckForMass();
		scaleX = cBugMass / 17.7f;
		scaleY = scaleX;
		gameObject.transform.localScale = new Vector3 (scaleX, scaleY, 0);
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Enemy")
		{
		    var otherCBugMass  = other.gameObject.GetComponent<cBugOnCollision>().cBugMass;
		    var otherBugScript = other.gameObject.GetComponent<bugFindScript>();
            
			if(otherCBugMass > cBugMass)
			{
                otherCBugMass            += cBugMass * 0.1f;
                otherBugScript.enemyFound = false;
                spawnerScript.enemyCount--;
                Destroy(gameObject);
			}
		}
		else if(other.gameObject.tag == "Player")
		{
		    var playerMass = other.gameObject.GetComponent<Player>().Mass;
		    if(playerMass >= cBugMass)
            {
                levelSystem.playerExperience += cBugMass * 0.01f * researchSpeed;
                playerMass                   += cBugMass * 0.05f * growthSpeed;
                other.gameObject.GetComponent<Player>().Mass = playerMass;
                spawnerScript.enemyCount--;
                Destroy(gameObject);
			}			
			else if(playerMass < cBugMass)
			{
                Player playerScript  = player.GetComponent<Player>();
                playerScript.Mass    = 50;
                pauseScript.gameOver = true;
                other.gameObject.SetActive (false);
			}
		}
	}
    void CheckForMass()
    {
        playerMass = player.GetComponent<Player>().Mass;
        if (cBugMass <= playerMass)
        {
            thisGameObjectSprite.sprite = green;
        }
        else if(cBugMass > playerMass)
        {
            thisGameObjectSprite.sprite = red;
        }
    }
}
