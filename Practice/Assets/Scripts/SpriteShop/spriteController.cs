using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class spriteController : MonoBehaviour
{
    public Sprite[]     bodySprite;
    public GameObject   body;
    public GameObject[] toggleBodies;
    public Sprite       Test;
    public bool[]       choosenBody;
    SpriteRenderer      bodyRenderer;
    SaveManager         sm;
    
    void Start()
    {
        bodyRenderer = body.GetComponent<SpriteRenderer>();
        sm           = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        checkToggle();
    }

    void Update()
    {
        checkToggle();
        ChangeSprites();
    }

    void checkToggle()
    {
        for (int i = 0; i < toggleBodies.Length; i++)
        {
            choosenBody[i] = toggleBodies[i].GetComponent<Toggle>().isOn;
        }
    }

    public void ChangeSprites()
    {
        checkToggle();
        if (choosenBody[0])
        {
            // Green
            bodyRenderer.sprite = bodySprite[0];
            sm.bodyIndex        = 0;
        }
        else if (choosenBody[1])
        {
            // Blue
            bodyRenderer.sprite = bodySprite[1];
            sm.bodyIndex        = 1;
        }
    }
    
}
