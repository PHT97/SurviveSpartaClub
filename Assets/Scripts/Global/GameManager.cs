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
    //DoorManager에서 클리어개수 받아옴.
    public int clearnum = 0;
    public Transform Player { get; private set; }
    [SerializeField] private string playerTag = "Player";
    private HealthSystem playerHealthSystem;

    [SerializeField] private TextMeshProUGUI DungeonTime;       //무적시간 해제 타이머
    [SerializeField] private TextMeshProUGUI ClearDungeonNum;   //클리어던전수
    [SerializeField] private TextMeshProUGUI HPNum;             //플레이어체력
    [SerializeField] private float time;

    public GameObject gameOverUI;
    public GameObject Canvas;

    //
    public GameObject MainCamera;
    public GameObject PlayerObject;
    //
    public bool IsPlaying = true;
    private void Start()
    {
        HPNum.text = playerHealthSystem.MaxHealth.ToString();
        time = 5f;
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
        if (time > 0f)
        {
            time -= Time.deltaTime;
            DungeonTime.text = time.ToString("N2");
        }
        else
        {
            return;
        }
    }
    
    private void UpdateDungeonClear()
    {
        ClearDungeonNum.text = clearnum.ToString();
        Debug.Log(clearnum);
    }
    private void UpdateHealthUI()
    {
        HPNum.text = playerHealthSystem.CurrentHealth.ToString();
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
    }
    
    public void UpdateDungeonNum()
    {
        
    }
    public void RestartGame()
    {
        IsPlaying = false;
        playerHealthSystem.ChangeHealth(playerHealthSystem.MaxHealth);   //플레이어의 체력을 초기화
        UpdateHealthUI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //buildIndex
        gameOverUI.SetActive(false);            //게임오버UI가리기
        IsPlaying = true;                       //게임 재시작
    }
    public void ExitGame()
    {
        Destroy(gameObject);
        Destroy(PlayerObject);
        Destroy(MainCamera);
        SceneManager.LoadScene("StartScene");
    }
}