using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour
{
    public enum RoomType
    {
        RoomTypeChallenge,
        RoomTypeStandard,
        RoomTypeBasic,
        RoomTypeNone
    }
    [SerializeField] RoomType type;
    [SerializeField] string NextRoomChallenge;
    [SerializeField] string NextRoomStandard;
    [SerializeField] string NextRoomBasic;


    private void onDoorEnter(int i)
    {
        if (i == 1)
        {
            //startPoint.currentMapName = NextRoomChallenge;
            SceneManager.LoadScene($"{NextRoomChallenge}");
        }
        else if (i == 2)
        {
            //startPoint.currentMapName = NextRoomStandard;
            SceneManager.LoadScene($"{NextRoomStandard}");
        }
        else if (i == 3)
        {
            Debug.Log("BasicRoom");
            //startPoint.currentMapName = NextRoomBasic;
            SceneManager.LoadScene($"{NextRoomBasic}");
        }
    }

}



    //[SerializeField]
    //public enum RoomType
    //{
    //    challenge, standard, basic, starting
    //} // roomA is 0, roomB is 1 etc.

    //[SerializeField] RoomType roomtype;

    //[SerializeField] GameObject nextChallenge1;
    //[SerializeField] GameObject nextChallenge2;
    //[SerializeField] GameObject nextChallenge3;

    //[SerializeField] GameObject nextStandard1;
    //[SerializeField] GameObject nextStandard2;
    //[SerializeField] GameObject nextStandard3;

    //[SerializeField] GameObject nextBasic1;
    //[SerializeField] GameObject nextBasic2;
    //[SerializeField] GameObject nextBasic3;

    //public void openNextRoom()
    //{
    //    float nextRoom = Random.Range(0, 3);
    //    if (roomtype == RoomType.challenge)
    //    {
    //        if (nextRoom > 2)
    //            createNewRoom(nextChallenge1);
    //        else if (nextRoom > 1)
    //            createNewRoom(nextChallenge2);
    //        else
    //            createNewRoom(nextChallenge3);
    //    }
    //    else if (roomtype == RoomType.standard)
    //    {
    //        if (nextRoom > 2)
    //            createNewRoom(nextStandard1);
    //        else if (nextRoom > 1)
    //            createNewRoom(nextStandard2);
    //        else
    //            createNewRoom(nextStandard3);
    //    }
    //    else if (roomtype == RoomType.basic)
    //    {
    //        if (nextRoom > 2)
    //            createNewRoom(nextBasic1);
    //        else if (nextRoom > 1)
    //            createNewRoom(nextBasic2);
    //        else
    //            createNewRoom(nextBasic3);
    //    }
    //    else if (roomtype == RoomType.starting)
    //    {

    //    }
    //}
    //void createNewRoom(GameObject roomToCreate)
    //{
    //    Object.Instantiate(roomToCreate);
    //}

    //public void playerMovetoSpawn()
    //{

    //}






//    //needs to not parent doors to room because this causes issues with animations
//    //wDoor eDoor etc basically need to have no parent so they will animate in place?

//    public enum RoomType
//    {
//        RoomTypeChallenge,
//        RoomTypeStandard,
//        RoomTypeBasic,
//        RoomTypeNone
//    }

//    [SerializeField] RoomType roomType;
//    [SerializeField] GameObject CDoor;
//    [SerializeField] GameObject SDoor;
//    [SerializeField] GameObject BDoor;
//    void OnMouseDown()
//    {
//        RoomType randomRoomType = (RoomType)Random.Range(0, 3);
//        Debug.Log("random roomtype: " + randomRoomType);

//        Vector3 roomCheck = placeRoom(gameObject.transform.parent.gameObject);
//        Debug.Log("checking for existence of room named: " + roomCheck);
//        if (roomCheck != new Vector3(0, 0, 0)) //check for the zero vector return value which indicates the room exists
//        {
//            //create the room
//            GameObject theNewRoom = createRoom(placeRoom(gameObject.transform.parent.gameObject), randomRoomType);
//            Debug.Log(theNewRoom.GetComponent<Collider>().bounds.size);

//        }
//        else
//        {
//            Debug.Log("did not create new room");
//        }
//        //open the doors

//    } //onmousedown

//    //HELPER FUNCTIONS
//    //placeRandom returns a random Vector3 offset for use in placing objects at random locations within rooms
//    //specify any coordinate to override
//    public Vector3 placeRandom(int x = 0, int y = 0, int z = 0)
//    {
//        if (x == 0) { x = Random.Range(-11, 11); }
//        if (z == 0) { z = Random.Range(-11, 11); }
//        return new Vector3(x, y, z);
//    }


