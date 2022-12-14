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

    public void StartBt()
    {
        Title.SetActive(false);
    }
    public void CltBtOn()
    {
        Clt.SetActive(true);
    }

    public void MenuBtOn()
    {
        Menu.SetActive(true);
    }
    public void CltBtOut()
    {
        Clt.SetActive(false);
    }

    public void MenuBtOut()
    {
        Menu.SetActive(false);
    }

    void GameEnd()//
    {
        Result.SetActive(true);
    }
    public void Back()
    {
        Result.SetActive(false);
        Title.SetActive(true);
    }

    public void LvSelOn()
    {
        LvSel.SetActive(true);
        CltBt.SetActive(false);
    }

    public void LvSelOut()
    {
        LvSel.SetActive(false);
        CltBt.SetActive(true);
    }
}
