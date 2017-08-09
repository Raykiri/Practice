using UnityEngine;

public class SightScript : MonoBehaviour
{
    public bool enemyFound;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (!enemyFound && (obj.tag == "Player" || obj.tag == "Enemy"))
        {
            enemyFound = true;
            transform.parent.GetComponent<EnemyControler>().target      = obj.gameObject;
            transform.parent.GetComponent<EnemyControler>().targetFound = enemyFound;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject == transform.parent.GetComponent<EnemyControler>().target)
        {
            enemyFound = false;
            transform.parent.GetComponent<EnemyControler>().target      = null;
            transform.parent.GetComponent<EnemyControler>().targetFound = enemyFound;
        }
    }
}
