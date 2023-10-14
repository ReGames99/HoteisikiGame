using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultiDiv : MonoBehaviour
{
    bool onMouseFlag = false;

    float equalSymbolPosx;



    private void Start()
    {
        equalSymbolPosx = GameObject.Find("=").transform.position.x;
    }

    void InstantiateBarNum(Vector3 oppsiteBall)
    {
        //分数の線を引く
        Instantiate((GameObject)Resources.Load("Bar"), new Vector3(oppsiteBall.x , oppsiteBall.y - 1f, oppsiteBall.z), Quaternion.identity, gameObject.transform.parent);

        //線の下に分母の球を設置
        GameObject numcir = Instantiate((GameObject)Resources.Load("numcir"), new Vector3(oppsiteBall.x, oppsiteBall.y - 2f, oppsiteBall.z), Quaternion.identity, gameObject.transform.parent);
        numcir.name = gameObject.GetComponent<MyNum>().myNum.ToString();
        numcir.gameObject.GetComponent<MyNum>().SetMyNumber();
    }



    public void DoMultiDivide()
    {
        //NumberBall、Symbolタグを持つオブジェクトを配列に格納
        GameObject[] numberBalls = GameObject.FindObjectsOfType<GameObject>()
            .Where(go => go.CompareTag("NumberBall") || go.CompareTag("Symbol"))
            .ToArray();

        //配列の中から反対側のオブジェクトの下にActFraction()を実行
        foreach (GameObject obj in numberBalls)
        {
            Vector3 numberBallVec = obj.transform.position;
            if (gameObject.transform.position.x - equalSymbolPosx < 0)
            {
                if (numberBallVec.x > equalSymbolPosx)
                {
                    InstantiateBarNum(numberBallVec);
                    Destroy(gameObject);
                }
            }
            else if (gameObject.transform.position.x - equalSymbolPosx >= 0)
            {
                if (numberBallVec.x < equalSymbolPosx)
                {
                    InstantiateBarNum(numberBallVec);
                    Destroy(gameObject);
                }
            }
        }
    }


}
