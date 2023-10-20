using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSub : MonoBehaviour
{
    bool mouseEnterFlag = false;
    bool mouseDownFlag = false;
    bool collisionFlag = false;

    bool mojicorrectFlag;

    GameObject otherObject;

    int addnum;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(gameObject.tag))
        {
            otherObject = collision.gameObject;
            collisionFlag = true;
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionFlag = false;
        otherObject = null;
    }

    private void OnMouseEnter()
    {
        mouseEnterFlag = true;
    }

    private void OnMouseExit()
    {
        mouseEnterFlag = false;
    }

    private void OnMouseDown()
    {
        if (mouseEnterFlag == true)
        {
            mouseDownFlag = true;
            
        }
    }

    private void OnMouseUp()
    {
        
        if(collisionFlag == true)
        {
            MojiCorrectCheck();
            if (mojicorrectFlag == true)
            {
                if (mouseDownFlag == true)
                {
                    AddNumber();
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.GetComponent<ReturnToInitialPos>().ReturnToInitialPosition();
                }

            }
            else
            {
                gameObject.GetComponent<ReturnToInitialPos>().ReturnToInitialPosition();
            }
        }
        else
        {
            gameObject.GetComponent<ReturnToInitialPos>().ReturnToInitialPosition();
        }
    }

    void AddNumber()
    {
        addnum = otherObject.GetComponent<MyNum>().myNum + gameObject.GetComponent<MyNum>().myNum;
        //otherObject.GetComponent<MyNum>().myNum = addnum;
        Debug.Log(addnum);

        if (gameObject.GetComponent<MyNum>().variable == "x")
        {
            if (addnum >= 0)
            {
                otherObject.name = "+" + addnum.ToString() + "x";
            }
            else
            {
                otherObject.name = addnum.ToString() + "x";
            }

        }
        else if (gameObject.GetComponent<MyNum>().variable == "y")
        {
            if (addnum >= 0)
            {
                otherObject.name = "+" + addnum.ToString() + "y";
            }
            else
            {
                otherObject.name = addnum.ToString() + "y";
            }
        }
        else if (gameObject.GetComponent<MyNum>().variable == "n")
        {
            if (addnum >= 0)
            {
                otherObject.name = "+" + addnum.ToString();
            }
            else
            {
                otherObject.name = addnum.ToString();
            }
        }

        otherObject.GetComponent<MyNum>().SetMyNumber();
        
    }


    void MojiCorrectCheck()
    {
        if (gameObject.GetComponent<MyNum>().variable == "x" &&
            otherObject.GetComponent<MyNum>().variable == "x")
        {
            mojicorrectFlag = true;
        }
        else if (gameObject.GetComponent<MyNum>().variable == "y" &&
                 otherObject.GetComponent<MyNum>().variable == "y")
        {
            mojicorrectFlag = true;
        }
        else if (gameObject.GetComponent<MyNum>().variable == "n" &&
                 otherObject.GetComponent<MyNum>().variable == "n")
        {
            mojicorrectFlag = true;
        }
    }

}
