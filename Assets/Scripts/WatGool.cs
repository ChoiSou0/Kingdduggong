using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[AddComponentMenu("UI/DebugTextComponentName",10)]
public class WatGool : MonoBehaviour
{
    public static int winner;
    public TMP_Text win_name;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            win_name.text = "1) »¡°£»ö ½Â¸®!";
        }

        if (other.gameObject.name == "Player2")
        {
            win_name.text = "2) ÆÄ¶õ»ö ½Â¸®!";
        }

        if (other.gameObject.name == "Player3")
        {
            win_name.text = "3) ÃÊ·Ï»ö ½Â¸®!";
        }

        if (other.gameObject.name == "Player4")
        {
            win_name.text = "4) ³ë¶õ»ö ½Â¸®!";
        }
    }
}
