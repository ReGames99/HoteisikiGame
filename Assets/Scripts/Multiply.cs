using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//fractionparentの子オブジェクトBarを取得できたときにこの関数起動
public class Multiply : MonoBehaviour
{

    public void DoMultiply()
    {
        if (gameObject.transform.parent.Find("Bar(Clone)")?.gameObject != null)
        {
            Debug.Log("起動！");

            //MulDivBallタグを持つオブジェクトを配列に格納
            GameObject[] muldivBalls = GameObject.FindGameObjectsWithTag("MulDivBall");

            //配列の中のオブジェクトを削除
            foreach (GameObject obj in muldivBalls)
            {
                if (obj.transform.Find("Bar(Clone)")?.gameObject != null)
                {
                    Destroy(obj);
                }              
            }


            //MulDivBallタグを持つオブジェクトを配列に格納
            GameObject[] xBalls = GameObject.FindGameObjectsWithTag("xBall");

            //配列の中のオブジェクトにActFraction()を実行
            foreach (GameObject obj in xBalls)
            {
                InstantiateMultiplySet(obj);

            }
        }
        
        

    }

    void InstantiateMultiplySet(GameObject xBall)
    {
        //分数セットを分解



        GameObject numcir = Instantiate((GameObject)Resources.Load("numcir"), new Vector3(xBall.transform.position.x - 1.6f, xBall.transform.position.y, xBall.transform.position.z), Quaternion.identity, gameObject.transform.parent);
        numcir.GetComponent<MultiDiv>().symbolX = Instantiate((GameObject)Resources.Load("X 1"), new Vector3(xBall.transform.position.x - 0.8f, xBall.transform.position.y, xBall.transform.position.z), Quaternion.identity, gameObject.transform.parent);       
        numcir.name = gameObject.GetComponent<MyNum>().myNum.ToString();
        numcir.gameObject.GetComponent<MyNum>().SetMyNumber();
    }

}
