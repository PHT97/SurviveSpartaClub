using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraManager : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public float offsetX = 0.0f;            // ī�޶��� x��ǥ
    public float offsetY = 1.2f;           // ī�޶��� y��ǥ
    public float offsetZ = 0.0f;          // ī�޶��� z��ǥ

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
