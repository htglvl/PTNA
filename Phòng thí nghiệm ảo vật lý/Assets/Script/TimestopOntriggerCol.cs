using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimestopOntriggerCol : MonoBehaviour
{
    private GameObject TimeStop;
    public string selectableTag = "dungcu";
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(selectableTag))
        {
            GameObject.Find("TimeManager").GetComponent<TimeControlSystem>().TimeControl.value = 0;
        }
    }
}
