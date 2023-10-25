using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabParent : MonoBehaviour
{
    bool aloneFlag;

    Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.parent.position;
    }

    private void OnMouseDown()
    {
        if(transform.parent.childCount == 1)
        {
            aloneFlag = true;
        }
    }

    private void OnMouseDrag()
    {
        if (aloneFlag == true)
        {
            transform.parent.position = transform.position;
        }
    }

    private void OnMouseUp()
    {
        
        
         //transform.parent.position = initialPos;
        
    }


}
