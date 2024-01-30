using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public enum DoorType
    {
        challenge, standard, basic
    }

    public DoorType doortype;
    private GameObject player;
    public RoomController roomController;
    public static int dungeonNum = 0;
    //private float Offset = 8f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = Vector3.zero;
            switch (doortype)
            {
                case DoorType.challenge:
                    Debug.Log("ç������");
                    roomController.SendMessage("onDoorEnter", 1);
                    GameManager.instance.UpdateDungeonNum(dungeonNum);
                    dungeonNum += 1;
                    break;
                case DoorType.standard:
                    Debug.Log("���Ĵٵ��");
                    roomController.SendMessage("onDoorEnter", 2);
                    GameManager.instance.UpdateDungeonNum(dungeonNum);
                    dungeonNum += 1;
                    break;
                case DoorType.basic:
                    Debug.Log("��������");
                    roomController.SendMessage("onDoorEnter", 3);
                    GameManager.instance.UpdateDungeonNum(dungeonNum);
                    dungeonNum += 1;
                    //Debug.Log("���� Ŭ���� ��ȣ" + dungeonNum);
                    break;
            }
        }
    }
}