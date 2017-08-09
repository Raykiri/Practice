using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class experienceDisplay : MonoBehaviour
{
    float expPercentage;
    float experience;
    float maxExperience;
    float scalerXScale;
    const float maxScale = 1.4f;
    const float startXPosition = 25;
    const float xOffsetToRight = 5;
    const float xStartPoint = 57;
    
    levelSystem levelSystem;
    Text        experienceText;
    Transform   scaler;

	private void Start ()
    {
        levelSystem    = GameObject.Find("Player").GetComponent<levelSystem>();
        experienceText = GameObject.Find("Percentage").GetComponent<Text>();
        scaler         = GameObject.Find("Scaler").GetComponent<Transform>();
        CountPercentage();
        scalerXScale   = scaler.transform.localScale.x;        
	}
	
	private void Update ()
    {
        CountPercentage();
        ScaleDisplay();
        ScalerPosition();
    }

    private void CountPercentage()
    {
        levelSystem   = GameObject.Find("Player").GetComponent<levelSystem>();
        experience    = levelSystem.playerExperience;
        maxExperience = levelSystem.experienceForLevelUp;

        if (experience == 0) experience = 0.0000000001f;
        expPercentage       = experience * 100 / maxExperience;
        experienceText.text = (Mathf.RoundToInt(expPercentage) + "%");
    }

    private void ScaleDisplay()
    {        
        scalerXScale = maxScale * expPercentage / 100;
        if(maxScale == 0 || expPercentage == 0)
        {
            Debug.LogError("MaxScale " + maxScale + " expPercentage " + expPercentage);
        }
        scaler.transform.localScale = new Vector3(scalerXScale, scaler.transform.localScale.y, scaler.transform.localScale.z);
    }

    private void ScalerPosition()
    {
        scaler.transform.position = new Vector3(xStartPoint * expPercentage / 100 + xOffsetToRight, scaler.transform.position.y, scaler.transform.position.z);        
    }
}
