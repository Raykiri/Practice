using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class bugFindScript : MonoBehaviour
{
    public  GameObject target;
    public  bool       enemyFound;
    public  bool       targetBigger;
    public  bool       attackEnemy;
    private float      thisBugMass;
    cBugOnCollision    collisionScript;

    void Start()
    {
        thisBugMass     = gameObject.GetComponent<cBugOnCollision>().cBugMass;
        collisionScript = gameObject.GetComponent<cBugOnCollision>();
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (!enemyFound && attackOrNot())
        {
            attackEnemy  = attackOrNot();
            enemyFound   = true;
            target       = obj.gameObject;
            targetBigger = TargetBigger(target);
        }
    }
    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject == target)
        {
            enemyFound = false;
            target     = null;
        }
    }
    bool TargetBigger(GameObject target)
    {
        if (target.CompareTag("Player"))
        {
            var targetMass = target.GetComponent<Player>().Mass;
            if (targetMass >= thisBugMass)
            {
                return true;
            }
            if (targetMass < thisBugMass)
            {
                return false;
            }
            return false;
        }
        if (target.CompareTag("Enemy"))
        {
            var targetMass = target.GetComponent<cBugOnCollision>().cBugMass;
            if (targetMass >= thisBugMass)
            {
                return true;
            }
            if (targetMass < thisBugMass)
            {
                return false;
            }
            return false;
        }
        return false;
    }
    bool attackOrNot()
    {
        if (collisionScript.behavior == 1)
        {
            return true;
        }
        if (collisionScript.behavior == 2)
        {
            var randomChoice = Random.Range(0, 3);
            if (randomChoice == 0)
            {
                return true;
            }
            return false;
        }
        throw  new ArgumentOutOfRangeException("behavior", "Behavior not found");
    }
}
