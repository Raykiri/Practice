using UnityEngine;

public class Slot : MonoBehaviour
{
    public  int  slotIndex;
    private bool isEmpty = true;
    GameObject   upgradeButtons;

    public void SlotClick()
    {
        if (isEmpty)
        {
            GameObject.Find("UpgradeControler").GetComponent<CheapUpgrade>().index = slotIndex;
      /*  
            Upgrade upgradeScript;
            GameObject.Find("Cheap").GetComponent<Cheap>().slotClicked = true;
            upgradeButtons = GameObject.Find("Upgrade Sprites");
            upgradeScript = upgradeButtons.GetComponent<Upgrade>();
            upgradeScript.slotIndex = slotIndex;
            isEmpty = false;
      */
        }
    }    
}
