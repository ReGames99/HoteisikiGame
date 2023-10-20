using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToInitialPos : MonoBehaviour
{
    Vector3 initialPos;

    void Start()
    {
        initialPos = transform.position;
    }

    
    public void ReturnToInitialPosition()
    {
        transform.position = initialPos;
    }

    private void OnMouseUp()
    {
        if(gameObject.CompareTag("xBall") || gameObject.CompareTag("MulDivBall"))
        {
            ReturnToInitialPosition();
        }
    }
}
