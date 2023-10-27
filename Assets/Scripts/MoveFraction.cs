using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFraction : MonoBehaviour
{
    GameObject l1;
    GameObject l2;
    GameObject l3;
    GameObject r1;
    GameObject r2;
    GameObject r3;


    void Start()
    {
        l1 = GameObject.Find("left1");
        l2 = GameObject.Find("left2");
        l3 = GameObject.Find("left3");
        r1 = GameObject.Find("right1");
        r2 = GameObject.Find("right2");
        r3 = GameObject.Find("right3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MoveRight()
    {
        System.Diagnostics.StackFrame caller = new System.Diagnostics.StackFrame(1);

        //if (caller.GetMethod().ReflectedType)
        r2.GetComponent<FrameCollider>().parentObject.transform.position = r3.transform.position;
    }

    public void MoveLeft()
    {
        r3.GetComponent<FrameCollider>().parentObject.transform.position = r2.transform.position;
    }
}
