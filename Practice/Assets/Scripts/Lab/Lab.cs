using UnityEngine;
using UnityEngine.SceneManagement;

public class Lab : MonoBehaviour
{
	void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Lab"))
            {
                BackToMenu();
            }
            else
            {
                OpenLab();
            }
        }
    }

    public void OpenLab()
    {
        SceneManager.LoadScene("Lab");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
