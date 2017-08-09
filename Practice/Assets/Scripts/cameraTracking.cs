using UnityEngine;

public class cameraTracking : MonoBehaviour
{
    private const float cameraZConst  = -7.1f;
    public const float  wallSizeConst = 0.014f;
    public const float  MiniMapSize   = 7;
    public const float  backGroundSizeConst = 200;

    public GameObject player;
	public GameObject Background;
    public GameObject ESpawner;

	private float   bg_X, bg_Y;
	private Vector3 playerPos;
	private Vector3 newCameraPos;
    private GameObject walls;

    readonly Vector3 defaultWallsSize = new Vector3(0.7f, 0.7f, 1);

	Player p;
	Camera cameraComponent;
    Camera mapCamera;


	void Start () 
	{
        mapCamera = GameObject.Find("MiniMap").GetComponent<Camera>();
		cameraComponent = GetComponent<Camera> ();
		p = player.gameObject.GetComponent<Player>();

		cameraComponent.orthographicSize = 25;
		Background.transform.localScale = new Vector3 (155, 155, 3);

        newCameraPos = new Vector3 (transform.position.x, player.transform.position.y, cameraZConst);
		playerPos = new Vector3 (player.transform.position.x, player.transform.position.y, cameraZConst);

		newCameraPos = playerPos;
		transform.position = newCameraPos;

        walls = GameObject.Find("Walls");
        walls.transform.localScale = defaultWallsSize;
}


	void Update () 
	{
        backGroundSize();
        trackPlayer();
        wallsSize();
        enemySpawn();
        miniMapSize();
	}

    void trackPlayer()
    {
        cameraComponent.orthographicSize = p.Mass / 2;
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, cameraZConst);
        newCameraPos = playerPos;
        transform.position = newCameraPos;
    }

    void backGroundSize()
    {
        bg_X = backGroundSizeConst * p.Mass / 50;
        bg_Y = backGroundSizeConst * p.Mass / 50;
        Background.transform.localScale = new Vector3(bg_X, bg_Y, 7);

    }

    void miniMapSize()
    {
        mapCamera.orthographicSize = p.Mass * MiniMapSize;
    }

    void wallsSize()
    {
        var wallsSize = p.Mass * wallSizeConst;
        walls.transform.localScale = new Vector3(wallsSize, wallsSize, 1);
    }

    void enemySpawn()
    {
        if (PlayerPrefs.GetInt("ESpawn") == 0)
            ESpawner.SetActive(false);
        else if (PlayerPrefs.GetInt("ESpawn") == 1)
            ESpawner.SetActive(true);
    }
}
