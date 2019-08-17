using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    private inventory inventories;
    public GameObject itembutton;
    public bool ischoosen;
    private void Start()
    {
        inventories = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<inventory>();
    }
    private void Update()
    {
        if (ischoosen == true)
        {
            for (int i = 0; i < inventories.slots.Length; i++)
            {
                if (inventories.isfull[i] == false)
                {
                    inventories.isfull[i] = true;
                    Instantiate(itembutton, inventories.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }

            }
        }

    }
}

