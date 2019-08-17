using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TimeBody : MonoBehaviour
{
    public bool isrewinding = false;
    List<PointInTime> pointInTimes;
    Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        pointInTimes = new List<PointInTime>();
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || GameObject.FindGameObjectWithTag("Time").GetComponent<TimeControlSystem>().TimeControl.value >= 0)
        {
            StopRewind();
        }else
        {
            StartRewind();
        }
        if (Input.GetKeyDown(KeyCode.R) || GameObject.FindGameObjectWithTag("Time").GetComponent<TimeControlSystem>().TimeControl.value == -1)
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
        if (pointInTimes.Count > Mathf.Round(30f / Time.fixedDeltaTime))
        {
            pointInTimes.RemoveAt( pointInTimes.Count - 1);
        }
        pointInTimes.Insert(0, new PointInTime(transform.position, transform.rotation));
    }
    void Rewind()
    {
        if (pointInTimes.Count > 0)
        {
            PointInTime pointInTime = pointInTimes[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointInTimes.RemoveAt(0);
        }
        else
        {
            StopRewind(); 
            GameObject.FindGameObjectWithTag("Time").GetComponent<TimeControlSystem>().TimeControl.value = 0;
        }
    }
    public void StartRewind()
    {
        isrewinding = true;
        RB.isKinematic = true;
    }
    public void StopRewind()
    {
        isrewinding = false;
        RB.isKinematic = false;
    }
}
