﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    BoardManager boardManager;

    public bool playerTurn = true;
    public bool enemiesMove = false;

    public int level = 0;
    private bool doingSetup;
    public Text levelText;
    public GameObject levelImage;
    public GameObject returnMenu;

    public int food = 100;
    public float attack = 1;
    public bool flag = false;
    public List<int> treNum = new List<int>();

    public int cnt = 0;
    public bool[] isHave = new bool[9]
    {
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false
    };

    private List<Enemy> enemies;

    public string Tresure = "Tresure";

    void Start()
    {
    }

    private void Awake()
    {
        Debug.Log("Awake");
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);            //シーンをまたいだ後でもそのシーンを破壊しない

        enemies = new List<Enemy>();

        boardManager = GetComponent<BoardManager>();
        SceneManager.sceneLoaded += OnSceneLoaded;

        //InitGame();

    }


    //スタートした時一度だけ読み込める（タイミング指定可能
    /*[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static public void Call()
    {
        Debug.Log("aaaaaaaaaaaaaaa");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }*/

    static private void OnSceneLoaded(Scene next, LoadSceneMode a)
    {
        instance.InitGame();
        
    }

    public void InitGame()
    {
        doingSetup = true;
        returnMenu = GameObject.Find("ReturnMenu");
        returnMenu.SetActive(false);
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Floor:" + instance.level + "   Attack:" + GameManager.instance.attack;
        levelImage.SetActive(true);
        Invoke("HideLevelImage", 1f);                                  //指定の関数を指定の秒数後に行う

        enemies.Clear();

        boardManager.SetUpScene();
        
    }

    public void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn || enemiesMove || doingSetup)
            return;
        StartCoroutine(MoveEnemies());
    }

    public void AddEnemy(Enemy script)
    {
        enemies.Add(script);
    }

    public void DestroyEnemy(Enemy script)
    {
        enemies.Remove(script);
    }

    IEnumerator MoveEnemies()
    {
        enemiesMove = true;
        
        if(enemies.Count == 0)
            yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].MoveEnemy();
            yield return new WaitForSeconds(0.1f);   //指定の秒数後にまた処理を始める
        }

        playerTurn = true;
        enemiesMove = false;
    }

    public void GameOver()
    {
        levelText.text = "Game Over";
        Debug.Log("Gamaover");
        levelImage.SetActive(true);
        returnMenu.SetActive(true);
        flag = false;
        //Destroy(gameObject);

    }

    public void Complete()
    {
        levelText.text = "Congratulation!";
        levelImage.SetActive(true);
        returnMenu.SetActive(true);
        flag = false;
        //Destroy(gameObject);
    }

}
