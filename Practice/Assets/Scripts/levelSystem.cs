using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelSystem : MonoBehaviour {

    // TODO:
    // Enable levelIndicator
    private const int   expForFirstLevel       = 10;
    private const float expForLevelUpGrowSpeed = 1.5f;
    private const int   expMultiplier          = 20;

    public float playerExperience;
    public float experienceForLevelUp;
    Player player;
    SaveManager saveManager;
    // Text levelindicator;

    void Start()
    {
     //  levelindicator = GameObject.Find("Level").GetComponent<Text>();
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    void Update()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerExperience = player.Experience;
        experienceForLevelUp = playerExperience * expMultiplier;
        experienceForLevelUp = expForFirstLevel * Mathf.Pow(expForLevelUpGrowSpeed, player.Level - 1);
        if (player.Level == 0) player.Level = 1;
        if (player.Mass < 50) player.Mass = 50;
        if (player.Experience >= experienceForLevelUp)
        {
            player.Experience = player.Experience - experienceForLevelUp;
            player.Level += 1;
            saveManager.researchPoints++;
        }
       // levelindicator.text = ("RP " + saveManager.researchPoints);
        saveManager.playerLevel = (int)player.Level;
        saveManager.playerExperience = playerExperience;
    }

    void OnDisable()
    {
        saveManager.playerLevel = (int)player.Level;
        saveManager.playerExperience = playerExperience;
    }
}
