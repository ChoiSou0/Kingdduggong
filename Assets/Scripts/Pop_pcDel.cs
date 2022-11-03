using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop_pcDel : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(Pop_PcDel()); 
    }
    IEnumerator Pop_PcDel()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
