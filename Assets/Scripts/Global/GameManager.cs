using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //DoorManager에서 클리어개수 받아옴.
    public int clearnum = 0;
    public Transform Player { get; private set; }
    [SerializeField] private string playerTag = "Player";

    private HealthSystem playerHealthSystem;

    [SerializeField] private TextMeshProUGUI DungeonTime;       //무적시간 해제 타이머
    [SerializeField] private TextMeshProUGUI ClearDungeonNum;   //클리어던전수
    [SerializeField] private TextMeshProUGUI HPNum;             //플레이어체력
    [SerializeField] private float time;                        //무적시간이 얼마나 남았는지 보여주는 시간


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
            Debug.Log("던전 클리어");
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
        }
        else
        {
            time = 0f;
        }
        DungeonTime.text = time.ToString("N2");
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
        Player.GetComponent<PlayerInput>().enabled = true;
        IsPlaying = false;
        Time.timeScale = 1f;
        playerHealthSystem.ChangeHealth(playerHealthSystem.MaxHealth);   //플레이어의 체력을 초기화
        UpdateHealthUI();
        SettingTime();
        UpdateTimeUI();
        Player.transform.position = Vector3.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //buildIndex
        gameOverUI.SetActive(false);            //게임오버UI가리기
        IsPlaying = true;                       //게임 재시작
    }
    public void ExitGame()
    {

        Destroy(gameObject);
        Destroy(PlayerObject);
        Destroy(MainCamera);
        Player.GetComponent<PlayerInput>().enabled = true;
        DoorManager.dungeonNum = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
    
}