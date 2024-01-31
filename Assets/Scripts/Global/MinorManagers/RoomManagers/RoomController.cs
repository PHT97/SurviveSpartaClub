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
            GameManager.instance.SettingTime();
            GameManager.instance.UpdateTimeUI();
        }
        else if (i == 2)
        {
            //startPoint.currentMapName = NextRoomStandard;
            SceneManager.LoadScene($"{NextRoomStandard}");
            GameManager.instance.SettingTime();
            GameManager.instance.UpdateTimeUI();
        }
        else if (i == 3)
        {
            Debug.Log("BasicRoom");
            //startPoint.currentMapName = NextRoomBasic;
            SceneManager.LoadScene($"{NextRoomBasic}");
            GameManager.instance.SettingTime();
            GameManager.instance.UpdateTimeUI();
        }
    }

}
