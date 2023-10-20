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
        
        

        //xBall�����̂Ƃ��͖񕪂��Ȃ��悤�ɂ���
        if (bottomNum != 0 && topNum != 0)
        {
            int dividingNum = GCD(bottomNum, topNum);
            Debug.Log(gameObject.name + dividingNum);

            //���q����̋����ő���񐔂Ŋ���
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject childObject = transform.GetChild(i).gameObject;

                if (childObject.CompareTag("MulDivBall") &&
                    childObject.GetComponent<MyNum>().motherOrChildFlag == false)
                {
                    reducedBottomNum = bottomNum / dividingNum;
                    Debug.Log(gameObject.name + "reducedBottomNum= " + reducedBottomNum);
                    childObject.GetComponent<MyNum>().name = reducedBottomNum.ToString(); //�����ŕs��o�邩��
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

            //�񕪂��Đ����ɂȂ�Ƃ��̋���
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
