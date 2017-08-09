using UnityEngine;
using System.Collections;

public class Enemy
{
    private  float  mass;
    private  float  speed;
    readonly string type;

    #region Constructors
    public Enemy()
    {
        mass  = 50;
        speed = 10;
        type  = "Default";
    }
    public Enemy(float mass) : this()
    {
        this.mass = mass;
    }
    public Enemy(float mass, float speed) : this(mass)
    {
        this.speed = speed;
    }
    public Enemy(float mass, float speed, string type) : this(mass, speed)
    {
        this.type = type;
    }
    #endregion
    #region Properties
    public float Mass
    {
        get
        {
            return mass;
        }
        set
        {
            mass = value;
        }
    }
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    public string Type
    {
        get
        {
            return type;
        }
    }
    #endregion
}
