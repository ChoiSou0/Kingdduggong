using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtl : MonoBehaviour
{
    [SerializeField] Vector3 _delta;
    [SerializeField] GameObject[] _player;

    void LateUpdate()
    {

        transform.position = _player[TurnManager.P_num].transform.position + _delta;
        transform.LookAt(_player[TurnManager.P_num].transform);
    }
}
