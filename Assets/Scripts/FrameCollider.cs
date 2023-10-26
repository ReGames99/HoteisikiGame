using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�������ރX�N���v�g�I�I�I�I
public class FrameCollider : MonoBehaviour
{
    [SerializeField] GameObject parentObject;

    bool pullableFlag = false;

    private void Start()
    {
        if(parentObject != null)
        {
            parentObject.transform.position = transform.position;
        }

        
    }

    private void Update()
    {
        if(pullableFlag == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                parentObject.transform.position = gameObject.transform.position;
            }
                
        }
    }

    //�g�̃R���C�_�[�ɒP�Ƃ�NumberBall���ڐG������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.transform.parent.childCount == 1)
        {
            parentObject = collision.transform.parent.gameObject;
            
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("a");
        if (collision.transform.parent.childCount == 1)
        {
            Debug.Log("b");
            //�z�����߂�悤�ɂ���
            if (Mathf.Abs(collision.transform.position.x - transform.position.x) < gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2)
            {
                Debug.Log("c");
                pullableFlag = true;
            }
            else
            {
                pullableFlag = false;
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.transform.parent.childCount == 1)
        {
            pullableFlag = false;
            parentObject = null;
            //parentObject�����ꂽ��
            if (collision.gameObject == parentObject)
            {
                //�ƂȂ�̂�����炵�Ă���
            }


        }
    }


}
