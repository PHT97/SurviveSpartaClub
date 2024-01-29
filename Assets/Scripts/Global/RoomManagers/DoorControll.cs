using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DoorManager;

public class DoorControll : MonoBehaviour
{

    [SerializeField] private GameObject OpenedDoor;
    [SerializeField] private GameObject ClosedDoor;



    //private RoomController roomController;

    //public GameManager gameManager;
    void Start()
    {
        OnRoomClear();
    }

    void OnRoomClear()
    {
        //if (gameManager.EnemyCount == 0)
        //{
        //    Destroy(ClosedDoor);
        //    OpenedDoor.SetActive(true);
        //}
    }
}
