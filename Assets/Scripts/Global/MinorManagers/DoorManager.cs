using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public enum DoorType
    {
        chanllenge, standard, basic
    }

    public DoorType doortype;
    private GameObject player;
    private float widthOffset = 2f;
    public GameObject doorEnterColider;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnger2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            switch(doortype)
            {
                case DoorType.chanllenge:
                    player.transform.position = new Vector2(transform.position.x, transform.position.y - widthOffset);
                    break;
                case DoorType.standard:
                    player.transform.position = new Vector2(transform.position.x, transform.position.y - widthOffset);
                    break;
                case DoorType.basic:
                    player.transform.position = new Vector2(transform.position.x, transform.position.y - widthOffset);
                    break;
            }
        }
    }
    //    private void OnTriggerEnter2D(Collider2D collision)
    //    {

    //        if (collision.tag == "Door")
    //        {
    //            Door temp = collision.GetComponent<Door>();
    //            if (temp.DoorType == 0)
    //            {
    //                this.transform.position = new Vector2(this.transform.position.x, -2.8f);
    //            }
    //            else if (temp.DoorType == 1)
    //            {
    //                this.transform.position = new Vector2(this.transform.position.x, 2.8f);
    //            }
    //            else if (temp.DoorType == 2)
    //            {
    //                this.transform.position = new Vector2(6.8f, this.transform.position.y);
    //            }
    //            else if (temp.DoorType == 3)
    //            {
    //                this.transform.position = new Vector2(-6.8f, this.transform.position.y);
    //            }
    //            Debug.Log(temp.gameObject.name);
    //            SceneManager.SendMessage("DoorKnock", temp.DoorType);
    //        }
    //    }
}
