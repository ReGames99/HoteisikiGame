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
        GetmyNum();

        //if(bottomNum == 0 && topNum != 0)

        int dividingNum = GCD(bottomNum, topNum);

        //���q����̋����ő���񐔂Ŋ���
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject childObject = transform.GetChild(i).gameObject;

            if (childObject.CompareTag("MulDivBall") &&
                childObject.GetComponent<MyNum>().motherOrChildFlag == false)
            {
                Debug.Log(dividingNum);
                reducedBottomNum = bottomNum / dividingNum;
                childObject.GetComponent<MyNum>().name = reducedBottomNum.ToString();
                childObject.GetComponent<MyNum>().SetMyNumber();

                bottomBall = childObject;
            }

            if (childObject.CompareTag("NumberBall") &&
                childObject.GetComponent<MyNum>().motherOrChildFlag == true)
            {
                Debug.Log(dividingNum);
                reducedTopNum = topNum / dividingNum;
                childObject.GetComponent<MyNum>().name = reducedTopNum.ToString();
                childObject.GetComponent<MyNum>().SetMyNumber();

                integerBall = childObject;
            }
        }

        int divideNum = reducedTopNum / reducedBottomNum;
        if (reducedTopNum % reducedBottomNum == 0)
        {
            Debug.Log("a");
            integerBall.GetComponent<MyNum>().name = divideNum.ToString();
            integerBall.GetComponent<MyNum>().SetMyNumber();
            Destroy(transform.Find("Bar(Clone)").gameObject);
            Destroy(bottomBall);
        }

    }


    //�ő���񐔂����߂�
    private int GCD(int a, int b)
    {
        //���R���ł͂Ȃ��Ƃ����Ȃ�
        a = Mathf.Abs(a);
        b = Mathf.Abs(b);

        //�傫�������Ə��������������ւ���
        //�ȒP�����ǍċA����
        if (a < b)
        {
            return GCD(b, a);
        }

        //���L���ۂ̏���
        while (b != 0)
        {
            int remain = a % b;
            a = b;
            b = remain;
        }

        return a;
    }


    //���q�ƕ����myNum���擾
    void GetmyNum()
    {
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

    }
}
