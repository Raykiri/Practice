using UnityEngine;

public class wallsScript : MonoBehaviour
{
    Vector3 newObjPosition;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag != "Wall")
        {
            newObjPosition = obj.gameObject.transform.position;
            if (obj.transform.position.x > this.gameObject.transform.position.x && this.name == "East")
            {
                newObjPosition.x       = this.gameObject.transform.position.x;
                obj.transform.position = newObjPosition;
            }
            if (obj.transform.position.x < this.gameObject.transform.position.x && this.name == "West")
            {
                newObjPosition.x       = this.gameObject.transform.position.x;
                obj.transform.position = newObjPosition;
            }
            if (obj.transform.position.y > this.gameObject.transform.position.y && this.name == "North")
            {
                newObjPosition.y       = this.gameObject.transform.position.y;
                obj.transform.position = newObjPosition;
            }
            if (obj.transform.position.y < this.gameObject.transform.position.y && this.name == "South")
            {
                newObjPosition.y       = this.gameObject.transform.position.y;
                obj.transform.position = newObjPosition;
            }
        }
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        OnTriggerEnter2D(obj);
    }

}
