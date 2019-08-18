using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class stat : MonoBehaviour
{
    private Rigidbody ry;
    private float speed;
    public TextMeshProUGUI cubestat;
    [HideInInspector]
    public bool selec;
    // Start is called before the first frame update
    void Start()
    {
        ry = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = ry.velocity.magnitude * 3.6;
        if (selec == true)
        {
            cubestat.text = "Toc Do: " + System.Math.Round(vel, 2).ToString() + " km/h";
        }
    }
}
