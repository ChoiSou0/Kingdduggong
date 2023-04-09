using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScale : MonoBehaviour
{
    public void ArrowScaleSizeControl(float dist) 
    {
        gameObject.transform.localScale = new Vector3(1, 1+0.3f* dist, 1);
    }

    public void ArrowScaleReset()
    {
        gameObject.transform.localScale=new Vector3(1, 1, 1);
    }
}
