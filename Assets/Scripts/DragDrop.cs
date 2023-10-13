using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    Vector3 initialPos;


    private void Start()
    {
        initialPos = transform.position;
    }

    void OnMouseDrag()
    {
        //以下四行はドラッグした時にオブジェクトを動かすコード
        Vector3 thisPosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
        worldPosition.z = initialPos.z;
        this.transform.position = worldPosition;
    }


    
}
