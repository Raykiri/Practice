using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class pauseScript : MonoBehaviour {
    
	public bool         gameOver;
	public GameObject   PauseBg;
	public GameObject   gameOverText;
	public GameObject   BoostIndicator;
	public GameObject   MobileJoystick;
	public GameObject   pauseButton;
    public GameObject[] toDisableOnGameOver;

	public Toggle paused;
	public bool   isOnn;
	public bool   pauseGame;
    
	void Start () 
	{	
		paused = pauseButton.gameObject.GetComponent<Toggle> ();
		isOnn  = pauseButton.gameObject.GetComponent<Toggle> ().isOn;
		pauseButton.gameObject.GetComponent<Toggle> ().isOn = false;
		isOnn    = false;
		gameOver = false;
		PauseBg.SetActive (false);
		gameOverText.SetActive (false);
        if (BoostIndicator != null) BoostIndicator.SetActive (true);
		MobileJoystick.SetActive (true);
    }

	void Update ()
	{
		isOnn = pauseButton.gameObject.GetComponent<Toggle> ().isOn;
		if (!gameOver) 
		{
			if (isOnn) 
			{
				Time.timeScale = 0;
				pauseButton.SetActive (true);
                if (BoostIndicator != null) BoostIndicator.SetActive (false);
				MobileJoystick.SetActive (false);
                Time.timeScale = 0;
				if (pauseGame) 
				{
					pauseButton.SetActive (false);					
				}

			} 
			else if (!isOnn) 
			{
				if (pauseGame) 
				{
					pauseButton.SetActive (false);
                    if (BoostIndicator != null) BoostIndicator.SetActive (false);
					MobileJoystick.SetActive (false);
                    Time.timeScale = 0;	
				} 
				else if(!pauseGame)
				{
					Time.timeScale = 1;

					PauseBg.SetActive (false);
                    if (BoostIndicator != null) BoostIndicator.SetActive (true);
                    MobileJoystick.SetActive (true);
                }
			}
		} 
		else if (gameOver)
        {
            PauseBg.SetActive (true);
			gameOverText.SetActive (true);
            foreach(GameObject obj in toDisableOnGameOver)
            {
                if(obj != null)
                    obj.SetActive(false);
            }
            Time.timeScale = 0;
		}
	}
}
