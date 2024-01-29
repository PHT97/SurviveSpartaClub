using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint; // �̵��Ǿ�� ���̸��� üũ�ϱ� ���� ����
    private CameraManager Camera; // �ڿ������� ī�޶� �̵��� ���� ������ ī�޶� ����

    public string currentMapName;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Camera = FindObjectOfType<CameraManager>(); // ī�޶� ������ ī�޶� ��ü�� �Ҵ�
        if (startPoint == currentMapName)
        {
            player.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.transform.position.z);
            // ĳ���� �̵�
            player.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

