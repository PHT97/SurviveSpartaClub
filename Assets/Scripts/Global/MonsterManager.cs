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

        //씬 로드되자마자 몬스터개수 들어감
        GameManager.instance.enemiesCount = monsters.Count;
    }
}
