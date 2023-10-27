using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSign : MonoBehaviour
{
    MoveFraction moveFraction;

    [SerializeField] public GameObject parentObject;

    [SerializeField] bool pullableFlag = false;

    [SerializeField] int colliderCount = 0;

    private void Start()
    {
        if (parentObject != null)
        {
            parentObject.transform.position = transform.position;
        }

        moveFraction = GameObject.Find("wakuManager").GetComponent<MoveFraction>();
    }



    private void Update()
    {
        if (pullableFlag == true)
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
            //ãzÇ¢çûÇﬂÇÈÇÊÇ§Ç…Ç∑ÇÈ
            if (Mathf.Abs(collision.transform.position.x - transform.position.x) < gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2
                && colliderCount == 1)
            {

            }
            else
            {

            }
        }

    }


    //ògÇÃÉRÉâÉCÉ_Å[Ç…íPì∆ÇÃNumberBallÇ™ê⁄êGÇµÇΩéû
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
            pullableFlag = false;

            //parentObjectÇ™ó£ÇÍÇΩéû
            if (collision.transform.parent.gameObject == parentObject)
            {
                Debug.Log("c");
                //Ç∆Ç»ÇËÇÃÇ‚Ç¬ÇÇ∏ÇÁÇµÇƒÇ≠ÇÈ
                moveFraction.MoveLeft();
            }


        }

    }
}
