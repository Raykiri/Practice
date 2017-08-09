using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class devConsole : MonoBehaviour 
{
    public bool       devConsoleToggle;
    public GameObject console;

	void Start ()
    {
        devConsoleToggle = GameObject.Find("devConsoleEnable").GetComponent<Toggle>().isOn;
        GameObject.Find("devConsoleEnable").GetComponent<Toggle>().isOn = false;
        console.SetActive(false);
    }
	
	void Update ()
    {
        devConsoleToggle = GameObject.Find("devConsoleEnable").GetComponent<Toggle>().isOn;
        if (devConsoleToggle)
            console.SetActive(true);
        else 
            console.SetActive(false);
	}
}
