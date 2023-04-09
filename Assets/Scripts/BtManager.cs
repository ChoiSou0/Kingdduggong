using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtManager : MonoBehaviour
{
    public GameObject Clt;
    public GameObject Menu;
    public GameObject Title;
    public GameObject Result;
    public GameObject LvSel;
    public GameObject CltBt;
    public GameObject Loading;
    public GameObject OutOutBT;

    [Header("맵1 스폰 위치")]
    public Transform Sp1;
    public Transform Sp2;
    public Transform Sp3;
    public Transform Sp4;

    [Header("맵2 스폰 위치")]
    public Transform Sp5;
    public Transform Sp6;
    public Transform Sp7;
    public Transform Sp8;

    [Header("플레이어")]
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    public AudioSource BTSound;

    public int mapnum;
    public static bool nolace;
    public static bool nolace2;

    private void Start()
    {
        mapnum = 1;

    }
    public void Update()
    {
        if(Drag.win == true)
        {
            Title.SetActive(true);
            Result.SetActive(true);
            Drag.P_num = 0;
            Drag.win = false;
            Drag.gool = false;
        }

        if (Title.activeSelf == true)
        {
            nolace = true;
        }

        if (Title.activeSelf == false)
        {
            nolace = false;
        }

        if(Menu.activeSelf == true)
        {
            nolace2 = true;
        }

        if (Menu.activeSelf == false)
        {
            nolace2 = false;
        }

    }
    public void StartBt()
    {
        BTSound.Play();
        Loading.SetActive(true);
        StartCoroutine(Stop());
        if (mapnum == 1)
        {
            P1.transform.position = Sp1.position;
            P2.transform.position = Sp2.position;
            P3.transform.position = Sp3.position;
            P4.transform.position = Sp4.position;
        }

        if (mapnum == 2)
        {
            P1.transform.position = Sp5.position;
            P2.transform.position = Sp6.position;
            P3.transform.position = Sp7.position;
            P4.transform.position = Sp8.position;
        }
    }
    public void CltBtOn()
    {
        BTSound.Play();
        Clt.SetActive(true);
    }

    public void MenuBtOn()
    {
        BTSound.Play();
        Menu.SetActive(true);
        if (Title.activeSelf == true)
        {
            OutOutBT.SetActive(false);
        }

        if (Title.activeSelf == false)
        {
            OutOutBT.SetActive(true);
        }
    }

    public void CltBtOut()
    {
        BTSound.Play();
        Clt.SetActive(false);
    }

    public void MenuBtOut()
    {
        BTSound.Play();
        Menu.SetActive(false);

    }

    void GameEnd()//
    {
        BTSound.Play();
        Result.SetActive(true);
    }

    public void Back()
    {
        BTSound.Play();
        Result.SetActive(false);
    }

    public void LvSelOn()
    {
        BTSound.Play();
        LvSel.SetActive(true);
        CltBt.SetActive(false);
    }

    public void LvSelOut()
    {
        BTSound.Play();
        LvSel.SetActive(false);
        CltBt.SetActive(true);
    }

    public void Track1on()
    {
        BTSound.Play();
        mapnum = 1;
    }

    public void Track2on()
    {
        BTSound.Play();
        mapnum = 2;
    }

    public void OutOutOn()
    {
        BTSound.Play();
        Title.SetActive(true);
        Menu.SetActive(false);
        Drag.P_num = 0;
        Drag.win = false;
        Drag.gool = false;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(3);
        Title.SetActive(false);
        nolace = false;
    }
}
