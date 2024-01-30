using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraManager : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public float offsetX = 0.0f;            // 카메라의 x좌표
    public float offsetY = 1.2f;           // 카메라의 y좌표
    public float offsetZ = 0.0f;          // 카메라의 z좌표

    private GameObject player;
    Vector3 TargetPos;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        TargetPos = new Vector3(
            player.transform.position.x + offsetX,
            player.transform.position.y + offsetY,
            player.transform.position.z + offsetZ
            );
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * cameraSpeed);
    }
}
