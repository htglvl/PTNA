using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragobject : MonoBehaviour
{
    private Vector3 Moffset;
    private float mZcoord;

    void OnMouseDown() {
        mZcoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Moffset = gameObject.transform.position - GetMouseWorldPos();        
    }
    private Vector3 GetMouseWorldPos(){
        Vector3 mousepoint = Input.mousePosition;
        mousepoint.z = mZcoord;
        return Camera.main.ScreenToWorldPoint(mousepoint);
    }
    void OnMouseDrag() {
        transform.position = GetMouseWorldPos() + Moffset;    
    }
}
