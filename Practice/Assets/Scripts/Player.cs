using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // TODO: Implement all previous features from PlayerController.cs (Refactoring)
    // Indicators
    //------------------------------
    public GameObject massIndicator;
    //------------------------------
    private const float speed     = 35f;
    private const int   sizeConst = 83;

    public  GameObject  joystick;
    private SaveManager saveManager;
    private float mass;
    private float exp;
    private float speedUpgrade;
    private float boostUpgrade;
    private int   level;

    #region Methods
    private void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        Load();
    }
    private void Update()
    {
        Move();
        SetSize();
        SetHighestMass();
        Indicators();
    }
    private void SetSize()
    {
        float size = Mass / sizeConst;
        transform.localScale = new Vector3(size, size, 0);
    }
    private void Move()
    {
        Vector3 movementDirection = joystick.GetComponent<JoystickController>().Direction;
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }
    private void Indicators()
    {
       massIndicator.GetComponent<Text>().text = ("Mass: " + Mathf.RoundToInt(Mass));
    }
    private void SetHighestMass()
    {
        if (saveManager.highestMass < Mass)
            saveManager.highestMass = mass;
    }
    private void Save()
    {
        saveManager.playerMass = Mass;
        saveManager.playerExperience = Experience;
        saveManager.playerLevel = (int)Level;
    }
    private void Load()
    {
        Mass = saveManager.playerMass;
        Experience = saveManager.playerExperience;
        SpeedUpgrade = saveManager.speedUpgrade;
        Level = saveManager.playerLevel;
    }
    private void OnDestroy()
    {
        Save();
        saveManager.Save();
    }
    #endregion
    #region Properties
    public float Mass
    {
        get { return mass; }
        set
        {
            if (value != mass && value > 0)
                mass = value;
        }
    }
    public float Experience
    {
        get { return exp; }
        set
        {
            if (value != exp && value > 0)
                exp = value;
        }
    }
    public float SpeedUpgrade
    {
        get { return speedUpgrade; }
        set
        {
            if (value != speedUpgrade && value > 0)
                speedUpgrade = value;
        }
    }
    public float BoostUpgrade
    {
        get { return boostUpgrade; }
        set
        {
            if (value != boostUpgrade && value > 0)
                boostUpgrade = value;
        }
    }
    public float Level
    {
        get { return level; }
        set
        {
            if (value != level)
                level = (int)value;
        }
    }
#endregion
}
