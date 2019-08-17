using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TimeBody : MonoBehaviour
{
    public bool isrewinding = false;
    List<Vector3> positions;
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopRewind();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRewind();
        }
        if (GetComponent<TimeControlSystem>().timesclider >= 0)
        {
            StopRewind();
        }
        else
        {
            StartRewind();
        }
    }
    private void FixedUpdate()
    {
        if (isrewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }
    void Record()
    {
        positions.Insert(0, transform.position);
    }
    void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            StopRewind(); 
        }
    }
    public void StartRewind()
    {
        isrewinding = true;
    }
    public void StopRewind()
    {
        isrewinding = false;
        GetComponent<TimeControlSystem>().TimeControl.value = 0;
    }
}
