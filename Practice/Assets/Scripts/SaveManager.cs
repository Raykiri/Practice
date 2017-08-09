using UnityEngine;
using System.Collections;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour {

    public static SaveManager manager;
    
    public float  playerMass;
    public float  coins;
    public int    researchPoints;
                  
    public float  speedUpgrade;
    public float  speedCost;
    public int    speedLevel;
                  
    public int    bodyIndex;
    public int    playerLevel;
    public float  playerExperience;
                  
    public float  speedBoostUpgradeValue;
    public int    speedBoostUpgradeCost;
    public int    speedBoostlevel;

    public float  highestMass;
    public float  playerHp;
                 
    public float  growthCost;
    public float  researchCost;

    public int    attackPower;
    public int    attackPowerCost;
    public int    attackPowerLevel;

    public float  growthSpeed;
    public float  researchSpeed;
    public bool[] slotsAreFull;
    public int[]  slotsSprites;

    void Awake ()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        Load();
    }
    void OnDisable()
    {
        Save();
    }

    public void Save()
    {
        BinaryFormatter bf   = new BinaryFormatter();
        FileStream      file = File.Create(Application.persistentDataPath + "/saves.bs");
        gameData        data = new gameData();

        data.speedLevel             = speedLevel;
        data.playerMass             = playerMass;
        data.coins                  = coins;
        data.speedUpgrade           = speedUpgrade;
        data.speedCost              = speedCost;
        data.bodyIndex              = bodyIndex;
        data.playerLevel            = playerLevel;
        data.playerExperience       = playerExperience;
        data.speedBoostUpgradeValue = speedBoostUpgradeValue;
        data.speedBoostUpgradeCost  = speedBoostUpgradeCost;
        data.speedBoostlevel        = speedBoostlevel;
        data.highestMass            = highestMass;
        data.playerHp               = playerHp;
        data.attackPower            = attackPower;
        data.attackPowerCost        = attackPowerCost;
        data.attackPowerLevel       = attackPowerLevel;
        data.growthSpeed            = growthSpeed;
        data.researchSpeed          = researchSpeed;
        data.slotsAreFull           = slotsAreFull;
        data.slotsSprites           = slotsSprites;
        data.growthCost             = growthSpeed;
        data.researchCost           = researchCost;
        data.researchPoints         = researchPoints;


        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (!(File.Exists(Application.persistentDataPath + "/saves.bs")))
            return;

        BinaryFormatter bf   = new BinaryFormatter();
        FileStream      file = File.Open(Application.persistentDataPath + "/saves.bs", FileMode.Open);
        gameData        data = (gameData)bf.Deserialize(file);
        file.Close();
            
        playerMass             = data.playerMass;
        coins                  = data.coins;
        speedUpgrade           = data.speedUpgrade;
        speedCost              = data.speedCost;
        bodyIndex              = data.bodyIndex;
        playerLevel            = data.playerLevel;
        playerExperience       = data.playerExperience;
        speedLevel             = data.speedLevel;
        speedBoostUpgradeValue = data.speedBoostUpgradeValue;
        speedBoostUpgradeCost  = data.speedBoostUpgradeCost;
        speedBoostlevel        = data.speedBoostlevel;
        highestMass            = data.highestMass;
        playerHp               = data.playerHp;
        attackPower            = data.attackPower;
        attackPowerCost        = data.attackPowerCost;
        attackPowerLevel       = data.attackPowerLevel;
        growthSpeed            = data.growthSpeed;
        researchSpeed          = data.researchSpeed;
        slotsAreFull           = data.slotsAreFull;
        slotsSprites           = data.slotsSprites;
        growthCost             = data.growthCost;
        researchCost           = data.researchCost;
        researchPoints         = data.researchPoints;
    }
}

[Serializable]
class gameData
{
    public float  playerMass;
    public float  coins;
    public float  speedUpgrade;
    public float  speedCost;
    public int    bodyIndex;
    public int    playerLevel;
    public float  playerExperience;
    public int    speedLevel;
    public float  speedBoostUpgradeValue;
    public int    speedBoostUpgradeCost;
    public int    speedBoostlevel;
    public float  highestMass;
    public float  playerHp;
    public int    attackPower;
    public int    attackPowerCost;
    public int    attackPowerLevel;
    public float  growthSpeed;
    public float  researchSpeed;
    public bool[] slotsAreFull;
    public int [] slotsSprites;
    public float  growthCost;
    public float  researchCost;
    public int    researchPoints;
}
