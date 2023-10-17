using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//fractionparentの子オブジェクトBarを取得できたときにこの関数起動
public class Multiply : MonoBehaviour
{

    public void DoMultiply()
    {
        //もしタップしたnumcirが分数の形になっていれば
        if (gameObject.transform.parent.Find("Bar(Clone)")?.gameObject != null)
        {
            //MulDivBallタグを持つオブジェクトを配列に格納
            GameObject[] muldivBalls = GameObject.FindGameObjectsWithTag("MulDivBall");

            //配列の中のオブジェクトが分母であれば削除
            foreach (GameObject obj in muldivBalls)
            {
                if (obj.transform.parent.Find("Bar(Clone)")?.gameObject != null　&&
                    obj.GetComponent<MyNum>().motherOrChildFlag == false)
                {
                    Destroy(obj.transform.parent.Find("Bar(Clone)").gameObject);
                    Destroy(obj);
                    
                }              
            }


            //xBallタグを持つオブジェクトを配列に格納
            GameObject[] xBalls = GameObject.FindGameObjectsWithTag("xBall");

            //配列の中のオブジェクトに掛け算セットを追加
            foreach (GameObject obj in xBalls)
            {
                InstantiateMultiplySet(obj);

            }
        }
        
        

    }

    //分数になっていないものは、掛け算のセットを追加する
    void InstantiateMultiplySet(GameObject xBall)
    {
        GameObject numcir = Instantiate((GameObject)Resources.Load("numcir"), new Vector3(xBall.transform.position.x - 1.6f, xBall.transform.position.y, xBall.transform.position.z), Quaternion.identity, xBall.transform.parent);
        xBall.transform.parent.Find("X 1(Clone)").gameObject.SetActive(true);

        numcir.GetComponent<MyNum>().motherOrChildFlag = true;
        numcir.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        

        numcir.name = gameObject.GetComponent<MyNum>().myNum.ToString();
        numcir.gameObject.GetComponent<MyNum>().SetMyNumber();


    }

}
