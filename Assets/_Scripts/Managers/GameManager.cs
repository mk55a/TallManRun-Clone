using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void GameStateChangedHandler(GameState newState);
    public static event GameStateChangedHandler OnGameStateChanged;

    private static GameManager instance;

    private GameState currentState=GameState.Default;
    //public UIHandler uiHandler;
    public LevelManager levelManager;
    public CameraMovement cameraMovement;
    
    private int currentLevel = 0;
    private GameObject currentLevelObject;

    [SerializeField]
    private List<GameObject> levelPrefabs;
    [SerializeField]
    private GameObject playerPrefab;

    private GameObject player; 
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    private void OnEnable()
    {
        levelManager = FindObjectOfType<LevelManager>();
        cameraMovement = FindObjectOfType<CameraMovement>();
    }

    private void Start()
    {
        
        Debug.LogWarning(GetCurrentGameState());
        SetGameState(GameState.PreLevel);
        
    }
    

    public GameState GetCurrentGameState()
    {
        return currentState;
    }

    public void SetGameState(GameState newState)
    {
        if (currentState == newState)
            return;

        // Handle state transition logic
        switch (newState)
        {
            case GameState.PreLevel:
                LoadLevel();
                break;
            case GameState.InProgress:
                StartLevel();
                break;
            case GameState.LevelComplete:
                CompleteLevel();
                break;
            case GameState.LevelFailed:
                FailLevel();
                break;
        }

        // Update the current state
        currentState = newState;

        OnGameStateChanged(newState);

        // Debug log for state changes
        Debug.Log("Game State: " + newState);
    }

    private void LoadPlayer()
    {
        if(player != null)
        {
            DestroyImmediate(player);
        }
        player = Instantiate(playerPrefab, levelManager.startingPoint.transform.position, Quaternion.identity);
        cameraMovement.SetTarget(player);
        Debug.LogError("Player loaded");
    }
    private void LoadLevel()
    {
        //uiHandler.EnablePreLevelUI();
        LoadLevelPrefab();
        Time.timeScale = 1;
    }
    
    private void StartLevel()
    {
        //uiHandler.DisablePreLevelUI();
        //preLevelUI.SetActive(false);
        Player.instance.EnablePlayerRun();
    }

    public void FailLevel()
    {
        // Show level failed UI
        //uiHandler.EnableLevelFailedUI();
        Time.timeScale = 0;
        // Add any other logic for level failure
    }

    public void CompleteLevel()
    {
        Time.timeScale = 0;
        // Show level complete UI
        //uiHandler.EnableLevelCompleteUI();
    }
    public void NextLevel()
    {
        currentLevel++;
        SetGameState(GameState.PreLevel);
    }
    public void LoadLevelPrefab()
    {
        if(currentLevelObject != null)
        {
            DestroyImmediate(currentLevelObject);
        }
        
        currentLevelObject = Instantiate(levelPrefabs[currentLevel]);
        Debug.LogError("Level Loaded");

        LoadPlayer();
    }

    public void ReloadLevel()
    {
        SetGameState(GameState.PreLevel);
    }
}

public enum PlayerState
{
    Run, 
    Boss,
    Death
}
public enum GameState
{
    Default,
    PreLevel, 
    InProgress,
    LevelComplete, 
    LevelFailed
}