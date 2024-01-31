using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControll : MonoBehaviour
{
    [SerializeField] private GameObject OpenedDoor;
    [SerializeField] private GameObject ClosedDoor;

    private void Start()
    {
        GameManager.instance.doorControll.Add(this);
    }

    public void OnRoomClear()
    {
        try
        {
            ClosedDoor.SetActive(false);
            OpenedDoor.SetActive(true);
        }
        catch(MissingReferenceException e) 
        {
            return;
        }
    }
}
