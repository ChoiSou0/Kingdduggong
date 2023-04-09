using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public GameObject ME;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Mefalse());
    }
    IEnumerator Mefalse()
    {
        yield return new WaitForSeconds(3);
        ME.SetActive(false);
    }
}
