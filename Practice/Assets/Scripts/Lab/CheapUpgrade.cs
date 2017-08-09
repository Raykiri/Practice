using UnityEngine;
using UnityEngine.UI;

public class CheapUpgrade : MonoBehaviour {


    public GameObject upgradeMenu;
    public GameObject cheap;

    [HideInInspector]
    public int index;
    [HideInInspector]
    public int[] slotsSpritesIndex;

    public  Sprite      emptySlotSprite;
    private bool        isOn;
    private bool[]      slotsAreFull;
    private Sprite      newSprite;
    private SaveManager saveManager;
    public  float       speed;
    public  float       growth;
    public  float       research;
    private float       speedCost;
    private float       growthCost;
    private float       researchCost;

    void Awake ()
    {
        index = 0;
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        Load();
        GetBoolLenghtOfSlots();
        GetSlotsSprites();
        isOn = false;
        if (speed <= 0)        speed        = 1;
        if (speedCost <= 0)    speedCost    = 1;
        if (growth <= 0)       growth       = 1;
        if (growthCost <= 0)   growthCost   = 1;
        if (research <= 0)     research     = 1;
        if (researchCost <= 0) researchCost = 1;
    }
    public void OnSlotClick(int slotIndex)
    {
        index = slotIndex;
        if (isOn)
        {
            switch (slotsSpritesIndex[index])
            {
                case 1:
                    speed /= 1.5f;
                    break;
                case 2:
                    growth /= 1.5f;
                    break;
                case 3:
                    research /= 1.5f;
                    break;
                default:
                    break;
            }
            CleanSlot(index);
            Save();
        }
        else if(!slotsAreFull[index])
        {
            OpenMenu();
        }
    }

    public void Speed()
    {
        if (!slotsAreFull[index] && !isOn)
        {
            newSprite = upgradeMenu.transform.Find("Speed").GetComponent<Image>().sprite;
            speed    *= 1.5f;
            slotsSpritesIndex[index] = 1;
            SetSlotsBoolToTrue(index);
            ApplySprite(newSprite, index);
            Save();
            CloseMenu();
        }
    }

    public void Growth()
    {
        if (!slotsAreFull[index] && !isOn)
        {
            newSprite = upgradeMenu.transform.Find("Growth").GetComponent<Image>().sprite;
            growth *= 1.5f;
            slotsSpritesIndex[index] = 2;
            SetSlotsBoolToTrue(index);
            ApplySprite(newSprite, index);
            Save();
            CloseMenu();
        }
    }

    public void Research()
    {
        if (!slotsAreFull[index] && !isOn)
        {
            newSprite = upgradeMenu.transform.Find("Research").GetComponent<Image>().sprite;
            research *= 1.5f;
            slotsSpritesIndex[index] = 3;
            SetSlotsBoolToTrue(index);
            ApplySprite(newSprite, index);
            Save();
            CloseMenu();
        }
    }

    public void RecycleBin()
    {
        CloseMenu();
        if (isOn)   isOn = false;
        else        isOn = true;
    }

    void CleanSlot(int slotIndex)
    {
        slotsSpritesIndex[index] = 0;
        slotsAreFull[index]      = false;
        //Turn off recyclebin
        isOn = false;
        cheap.transform.GetChild(index).GetComponent<Image>().sprite = emptySlotSprite;
    }

    public void ApplySprite(Sprite sprite, int slotIndex)
    {
        cheap.transform.GetChild(slotIndex).GetComponent<Image>().sprite = sprite;
        SetSlotsBoolToTrue(slotIndex);
    }

    void GetBoolLenghtOfSlots()
    {
        if(slotsAreFull.Length <= 0) slotsAreFull = new bool[cheap.transform.childCount];
    }

    void SetSlotsBoolToTrue(int index)
    {
        slotsAreFull[index] = true;
    }

    void GetSlotsSprites()
    {
        if (slotsSpritesIndex.Length <= 0) slotsSpritesIndex = new int[upgradeMenu.transform.childCount];
    }

    public void Save()
    {
        saveManager.speedUpgrade  = speed;
        saveManager.speedCost     = speedCost;
        saveManager.growthSpeed   = growth;
        saveManager.growthCost    = growthCost;
        saveManager.researchSpeed = research;
        saveManager.researchCost  = researchCost;
        saveManager.slotsAreFull  = slotsAreFull;
        saveManager.slotsSprites  = slotsSpritesIndex;
    }

    public void Load()
    {
        speed             = saveManager.speedUpgrade;
        speedCost         = saveManager.speedCost;
        growth            = saveManager.growthSpeed;
        research          = saveManager.researchSpeed;
        slotsAreFull      = saveManager.slotsAreFull;
        slotsSpritesIndex = saveManager.slotsSprites;
        SpriteLoad();
    }

    void SpriteLoad()
    {
        for (int i = 0; i < slotsSpritesIndex.Length; i++)
        {
            index = i;
            if (slotsSpritesIndex[i] == 1) ApplySprite(upgradeMenu.transform.GetChild(0).GetComponent<Image>().sprite, index);
            if (slotsSpritesIndex[i] == 2) ApplySprite(upgradeMenu.transform.GetChild(1).GetComponent<Image>().sprite, index);
            if (slotsSpritesIndex[i] == 3) ApplySprite(upgradeMenu.transform.GetChild(2).GetComponent<Image>().sprite, index);
        }
    }

    void OpenMenu()
    {
        upgradeMenu.SetActive(true);
    }

    void CloseMenu()
    {
        upgradeMenu.SetActive(false);
    }
}