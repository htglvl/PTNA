using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    private inventory inventories;
    public int i;
    private void Start() {
        inventories = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<inventory>();
    }
    private void Update() {
        if (transform.childCount <= 0)
        {
            
            inventories.isfull[i] = false;
        }
    }
    public void dropitem(){
        foreach (Transform child in transform)
        {
            child.GetComponent<spawn>().spawndropitem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
