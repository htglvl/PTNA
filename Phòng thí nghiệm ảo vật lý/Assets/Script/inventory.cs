using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public bool[] isfull;
    public GameObject[] slots;
    private void Update() {
        if (Input.GetMouseButtonDown(2))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select Stage
                if (hit.transform.CompareTag("dungcu") && hit.transform.GetComponent<pickup>())
                {
                    hit.transform.GetComponent<pickup>().ischoosen = true;
                }
            }
        }
    }
    
}
