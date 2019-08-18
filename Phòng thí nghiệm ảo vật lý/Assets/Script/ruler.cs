using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ruler : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float counter;
    private float dist;
    public Transform Origin;
    public Transform Destination;
    public float lineDrawSpeed;
    public TextMeshProUGUI stat;
    [HideInInspector]
    public bool selec;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetWidth(0.1f , 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, Origin.position);
        Vector3 pointA = Origin.position;
        Vector3 pointB = Destination.position;
        lineRenderer.SetPosition(1, pointB);
        if (selec == true)
        {
            stat.text = "Độ dài: " + System.Math.Round(Vector3.Distance(pointA, pointB),2).ToString()  + " m";
        }
    }
}
