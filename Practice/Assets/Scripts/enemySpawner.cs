using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class enemySpawner : MonoBehaviour 
{
    public List<GameObject> safeZone = new List<GameObject>();
    public GameObject enemy;
	public GameObject pos1, pos2;
	public int maxEnemy, enemyCount;
	public Vector3 pos;
	public GameObject player;
    public const float spawnerScaleConst = 25;

	private float minSpawnDistanceX, maxSpawnDistanceX;
	private float minSpawnDistanceY, maxSpawnDistanceY;
	private int   spawnDirection;
    private float playerMass;

	Transform spawner;
	Transform tr_pos1, tr_pos2;
	Vector3 spawnPosition;

	void Start () 
	{
		tr_pos1 = pos1.GetComponent<Transform> ();
		tr_pos2 = pos2.GetComponent<Transform> ();
		spawner = gameObject.GetComponent<Transform> ();
		enemyCount = 0;
    }

	void Update ()
    {
        playerMass = GameObject.Find("Player").GetComponent<Player>().Mass;
        spawner.transform.localScale = new Vector3(spawnerScaleConst * playerMass / 50, spawnerScaleConst * playerMass / 50, 0); //24 25
        
		if (enemyCount <= maxEnemy - 1)
		{
			StartCoroutine (spawnEnemy(2*Time.deltaTime));
		}
	}

	IEnumerator spawnEnemy(float waitTime)
	{
        ChooseSpawnPosition();
	    var spawnRotation = Quaternion.identity;
		Instantiate (enemy, spawnPosition, spawnRotation);
        enemyCount++;
		yield return new WaitForSeconds (waitTime);
	}

	void ChooseSpawnPosition()
	{

        spawnPosition = new Vector3(Random.Range(tr_pos1.transform.position.x, tr_pos2.transform.position.x),
                                    Random.Range(tr_pos2.transform.position.y, tr_pos1.transform.position.y),
                                    0);
        SafeZone();
    }

    void SafeZone()
    {
        foreach (GameObject obj in safeZone)
        {
            var pos1 = obj.transform.Find("Pos1").gameObject;
            var pos2 = obj.transform.Find("Pos2").gameObject;
            if (pos1 != null && pos2 != null)
            {
                if(pos1.transform.position.x < spawnPosition.x && spawnPosition.x < pos2.transform.position.x)
                {
                    ChooseSpawnPosition();
                }
                else if (pos1.transform.position.y < spawnPosition.y && spawnPosition.y < pos2.transform.position.y)
                {
                    ChooseSpawnPosition();
                }
            }
        }
    }
}