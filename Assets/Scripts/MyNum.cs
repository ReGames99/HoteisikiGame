using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyNum : MonoBehaviour
{
    string objectName;

    [SerializeField] public int myNum;

    public string variable;

    //true�����q
    [SerializeField] public bool motherOrChildFlag ;


    private void Start()
    {
        SetMyNumber();   
    }

 

    //�I�u�W�F�N�g������myNum�ƕ\������鐔����ݒ�
    public void  SetMyNumber()
    {
        objectName = gameObject.name;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = objectName;

        if (objectName.Contains("x"))
        {
            variable = "x";

            if (objectName == "+x")
            {
                myNum = 1;
            }
            else if (objectName == "-x")
            {
                myNum = -1;
            }
            else
            {
                string str = RemoveChar(objectName, 'x').ToString();
                myNum = int.Parse(str);
            }
        }
        else if (objectName.Contains("y"))
        {
            variable = "y";

            if (objectName == "+y")
            {
                myNum = 1;
            }
            else if (objectName == "-y")
            {
                myNum = -1;
            }
            else
            {
                string str = RemoveChar(objectName, 'y').ToString();
                myNum = int.Parse(str);
            }
        }
        else
        {
            variable = "n";
            myNum = int.Parse(objectName);
        }
    }


    //x,y�̏��O
    private string RemoveChar(string input, char charToRemove)
    {
        string result = string.Empty;
        foreach (char c in input)
        {
            if (c != charToRemove)
            {
                result += c;
            }
        }
        return result;
    }
}
