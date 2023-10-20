using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeparateNum : MonoBehaviour
{
    GameObject numcir;


    private void Start()
    {
        Invoke("NumVariableCheck", 0.05f);
    }


    public void SeparateNumberToBalls()
    {
        GameObject variableX = Instantiate((GameObject)Resources.Load("x"), new Vector3(gameObject.transform.position.x + 0.8f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, gameObject.transform.parent);
        numcir = Instantiate((GameObject)Resources.Load("numcir"), new Vector3(gameObject.transform.position.x - 0.8f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, gameObject.transform.parent);
        
        if(gameObject.transform.parent.Find("X 1(Clone)"))
        {
            gameObject.transform.parent.Find("X 1(Clone)").gameObject.SetActive(true);
        }
        else
        {
            GameObject symbolX = Instantiate((GameObject)Resources.Load("X 1"), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, gameObject.transform.parent);
            symbolX.transform.localScale = new Vector3(0.01f, 0.01f, 0);
        }
        

        //numcirを分子に設定
        numcir.GetComponent<MyNum>().motherOrChildFlag = true;

        //大きさの調整
        variableX.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        numcir.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        

        numcir.name = gameObject.GetComponent<MyNum>().myNum.ToString();
        numcir.gameObject.GetComponent<MyNum>().SetMyNumber();

        Destroy(gameObject);
    }


    //変数の時のみこのスクリプトを有効にする
    void NumVariableCheck()
    {
        if (gameObject.GetComponent<MyNum>().variable == "n")
        {
            SeparateNum destroyComponent = this;
            Destroy(destroyComponent);
        }
    }
}
