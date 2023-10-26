using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//すいこむスクリプト！！！！
public class FrameCollider : MonoBehaviour
{
    MoveFraction moveFraction;

    [SerializeField] public GameObject parentObject;

    [SerializeField] bool pullableFlag = false;

    [SerializeField] int colliderCount = 0;

    private void Start()
    {
        if(parentObject != null)
        {
            parentObject.transform.position = transform.position;
        }

        moveFraction = GameObject.Find("wakuManager").GetComponent<MoveFraction>();
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


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.parent.childCount == 1)
        {
            //吸い込めるようにする
            if (Mathf.Abs(collision.transform.position.x - transform.position.x) < gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2
                && colliderCount == 1)
            {
                pullableFlag = true;
            }
            else
            {
                pullableFlag = false;
            }
        }

    }


    //枠のコライダーに単独のNumberBallが接触した時
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("NumberBall"))
        {
            colliderCount++;
        }
        

        if (collision.transform.parent.childCount == 1)
        {
            
            if(colliderCount == 2)
            {
                moveFraction.MoveRight();
            }
            parentObject = collision.transform.parent.gameObject;
        }
        if(colliderCount == 1)
        {
            parentObject = collision.transform.parent.gameObject;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NumberBall"))
        {
            colliderCount--;
        }

        Debug.Log("a");
        if (collision.transform.parent.childCount == 1)
        {
            Debug.Log("b");
            pullableFlag = false;

            //parentObjectが離れた時
            if (collision.transform.parent.gameObject == parentObject)
            {
                Debug.Log("c");
                //となりのやつをずらしてくる
                moveFraction.MoveLeft();
            }


        }
        
    }


}