//    public bool randomBool()
//    {
//        int randomNumber = Random.Range(0, 100);
//        return (randomNumber % 2 == 0) ? true : false;
//    }

//    //placeRoom returns a new room location based on the name of the door parent passed to it (named in scene wDoor, eDoor, etc...)

//    //change placeroom to simply use an offset of the door position instead of the room parent position

//    //doors need to not be children of rooms which probably means placing them using world coordinates which they might be already

//    //  public Vector3 placeRoom()
//    //  {
//    //    Vector3 doorLocation = gameObject.transform.position;

//    //  }

//    public Vector3 placeRoom(GameObject doorParent)
//    {

//        //Debug.Log("PlaceRoom called and forward is: " + gameObject.transform.forward);

//        Debug.Log("PlaceRoom called and doorParent.name is: " + doorParent.name);
//        //get the name of the parent of this door
//        string thisName = doorParent.name;

//        //position of ultimate parent object for placement of the next
//        GameObject nextRoomParent = doorParent.transform.root.gameObject;
//        Debug.Log("Next room parent is: " + doorParent.transform.root.gameObject);

//        //initialize a possible position for the new room
//        Vector3 nextRoomPosition = nextRoomParent.transform.position;
//        Debug.Log("(this room position) nextRoomPosition: " + nextRoomPosition);

//        //decide an appropriate new position for the next room
//        switch (thisName)
//        {
//            case "CDoor":
//                nextRoomPosition += new Vector3(0, 15, 0);
//                Debug.Log(nextRoomPosition);
//                break;
//            case "SDoor":
//                nextRoomPosition += new Vector3(0, 15, 0);
//                Debug.Log(nextRoomPosition);
//                break;
//            case "BDoor":
//                nextRoomPosition += new Vector3(0, 15, 0);
//                Debug.Log(nextRoomPosition);
//                break;
//            default:
//                break;
//        }

//        Debug.Log("PlaceRoom result: " + nextRoomPosition);

//        //construct what the new name would be if this room were created
//        string nextRoomName = nextRoomPosition.ToString("F3");

//        if (GameObject.Find(nextRoomName) != null)
//        {
//            return new Vector3(0, 0, 0); //this result needs to be checked for by the caller and might need to be 999 999 999
//        }
//        else
//        {
//            return nextRoomPosition;
//        }
//    }

//    public GameObject createRoom(Vector3 pos, RoomType type)
//    {

//        GameObject obj = new GameObject();
//                switch (type)
//        {
//            case RoomType.RoomTypeChallenge:
//                obj = createRoomChallenge(pos);
//                break;
//            case RoomType.RoomTypeStandard:
//                obj = createRoomStandard(pos);
//                break;
//            case RoomType.RoomTypeBasic:
//                obj = createRoomBasic(pos);
//                break;
//            default:
//                break;
//        }
//        return obj;
//    }


//    private GameObject createRoomChallenge(Vector3 pos)
//    {
//        Vector3 nextRoomPosition = pos;
//        string newRoomName = nextRoomPosition.ToString("F3");
//        Debug.Log("challenge: " + nextRoomPosition);
//        GameObject nextRoom = (GameObject)Instantiate(Resources.Load("Challenge"));
//        nextRoom.transform.position = nextRoomPosition;
//        nextRoom.name = newRoomName;

//        return nextRoom;
//    }

//    private GameObject createRoomStandard(Vector3 pos)
//    {
//        Vector3 nextRoomPosition = pos;
//        string newRoomName = nextRoomPosition.ToString("F3");
//        Debug.Log("standard: " + pos);
//        GameObject nextRoom = (GameObject)Instantiate(Resources.Load("Standard"));
//        nextRoom.transform.position = nextRoomPosition;
//        nextRoom.name = newRoomName;

//        return nextRoom;
//    }

//    private GameObject createRoomBasic(Vector3 pos)
//    {
//        Vector3 nextRoomPosition = pos;
//        string newRoomName = nextRoomPosition.ToString("F3");
//        Debug.Log("baisc" + pos);
//        GameObject nextRoom = (GameObject)Instantiate(Resources.Load("Baisc"));
//        nextRoom.transform.position = nextRoomPosition;
//        nextRoom.name = newRoomName;

//        return nextRoom;
//    }
//}

