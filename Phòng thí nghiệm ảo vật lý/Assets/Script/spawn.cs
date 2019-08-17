using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject item;
    public Transform spawnPos;
    public void spawndropitem(){
        Instantiate(item, spawnPos);
    }
}
