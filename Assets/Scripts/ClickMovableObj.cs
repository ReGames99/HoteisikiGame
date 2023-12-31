using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickMovableObj : MonoBehaviour
{
    bool onMouseFlag = false;

    float mouseDownPosx;
    float mouseDownPosy;
    float mouseUpPosx;
    float mouseUpPosy;


    [SerializeField] UnityEvent Event;

    

    private void FanctionList()
    {
        // Event が受け取った各関数の引数に collisionを代入して、各関数を実行
        Event.Invoke();
    }



    private void OnMouseDown()
    {
        mouseDownPosx = Input.mousePosition.x;
        mouseDownPosy = Input.mousePosition.y;
    }

    private void OnMouseUp()
    {
        mouseUpPosx = Input.mousePosition.x;
        mouseUpPosy = Input.mousePosition.y;

        if (onMouseFlag == true)
        {
            if (mouseUpPosx - mouseDownPosx <= 0.1f && mouseUpPosx - mouseDownPosx >= -0.1f &&
                mouseUpPosy - mouseDownPosy <= 0.1f && mouseUpPosy - mouseDownPosy >= -0.1f)
            {
                FanctionList();
            }
        }
    }

    private void OnMouseEnter()
    {
        onMouseFlag = true;
    }
    private void OnMouseExit()
    {
        onMouseFlag = false;
    }

    
}
