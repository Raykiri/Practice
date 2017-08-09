using UnityEngine;
using System.Collections;

public class gameBordersScript : MonoBehaviour {
    
    public float maxRange;
    Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        maxRange = 300f;
    }

	void Update ()
    {
        maxRange = 10f * player.Mass;
        setObjectLocation(gameObject);
    }
    

    bool doesObjectOutOfBorders(GameObject obj)
    {
        var range = maxRange;
        if (obj.transform.position.x > range || obj.transform.position.y > range || obj.transform.position.x < -range || obj.transform.position.y < -range)
        {
            return true;
        }
        return false;
    }

    void setObjectLocation(GameObject whatObj)
    {
        if (doesObjectOutOfBorders(whatObj))
        {
            Vector3 newObjCoordinates = whatObj.transform.position;
            
            if (whatObj.transform.position.x > maxRange)
            {
                newObjCoordinates.x = maxRange;
            }
            else if (whatObj.transform.position.x < -maxRange)
            {
                newObjCoordinates.x = -maxRange;
            }

            if (whatObj.transform.position.y > maxRange)
            {
                newObjCoordinates.y = maxRange;
            }
            else if (whatObj.transform.position.y < -maxRange)
            {
                newObjCoordinates.y = -maxRange;
            }
            whatObj.transform.position = newObjCoordinates;
        }
    }
}
