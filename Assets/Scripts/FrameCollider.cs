using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//すいこむスクリプト！！！！
public class FrameCollider : MonoBehaviour
{
    [SerializeField] GameObject parentObject;

    bool pullableFlag = false;

    private void Start()
    {
        if(parentObject != null)
        {
            parentObject.transform.position = transform.position;
        }

        
    }

    private void Update()
    {
        if(pullableFlag == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                parentObject.transform.position = gameObject.transform.position;
            }
                
        }
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
                pullableFlag = true;
            }
            else
            {
                pullableFlag = false;
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.transform.parent.childCount == 1)
        {
            pullableFlag = false;
            parentObject = null;
            //parentObjectが離れた時
            if (collision.gameObject == parentObject)
            {
                //となりのやつをずらしてくる
            }


        }
    }


}
