using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceFraction : MonoBehaviour
{
    int bottomNum;
    int topNum;

    GameObject integerBall;
    GameObject bottomBall;
    int reducedBottomNum;
    int reducedTopNum;


    public void DoReduce()
    {
        Debug.Log(gameObject.name + "topNum= " + topNum);
        GetmyNum();
        Debug.Log(gameObject.name + "topNum= " + topNum);
        
        

        //xBallだけのときは約分しないようにする
        if (bottomNum != 0 && topNum != 0)
        {
            int dividingNum = GCD(bottomNum, topNum);
            Debug.Log(gameObject.name + dividingNum);

            //分子分母の球を最大公約数で割る
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject childObject = transform.GetChild(i).gameObject;

                if (childObject.CompareTag("MulDivBall") &&
                    childObject.GetComponent<MyNum>().motherOrChildFlag == false)
                {
                    reducedBottomNum = bottomNum / dividingNum;
                    Debug.Log(gameObject.name + "reducedBottomNum= " + reducedBottomNum);
                    childObject.GetComponent<MyNum>().name = reducedBottomNum.ToString(); //ここで不具合出るかも
                    childObject.GetComponent<MyNum>().SetMyNumber();

                    bottomBall = childObject;
                }

                if (childObject.CompareTag("NumberBall") || childObject.CompareTag("MulDivBall"))
                {
                    if (childObject.GetComponent<MyNum>().motherOrChildFlag == true)
                    {
                        
                        reducedTopNum = topNum / dividingNum;
                        Debug.Log(gameObject.name + "reducedTopNum= " + reducedTopNum);
                        if (childObject.GetComponent<MyNum>().variable == "x")
                        {
                            childObject.name = reducedTopNum.ToString() + "x";
                        }
                        else if (childObject.GetComponent<MyNum>().variable == "y")
                        {
                            childObject.name = reducedTopNum.ToString() + "y";
                        }
                        else if (childObject.GetComponent<MyNum>().variable == "n")
                        {
                            childObject.name = reducedTopNum.ToString();
                        }

                        childObject.GetComponent<MyNum>().SetMyNumber();

                        integerBall = childObject;
                    }

                }

                
            }

            //約分して整数になるときの挙動
            int divideNum = reducedTopNum / reducedBottomNum;
            if (reducedTopNum % reducedBottomNum == 0)
            {
                if (integerBall.GetComponent<MyNum>().variable == "x")
                {
                    integerBall.name = divideNum.ToString() + "x";
                }
                else if (integerBall.GetComponent<MyNum>().variable == "y")
                {
                    integerBall.name = divideNum.ToString() + "y";
                }
                else if (integerBall.GetComponent<MyNum>().variable == "n")
                {
                    integerBall.name = divideNum.ToString();
                }

                integerBall.GetComponent<MyNum>().SetMyNumber();
                Destroy(transform.Find("Bar(Clone)").gameObject);
                Destroy(bottomBall);
            }

        }
        
        

    }


    //最大公約数を求める
    private int GCD(int a, int b)
    {
        //自然数ではないといけない
        a = Mathf.Abs(a);
        b = Mathf.Abs(b);

        //大きい数字と小さい数字を入れ替える
        //簡単だけど再帰処理
        if (a < b)
        {
            return GCD(b, a);
        }

        //下記実際の処理
        while (b != 0)
        {
            int remain = a % b;
            a = b;
            b = remain;
        }

        return a;
    }


    //分子と分母のmyNumを取得
    void GetmyNum()
    {
        bottomNum = 0;
        topNum = 0;

        GameObject bottom = null;
        GameObject top = null;

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject childObject = transform.GetChild(i).gameObject;

            if (childObject.CompareTag("MulDivBall") &&
                childObject.GetComponent<MyNum>().motherOrChildFlag == false)
            {
                bottom = childObject;
            }
            if (childObject.CompareTag("MulDivBall") &&
                childObject.GetComponent<MyNum>().motherOrChildFlag == true)
            {
                
                top = childObject;
                Debug.Log(gameObject.name + "top= " + top);
            }
            if (childObject.CompareTag("NumberBall") &&
                childObject.GetComponent<MyNum>().motherOrChildFlag == true)
            {
                top = childObject;
            }
        }

        if (bottom != null && top != null)
        {
            bottomNum = bottom.GetComponent<MyNum>().myNum;
            topNum = top.GetComponent<MyNum>().myNum;           
        }
        Debug.Log(gameObject.name + "bottom= " + bottom);
        

    }
}
