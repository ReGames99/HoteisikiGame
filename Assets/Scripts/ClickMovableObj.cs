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


    // 通常のListとしてinspectorで扱える
    //[SerializeField] List<SpawnInfo> spawnList = new List<SpawnInfo>();
    //[SerializeField] List<string> list = new List<string>();

    [SerializeField] UnityEvent Event;


    //// 自作classはSerializableする
    //[System.Serializable]
    //public class SpawnInfo
    //{
    //    public char scriptName; // EnemyのPrefab
    //    public char fuctionName;        // Enemyのspawn座標
    //}


    private void Start()
    {
        //Debug.Log(list[0]);
    }

    

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
                Debug.Log("click");


                //以下クリック時に呼び出したい関数

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
