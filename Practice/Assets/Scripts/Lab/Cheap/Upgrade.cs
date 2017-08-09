using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour {

    public  int         slotIndex;
    public  GameObject  upgradeButton;
    public  GameObject  cheap;
    public  Sprite      speed, growth, research;
    private SaveManager sm;

    void Start()
    {
        sm = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }
    public void Speed()
    {
        cheap.GetComponent<Cheap>().slots[slotIndex].GetComponent<Image>().sprite = speed;
        sm.speedUpgrade = 2;
        GameObject.Find("Cheap").GetComponent<Cheap>().slotClicked = false;
        gameObject.SetActive(false);
    }
    public void Growth()
    {
        cheap.GetComponent<Cheap>().slots[slotIndex].GetComponent<Image>().sprite = growth;
        // How fast player will gain mass
        sm.growthSpeed = 2; 
        GameObject.Find("Cheap").GetComponent<Cheap>().slotClicked = false;
        gameObject.SetActive(false);
    }
    public void Research()
    {
        cheap.GetComponent<Cheap>().slots[slotIndex].GetComponent<Image>().sprite = research;
        // How fast player will gain exp
        sm.researchSpeed = 2;
        GameObject.Find("Cheap").GetComponent<Cheap>().slotClicked = false;
        gameObject.SetActive(false);
    }
}
