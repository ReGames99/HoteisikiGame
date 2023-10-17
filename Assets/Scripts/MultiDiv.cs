using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


//X(かける)を取得できたときに関数起動
public class MultiDiv : MonoBehaviour
{
    public GameObject symbolX;

    GameObject fractionParent;

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

                obj.transform.parent = fractionParent.transform;

                Destroy(gameObject);
            }
        }    
    }



    void InstantiateBarNum(Vector3 nbandsym)
    {
        //分数セットの親オブジェクトを生成
        fractionParent = Instantiate((GameObject)Resources.Load("fraction parent"), new Vector3(nbandsym.x, nbandsym.y - 0.7f, nbandsym.z), Quaternion.identity, gameObject.transform.parent);

        //分数の線を引く
        GameObject bar = Instantiate((GameObject)Resources.Load("Bar"), new Vector3(nbandsym.x, nbandsym.y - 0.7f, nbandsym.z), Quaternion.identity, fractionParent.transform);

        //線の下に分母の球を設置
        GameObject numcir = Instantiate((GameObject)Resources.Load("numcir"), new Vector3(nbandsym.x, nbandsym.y - 1.4f, nbandsym.z), Quaternion.identity, fractionParent.transform);
        numcir.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        numcir.name = gameObject.GetComponent<MyNum>().myNum.ToString();
        numcir.gameObject.GetComponent<MyNum>().SetMyNumber();


        //Barが存在するなら、

    }

}
