using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    Vector3 initialPos;


    private void Start()
    {
        initialPos = transform.position;
    }

    void OnMouseDrag()
    {
        //�ȉ��l�s�̓h���b�O�������ɃI�u�W�F�N�g�𓮂����R�[�h
        Vector3 thisPosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
        worldPosition.z = initialPos.z;
        this.transform.position = worldPosition;
    }


    
}
