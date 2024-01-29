using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint; // 이동되어온 맵이름을 체크하기 위한 변수
    private CameraManager Camera; // 자연스러운 카메라 이동을 위해 가져온 카메라 변수

    public string currentMapName;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Camera = FindObjectOfType<CameraManager>(); // 카메라 변수에 카메라 객체를 할당
        if (startPoint == currentMapName)
        {
            player.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.transform.position.z);
            // 캐릭터 이동
            player.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

