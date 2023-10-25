using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCollider : MonoBehaviour
{
    [SerializeField] GameObject parentObject;

    

    private void Start()
    {
        if(parentObject != null)
        {
            parentObject.transform.position = transform.position;
        }

        
    }

    private void Update()
    {
        
    }

    //枠のコライダーに単独のNumberBallが接触した時
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.transform.parent.childCount == 1)
        {
            parentObject = collision.transform.parent.gameObject;
            
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("a");
        if (collision.transform.parent.childCount == 1)
        {
            Debug.Log("b");
            //吸い込めるようにする
            if (Mathf.Abs(collision.transform.position.x - transform.position.x) < gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2)
            {
                Debug.Log("c");
                if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log("d");
                    collision.transform.parent.position = transform.position;
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.transform.parent.childCount == 1)
        {
            //collision.gameObject.GetComponent<ReturnToInitialPos>().pullableFlag = false;
            //parentObjectが離れた時
            if (collision.gameObject == parentObject)
            {
                //となりのやつをずらしてくる
            }


        }
    }


}
