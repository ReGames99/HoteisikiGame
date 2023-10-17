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
        if (gameObject.transform.parent.Find("Bar(Clone)")?.gameObject != null &&
            gameObject.GetComponent<MyNum>().motherOrChildFlag == false)
        {
            //MulDivBallタグを持つオブジェクトを配列に格納
            GameObject[] muldivBalls = GameObject.FindGameObjectsWithTag("MulDivBall");

            //配列の中のオブジェクトが分母であれば削除
            foreach (GameObject obj in muldivBalls)
            {
                if (obj.transform.parent.Find("Bar(Clone)")?.gameObject != null)
                {
                    Destroy(obj.transform.parent.Find("Bar(Clone)").gameObject);
                    Destroy(obj);
                    
                }              
            }


            //muldivBallsの親を取得
            GameObject[] muldivParents = new GameObject[muldivBalls.Length];
            for (int i = 0; i < muldivBalls.Length; i++)
            {
                muldivParents[i] = muldivBalls[i].transform.parent.gameObject;
            }


            //xBallタグを持つオブジェクトを配列に格納
            GameObject[] xBalls = GameObject.FindGameObjectsWithTag("xBall");

            //分母を削除した分数以外の項に掛け算セットを追加
            foreach (GameObject obj in xBalls)
            {
                if(muldivParents.Contains(obj.transform.parent.gameObject) == false)
                {
                    InstantiateMultiplySet(obj);
                }
                
                

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
