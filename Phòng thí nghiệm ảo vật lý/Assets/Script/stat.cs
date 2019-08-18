using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class stat : MonoBehaviour
{
    private Rigidbody ry;
    private float speed, lastVelocity, acceleration;
    private TextMeshProUGUI cubestat;
    public bool isStopTime = false;
    [HideInInspector]
    public bool selec;
    // Start is called before the first frame update
    void Start()
    {
        cubestat = GameObject.Find("stat").GetComponent<TextMeshProUGUI>();
        ry = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStopTime == true)
        {
            if (selec == true)
            {
                cubestat.text = "dung cu cham vao hinh nay se dung thoi gian";
            }
        }
        else
        {
            var vel = ry.velocity.magnitude * 3.6 * 5 / 18;
            if (selec == true)
            {
                cubestat.text = "Toc Do: " + System.Math.Round(vel, 2).ToString() + " m/s "
                              + "Khoi Luong: " + System.Math.Round(ry.mass, 2).ToString() + " kg "
                              + "Gia Toc: " + System.Math.Round(acceleration, 2).ToString() + "m/s2 ";

            }
        }

    }
    private void FixedUpdate()
    {
        acceleration = (ry.velocity.magnitude * 3.6f * 5 / 18 - lastVelocity) / Time.fixedDeltaTime;
        lastVelocity = ry.velocity.magnitude * 3.6f * 5 / 18;
    }
}
