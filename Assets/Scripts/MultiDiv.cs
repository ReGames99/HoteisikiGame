using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultiDiv : MonoBehaviour
{
    public GameObject symbolX;



    public void DoDivide()
    {
        if(symbolX != null)
        {
            //自分自身のXは先に消し、分数の線を生成しないようにする          
            symbolX.SetActive(false);
            Destroy(symbolX);


            //NumberBall、Symbolタグを持つオブジェクトを配列に格納
            GameObject[] numberBalls = GameObject.FindObjectsOfType<GameObject>()
                .Where(go => go.CompareTag("NumberBall") || go.CompareTag("Symbol"))
                .ToArray();

            //配列の中のオブジェクトの下にActFraction()を実行
            foreach (GameObject obj in numberBalls)
            {
                Vector3 numberBallVec = obj.transform.position;

                InstantiateBarNum(numberBallVec);
                Destroy(gameObject);
            }
        }    
    }



    void InstantiateBarNum(Vector3 oppsiteBall)
    {
        //分数の線を引く
        GameObject bar = Instantiate((GameObject)Resources.Load("Bar"), new Vector3(oppsiteBall.x, oppsiteBall.y - 0.7f, oppsiteBall.z), Quaternion.identity, gameObject.transform.parent);

        //線の下に分母の球を設置
        GameObject numcir = Instantiate((GameObject)Resources.Load("numcir"), new Vector3(oppsiteBall.x, oppsiteBall.y - 1.4f, oppsiteBall.z), Quaternion.identity, gameObject.transform.parent);
        numcir.name = gameObject.GetComponent<MyNum>().myNum.ToString();
        numcir.gameObject.GetComponent<MyNum>().SetMyNumber();

        //線を球の子オブジェクトにする
        bar.transform.parent = numcir.transform;
    }

}
