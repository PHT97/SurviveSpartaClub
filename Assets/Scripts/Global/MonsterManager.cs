using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    private List<GameObject> monsters;


    // Start is called before the first frame update
    void Start()
    {
        monsters = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        //�� �ε���ڸ��� ���Ͱ��� ��
        GameManager.instance.enemiesCount = monsters.Count;
    }
}
