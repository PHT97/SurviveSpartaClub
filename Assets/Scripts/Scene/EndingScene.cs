using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : MonoBehaviour
{
    private GameObject GameManagerObject;
    private GameObject GameCamera;
    private GameObject PlayerObject;
    void Start()
    {
        GameManagerObject = GameObject.Find("GameManager");
        GameCamera = GameObject.Find("Main Camera");
        PlayerObject = GameObject.Find("Player");
        Destroy(GameManagerObject);
        Destroy(GameCamera);
        Destroy(PlayerObject);
    }
}


