using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDiv : MonoBehaviour
{
    bool onMouseFlag = false;

    [SerializeField] GameObject instantiateObject;

    private void OnMouseUp()
    {

        if (onMouseFlag == true)
        {
            //•ª”‚Ìü‚ğˆø‚­
            Instantiate(instantiateObject, new Vector3(gameObject.transform.position.x , gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity, gameObject.transform.parent);
        }
    }

    private void OnMouseEnter()
    {
        onMouseFlag = true;
    }

    private void OnMouseExit()
    {
        onMouseFlag = false;
    }
}
