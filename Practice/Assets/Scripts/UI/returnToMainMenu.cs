using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class returnToMainMenu : MonoBehaviour 
{

    Player      player;
    SaveManager saveManager;

    void Start()
    {
        player      = GameObject.Find("Player").GetComponent<Player>();
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();        
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            returnToMainmenu();
        }
    }

	public void returnToMainmenu()
	{
        saveManager.playerMass = player.Mass;
        SceneManager.LoadScene ("MainMenu");
	}
}
