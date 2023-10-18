using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceFraction : MonoBehaviour
{
    int bottomNum;
    int topNum;


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
                int num = bottomNum / dividingNum;
                childObject.GetComponent<MyNum>().name = num.ToString();
                childObject.GetComponent<MyNum>().SetMyNumber();
            }
            if (childObject.CompareTag("NumberBall") &&
                childObject.GetComponent<MyNum>().motherOrChildFlag == true)
            {
                Debug.Log(dividingNum);
                int num = topNum / dividingNum;
                childObject.GetComponent<MyNum>().name = num.ToString();
                childObject.GetComponent<MyNum>().SetMyNumber();
            }
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
                Debug.Log(top);
            }
        }
        
        if (bottom != null && top != null)
        {
            bottomNum = bottom.GetComponent<MyNum>().myNum;
            topNum = top.GetComponent<MyNum>().myNum;
            Debug.Log(bottomNum);
            Debug.Log(topNum);
        }

    }
}
