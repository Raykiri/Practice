using UnityEngine;
using UnityEngine.UI;

public class fpsCounter : MonoBehaviour 
{
	private float fps;
	private Text  text;

	void Start () 
	{
		text = GetComponent<Text> ();
	}

	void Update () 
	{
		fps       = 1 / Time.deltaTime;
		text.text = ("Fps: " + Mathf.RoundToInt(fps));
    }
}
