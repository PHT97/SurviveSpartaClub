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
                    Debug.Log("Ã§¸°Áö·ë");
                    roomController.SendMessage("onDoorEnter", 1);
                    break;
                case DoorType.standard:
                    Debug.Log("½ºÅÄ´Ùµå·ë");
                    roomController.SendMessage("onDoorEnter", 2);
                    break;
                case DoorType.basic:
                    Debug.Log("º£ÀÌÁ÷·ë");
                    roomController.SendMessage("onDoorEnter", 3);
                    break;
            }
        }
    }
}