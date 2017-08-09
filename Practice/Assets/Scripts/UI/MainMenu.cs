using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{
    SaveManager saveManager;

	public static MainMenu Menu;
	public GameObject mainMenuObject;
	public GameObject exchanger;

    public GameObject[] settingsObjects;
    public GameObject   ShopMenu;
    public GameObject   PlayerDemo;

	int   firstLoad; // 1 = false, 0 = true;
	float defaultPlayerMass;



	void Start () 
	{
        saveManager       = GameObject.Find("SaveManager").GetComponent<SaveManager>();
		Menu              = GetComponent<MainMenu> ();
		firstLoad         = PlayerPrefs.GetInt ("FirstLoad");
		defaultPlayerMass = 50;
        PlayerPrefs.SetInt("ESpawn", 1);

        DisplayBestScore();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void NewGame()
    {
        saveManager.speedCost              = 1f;
        saveManager.speedUpgrade           = 1f;
        saveManager.playerMass             = defaultPlayerMass;
        saveManager.coins                  = 0;
        saveManager.playerExperience       = 0;
        saveManager.playerLevel            = 1;
        saveManager.speedLevel             = 0;
        saveManager.speedBoostlevel        = 0;
        saveManager.speedBoostUpgradeCost  = 1;
        saveManager.speedBoostUpgradeValue = 0;
        BackToMenu();
    }
	public void Continue()
	{
		if (firstLoad == 1) 
			SceneManager.LoadScene ("Lab");
		else if(firstLoad == 0)
		{
			firstLoad = 1;
			PlayerPrefs.SetInt ("FirstLoad", firstLoad);
			NewGame ();
		}
	}

	public void Settings()
	{
        foreach (GameObject obj in settingsObjects) 
        {
            obj.SetActive(true);
        }
        mainMenuObject.SetActive(false);
        exchanger.SetActive(false);
    }

	public void Quit()
	{
		Application.Quit ();
	}

	public void Exchanger()
	{
		mainMenuObject.SetActive (false);
		exchanger.SetActive (true);
	}

	public void BackToMenu()
	{
        exchanger.SetActive (false);
		mainMenuObject.SetActive (true);

        foreach (GameObject obj in settingsObjects)
        {
            obj.SetActive(false);
        }
        ShopMenu.SetActive(false);
        PlayerDemo.SetActive(false);
    }

    public void Shop()
    {
        mainMenuObject.SetActive(false);
        ShopMenu.SetActive(true);
        PlayerDemo.SetActive(true);

    }

    void DisplayBestScore()
    {
        Text bestScore = GameObject.Find("Best Score").GetComponent<Text>();
        bestScore.text = ("Best Score " + Mathf.RoundToInt(saveManager.highestMass));
    }
}
