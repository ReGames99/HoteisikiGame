using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToInitialPos : MonoBehaviour
{
    Vector3 initialPos;


    GameObject collisionObject;

    IEnumerator Start()
    {
        yield return null; //ÇPÉtÉåÅ[ÉÄë“Ç¬

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
        else if(gameObject.CompareTag("NumberBall") && gameObject.transform.parent.childCount != 1)
        {
            ReturnToInitialPosition();
        }

    }
}
