using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Cheap : MonoBehaviour
{
    public List<GameObject> slots;
    public GameObject       upgradeSprites;
    public bool             slotClicked;

    void Update()
    {
        if (slotClicked)
        {
            upgradeSprites.SetActive(true);
        }
    }
}
