using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //DoorManager���� Ŭ����� �޾ƿ�.
    public int clearnum = 0;
    public Transform Player { get; private set; }
    [SerializeField] private string playerTag = "Player";

    private HealthSystem playerHealthSystem;

    [SerializeField] private TextMeshProUGUI DungeonTime;       //�����ð� ���� Ÿ�̸�
    [SerializeField] private TextMeshProUGUI ClearDungeonNum;   //Ŭ���������
    [SerializeField] private TextMeshProUGUI HPNum;             //�÷��̾�ü��
    [SerializeField] private float time;                        //�����ð��� �󸶳� ���Ҵ��� �����ִ� �ð�


    public GameObject gameOverUI;
    public GameObject Canvas;

    //
    public GameObject MainCamera;
    public GameObject PlayerObject;
    public Action OnEnemyDeadEvent;
    //
    public int enemiesCount;
    public bool isClear = false;

    public bool IsPlaying = true;
    private void Start()
    {
        HPNum.text = playerHealthSystem.MaxHealth.ToString();
        time = 0f;
        OnEnemyDeadEvent += EnemyDead;
    }

    private void Awake()
    {
        clearnum = DoorManager.dungeonNum;
        instance = this;
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
        playerHealthSystem = Player.GetComponent<HealthSystem>();
        playerHealthSystem.OnDamage += UpdateHealthUI;
        playerHealthSystem.OnDeath += GameOver;

        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        UpdateTimeUI();
    }

    public void CallEnemyDeadEvent()
    {
        OnEnemyDeadEvent?.Invoke();
    }

    public void EnemyDead()
    {
        enemiesCount--;
        if (enemiesCount <= 0)
        {
            Debug.Log("���� Ŭ����");
        }
    }

    private void UpdateHealthUI()
    {
        HPNum.text = playerHealthSystem.CurrentHealth.ToString();
    }

    public void UpdateTimeUI()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
            DungeonTime.text = time.ToString("N2");
        }
        else
        {
            time = 0f;
        }
    }

    public void SettingTime()
    {
        time = 10f;
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void UpdateDungeonNum(int num)
    {
        ClearDungeonNum.text = num.ToString();
    }

    public void RestartGame()
    {
        IsPlaying = false;
        Time.timeScale = 1f;
        playerHealthSystem.ChangeHealth(playerHealthSystem.MaxHealth);   //�÷��̾��� ü���� �ʱ�ȭ
        UpdateHealthUI();
        SettingTime();
        UpdateTimeUI();
        Player.transform.position = Vector3.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //buildIndex
        gameOverUI.SetActive(false);            //���ӿ���UI������
        IsPlaying = true;                       //���� �����
    }
    public void ExitGame()
    {
        Destroy(gameObject);
        Destroy(PlayerObject);
        Destroy(MainCamera);
        DoorManager.dungeonNum = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
    
}