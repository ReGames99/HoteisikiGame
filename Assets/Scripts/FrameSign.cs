using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSign : MonoBehaviour
{
    MoveFraction moveFraction;

    [SerializeField] public GameObject parentObject;

    [SerializeField] int colliderCount = 0;

    private void Start()
    {
        moveFraction = GameObject.Find("wakuManager").GetComponent<MoveFraction>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.parent.childCount == 1)
        {
            //吸い込めるようにする
            if (Mathf.Abs(collision.transform.position.x - transform.position.x) < gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2
                && colliderCount == 1)
            {

            }
            else
            {

            }
        }

    }


    //枠のコライダーに単独のNumberBallが接触した時
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NumberBall"))
        {
            colliderCount++;
        }


        if (collision.transform.parent.childCount == 1)
        {

            if (colliderCount == 2)
            {
                moveFraction.MoveRight();
            }
            parentObject = collision.transform.parent.gameObject;
        }
        if (colliderCount == 1)
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
