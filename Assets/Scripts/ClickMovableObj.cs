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


    // �ʏ��List�Ƃ���inspector�ň�����
    //[SerializeField] List<SpawnInfo> spawnList = new List<SpawnInfo>();
    //[SerializeField] List<string> list = new List<string>();

    [SerializeField] UnityEvent Event;


    //// ����class��Serializable����
    //[System.Serializable]
    //public class SpawnInfo
    //{
    //    public char scriptName; // Enemy��Prefab
    //    public char fuctionName;        // Enemy��spawn���W
    //}


    private void Start()
    {
        //Debug.Log(list[0]);
    }

    

    private void FanctionList()
    {
        // Event ���󂯎�����e�֐��̈����� collision�������āA�e�֐������s
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
                Debug.Log("click");


                //�ȉ��N���b�N���ɌĂяo�������֐�

                if(gameObject.GetComponent<SeparateNum>() != null)
                {
                    gameObject.GetComponent<SeparateNum>().SeparateNumberToBalls();
                }









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
