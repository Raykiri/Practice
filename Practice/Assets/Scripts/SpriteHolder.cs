using UnityEngine;

public class SpriteHolderScript : MonoBehaviour
{
    public   Sprite[] sprites;
    public   GameObject body;
    private  int bodyIndex;
    SpriteRenderer bodyRenderer;

    void Start()
    {
        bodyRenderer = body.GetComponent<SpriteRenderer>();
        bodyIndex    = GameObject.Find("SaveManager").GetComponent<SaveManager>().bodyIndex;
        bodyIndex    = GameObject.Find("SaveManager").GetComponent<SaveManager>().bodyIndex;
        bodyRenderer.sprite = sprites[bodyIndex];
    }
}
