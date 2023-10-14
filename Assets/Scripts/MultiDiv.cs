using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultiDiv : MonoBehaviour
{
    bool onMouseFlag = false;

    float equalSymbolPosx;

    public GameObject symbolX;


    private void Start()
    {
        equalSymbolPosx = GameObject.Find("=").transform.position.x;
    }

    void InstantiateBarNum(Vector3 oppsiteBall)
    {
        //�����̐�������
        Instantiate((GameObject)Resources.Load("Bar"), new Vector3(oppsiteBall.x , oppsiteBall.y - 0.7f, oppsiteBall.z), Quaternion.identity, gameObject.transform.parent);

        //���̉��ɕ���̋���ݒu
        GameObject numcir = Instantiate((GameObject)Resources.Load("numcir"), new Vector3(oppsiteBall.x, oppsiteBall.y - 1.4f, oppsiteBall.z), Quaternion.identity, gameObject.transform.parent);
        numcir.name = gameObject.GetComponent<MyNum>().myNum.ToString();
        numcir.gameObject.GetComponent<MyNum>().SetMyNumber();

        
    }



    public void DoDivide()
    {
        //�������g��X�͐�ɏ����Ă���
        symbolX.SetActive(false);
        Destroy(symbolX);

        //NumberBall�ASymbol�^�O�����I�u�W�F�N�g��z��Ɋi�[
        GameObject[] numberBalls = GameObject.FindObjectsOfType<GameObject>()
            .Where(go => go.CompareTag("NumberBall") || go.CompareTag("Symbol"))
            .ToArray();

        //�z��̒��̃I�u�W�F�N�g�̉���ActFraction()�����s
        foreach (GameObject obj in numberBalls)
        {
            Vector3 numberBallVec = obj.transform.position;
                           
            InstantiateBarNum(numberBallVec);
            Destroy(gameObject);         
        }
    }

}
