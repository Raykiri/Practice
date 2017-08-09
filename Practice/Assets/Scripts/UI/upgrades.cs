using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class upgrades : MonoBehaviour 
{
    private SaveManager sm;

    public GameObject   upgradeButton;
    public GameObject   coinsObject;
    public GameObject[] toDisable;
	public GameObject[] toEnable;
    public GameObject   speedDisplayText;
    public GameObject   speedBoostDisplayText;
    public GameObject   attackPowerobject;
    public float        coins;

    public float speedBoostUpgradeValue = 1;
    public int   speedBoostUpgradeCost = 1;
    public int   speedBoostlevel;

    public float speedUpgrade;
    public int   speedLevel;
    public float speedCost;

    public int attackPowerLevel;
    public int attackPower;
    public int attackPowerCost;

    private bool upgradeMenuIsOpen;
    
	Text speedUpgText;
    Text speedBoostUpgradeText;
    Text coinsDisplay;
    Text attackPowerDisplay;

	void Start()
    {
        sm = GameObject.Find("SaveManager").GetComponent<SaveManager>();

        speedBoostUpgradeText  = speedBoostDisplayText.GetComponent<Text>();
        speedUpgText           = speedDisplayText.GetComponent<Text> ();
        attackPowerDisplay     = attackPowerobject.GetComponent<Text>();
        speedCost              = sm.speedCost;
        speedLevel             = sm.speedLevel;
        speedBoostUpgradeValue = sm.speedBoostUpgradeValue;
        speedBoostUpgradeCost  = sm.speedBoostUpgradeCost;
        speedBoostlevel        = sm.speedBoostlevel;
        attackPower            = sm.attackPower;
        attackPowerCost        = sm.attackPowerCost;
        attackPowerLevel       = sm.attackPowerLevel;

        if (attackPower <= 0) attackPower = 1;
        if (attackPowerCost <= 0) attackPowerCost = 1;

        speedUpgText.text          = ("Level  " + speedLevel       + "\nCost: " + speedCost);
        speedBoostUpgradeText.text = ("Level  " + speedBoostlevel  + "\nCost: " + speedBoostUpgradeCost);
        attackPowerDisplay.text    = ("Level "  + attackPowerLevel + "\nCost "  + attackPowerCost);

    }

    void Update()
	{
        if (upgradeMenuIsOpen == true)
        {
            coins                      = sm.coins;
            coinsDisplay.text          = ("Coins: " + coins);
            speedUpgText.text          = ("Level  " + speedLevel + "\nCost: " + speedCost);
            speedBoostUpgradeText.text = ("Level  " + speedBoostlevel + "\nCost: " + speedBoostUpgradeCost);
        }
    }

	public void Upgrades()
    {
        upgradeMenuIsOpen = true;
        upgradeButton.GetComponent<Image>().enabled = false;
        upgradeButton.transform.Find("Text").gameObject.SetActive(false);
		foreach(GameObject obj in toDisable)
		{
			obj.SetActive (false);
		}
		foreach(GameObject obj in toEnable)
		{
			obj.SetActive (true);
        }
        coinsDisplay = coinsObject.GetComponent<Text>();

    }

	public void Back()
    {
        upgradeButton.GetComponent<Image>().enabled = true;
        upgradeButton.transform.Find("Text").gameObject.SetActive(true);
        foreach (GameObject obj in toDisable)
		{
			obj.SetActive (true);
		}
		foreach(GameObject obj in toEnable)
		{
			obj.SetActive (false);
		}
        upgradeMenuIsOpen = false;
        sm.coins          = coins;
	}

	public void upgradeSpeed()
	{
	/*	if (coins >= speedCost) 
		{
            speedLevel++;
            sm.speedLevel = speedLevel;
			coins -= speedCost;
			speedCost++;
            sm.coins = coins;
            sm.speedUpgrade = speedUpgrade;
            sm.speedCost = speedCost;
            speedLevel = sm.speedLevel;
            speedUpgText.text = ("Level  " + speedLevel + "\nCost: " + speedCost);

            sm.Save();
		}*/
	}

    public void UpgradeSpeedBoost()
    {
        if(speedBoostUpgradeCost < 1)
        {
            speedBoostUpgradeCost = 1;
        }
        if(coins >= speedBoostUpgradeCost)
        {
            speedBoostlevel++;
            sm.speedBoostlevel = speedBoostlevel;
            coins -= speedBoostUpgradeCost;
            speedBoostUpgradeCost++;
            sm.coins = coins;
            sm.speedBoostUpgradeCost = speedBoostUpgradeCost;
            speedBoostUpgradeValue += 0.15f;
            sm.speedBoostUpgradeValue = speedBoostUpgradeValue;
            speedBoostUpgradeText.text = ("Level  " + speedBoostlevel + "\nCost: " + speedBoostUpgradeCost);
            sm.Save();
        }
    }

    public void UpgradeAttackPower()
    {
        if (coins >= attackPowerCost)
        {
            attackPowerLevel++;
            sm.attackPowerLevel = attackPowerLevel;
            coins -= attackPowerCost;
            attackPowerCost++;
            sm.coins = coins;
            sm.attackPowerCost = attackPowerCost;
            attackPower++;
            sm.attackPower = attackPower;
            attackPowerDisplay.text = ("Level " + attackPowerLevel + "\nCost " + attackPowerCost);
            sm.Save();
        }
    }
}
