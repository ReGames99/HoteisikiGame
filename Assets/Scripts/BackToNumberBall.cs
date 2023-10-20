using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToNumberBall : MonoBehaviour
{
    //�����̐e�I�u�W�F�N�g�̎q�ǂ��̒����番�q��muldivBall��X 1���擾�B���������ꍇ�͉����N����Ȃ��B
    public void BackNum()
    {
        if(gameObject.transform.parent.Find("X 1(Clone)").gameObject.activeSelf == true)
        {
            gameObject.transform.parent.Find("X 1(Clone)").gameObject.SetActive(false);


            for (int i = 0; i < gameObject.transform.parent.childCount; i++)
            {
                GameObject childObject = gameObject.transform.parent.GetChild(i).gameObject;

                if (childObject.CompareTag("MulDivBall") &&
                    childObject.GetComponent<MyNum>().motherOrChildFlag == true)
                {
                    GameObject backNum = Instantiate((GameObject)Resources.Load("CapNum"), new Vector3(gameObject.transform.parent.Find("X 1(Clone)").transform.position.x, gameObject.transform.parent.Find("X 1(Clone)").transform.position.y, gameObject.transform.parent.Find("X 1(Clone)").transform.position.z), Quaternion.identity, gameObject.transform.parent);

                    //xball�ł�����`���Ă��Ȃ��̂ŁAyBall���ł�����ύX
                    backNum.name = childObject.GetComponent<MyNum>().myNum.ToString() + "x";
                    backNum.gameObject.GetComponent<MyNum>().SetMyNumber();

                    Destroy(childObject);
                }
            }
            Destroy(gameObject);
        }
        
    }
}
