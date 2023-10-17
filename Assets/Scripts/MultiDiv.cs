using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


//X(かける)を取得できたときに関数起動
public class MultiDiv : MonoBehaviour
{
    GameObject fractionParent;

    public void DoDivide()
    {
        if(gameObject.transform.parent.Find("X 1(Clone)")?.gameObject != null &&
            gameObject.GetComponent<MyNum>().motherOrChildFlag == true)
        {
            //自分自身のXは先に消し、分数の線を生成しないようにする          
            gameObject.transform.parent.Find("X 1(Clone)").gameObject.SetActive(false);


            //NumberBall、Symbolタグを持つオブジェクトを配列に格納
            GameObject[] numberBalls = GameObject.FindGameObjectsWithTag("NumberBall");
            foreach (GameObject obj in numberBalls)
            {
                InstantiateBarNum(obj);
            }

            GameObject[] Symbols = GameObject.FindGameObjectsWithTag("Symbol");
            foreach (GameObject obj in Symbols)
            {
                InstantiateBarNum(obj); 
            }

            GameObject[] xBalls = GameObject.FindGameObjectsWithTag("xBall");
            foreach (GameObject obj in xBalls)
            {
                
                if (obj.transform.parent.gameObject != gameObject.transform.parent.gameObject &&
                    obj.transform.parent.Find("X 1(Clone)").gameObject.activeSelf == false)
                {
                    //Debug.Log(obj.transform.parent.Find("X 1(Clone)").gameObject);
                    InstantiateBarNum(obj);                 
                }      
            }

            Destroy(gameObject);

        }    
    }



    void InstantiateBarNum(GameObject nbandsym)
    {
        //分数の線を引く
        GameObject bar = Instantiate((GameObject)Resources.Load("Bar"), new Vector3(nbandsym.transform.position.x, nbandsym.transform.position.y - 0.7f, nbandsym.transform.position.z), Quaternion.identity, nbandsym.gameObject.transform.parent);

        //線の下に分母の球を設置し、分母に設定
        GameObject numcir = Instantiate((GameObject)Resources.Load("numcir"), new Vector3(nbandsym.transform.position.x, nbandsym.transform.position.y - 1.4f, nbandsym.transform.position.z), Quaternion.identity, nbandsym.gameObject.transform.parent);
        numcir.GetComponent<MyNum>().motherOrChildFlag = false;

        //大きさの調整
        numcir.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        
        numcir.name = gameObject.GetComponent<MyNum>().myNum.ToString();
        numcir.gameObject.GetComponent<MyNum>().SetMyNumber();

    }

}
