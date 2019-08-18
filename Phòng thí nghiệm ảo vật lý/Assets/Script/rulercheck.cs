using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rulercheck : MonoBehaviour
{
    private GameObject ball, ball1;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Cube");
        ball1 = GameObject.Find("Cube (1)");
    }

    // Update is called once per frame
    void Update()
    {
        if (ball == null || ball1 == null)
        {
            Destroy(gameObject);
        }
    }
}
