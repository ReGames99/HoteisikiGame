using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositiveNegative : MonoBehaviour
{
    float equalSymbolPosx;

    bool changableFlag = true; //trueのときは範囲外

    bool plusFlag ;

    private void Start()
    {
        equalSymbolPosx = GameObject.Find("=").transform.position.x;
    }


    private void OnMouseDrag()
    {
        //Mathf.Abs(n)はｎの絶対値
        if(Mathf.Abs(gameObject.transform.position.x - equalSymbolPosx) <= 0.3f &&
           Mathf.Abs(gameObject.transform.position.x - equalSymbolPosx) >= 0f)
        {          
            //範囲に入った時の１フレーム目の挙動
            if(changableFlag == true)
            {
                changableFlag = false;

                if(gameObject.transform.position.x - equalSymbolPosx < 0)
                {
                    plusFlag = false;
                }
                else
                {
                    plusFlag = true;
                }
            }
            
        }
        //範囲外に出たとき、入ってきた側と反対方向に出れば符号変更
        else
        {
            if(changableFlag == false)
            {
                if (plusFlag == false)
                {
                    if (gameObject.transform.position.x - equalSymbolPosx >= 0)
                    {
                        ChangePosNeg();
                    }
                }
                else if(plusFlag == true)
                {
                    if (gameObject.transform.position.x - equalSymbolPosx < 0)
                    {
                        ChangePosNeg();
                    }
                }
            }

            changableFlag = true;
        }
    }

    void ChangePosNeg()
    {       
            int newMyNum = 0 - gameObject.GetComponent<MyNum>().myNum; 

            if(gameObject.GetComponent<MyNum>().variable   == "x")
            {
                if(newMyNum >= 0)
                {
                    gameObject.name = "+" + newMyNum.ToString() + "x";
                }
                else
                {
                    gameObject.name = newMyNum.ToString() + "x";
                }           
            }
            else if (gameObject.GetComponent<MyNum>().variable == "y")
            {
                if (newMyNum >= 0)
                {
                    gameObject.name = "+" + newMyNum.ToString() + "y";
                }
                else
                {
                    gameObject.name = newMyNum.ToString() + "y";
                }
            }
            else if(gameObject.GetComponent<MyNum>().variable == "n")
            {
                if (newMyNum >= 0)
                {
                    gameObject.name = "+" + newMyNum.ToString();
                }
                else
                {
                    gameObject.name = newMyNum.ToString();
                }
            }

            gameObject.GetComponent<MyNum>().SetMyNumber();
    }
}
