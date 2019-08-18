using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeControlSystem : MonoBehaviour
{
    public TextMeshProUGUI timeword;
    public float timesclider;
    public Slider TimeControl;
    List<Vector3> positions;
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();
        timesclider = 1;
        TimeControl.value = 1f;
        timeword.text = timesclider.ToString();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timesclider != 0)
            {
                TimeControl.value = 0;
            }
            else
            {
                TimeControl.value = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            TimeControl.value = -1;
        }
        timesclider = TimeControl.value;
        timeword.text = System.Math.Round(timesclider, 2).ToString();
        Time.timeScale = Mathf.Abs(timesclider);    
    }
    
}
