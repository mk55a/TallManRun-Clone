
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject preLevelUI;
    [SerializeField]
    private TextMeshProUGUI levelText;
    [SerializeField]
    private GameObject levelCompleteUI;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private GameObject levelFailedUI;
    [SerializeField]
    private Button retryButton;

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += HandleGameStateChanged;
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= HandleGameStateChanged;
    }
    private void Awake()
    {
        //GameManager.Instance.uiHandler = this; 
        
    }
    public void EnablePreLevelUI()
    {
        SetActiveUI(preLevelUI, true);
    }
    public void DisablePreLevelUI()
    {
        SetActiveUI(preLevelUI, false);
    }

    public void EnableLevelCompleteUI()
    {
        AddButtonListener(continueButton, GameManager.Instance.NextLevel);
        SetActiveUI(levelCompleteUI, true);

    }

    public void DisableLevelCompleteUI()
    {
        RemoveButtonListener(continueButton, GameManager.Instance.NextLevel);
        SetActiveUI(levelCompleteUI, false);
    }

    public void EnableLevelFailedUI()
    {
        AddButtonListener(retryButton, GameManager.Instance.ReloadLevel);
        SetActiveUI(levelFailedUI, true);
    }

    public void DisableLevelFailedUI()
    {
        RemoveButtonListener(retryButton, GameManager.Instance.ReloadLevel);
        SetActiveUI(levelFailedUI, false);
    }

    private void SetActiveUI(GameObject uiObject, bool isActive)
    {
        preLevelUI.SetActive(uiObject == preLevelUI && isActive);
        levelCompleteUI.SetActive(uiObject == levelCompleteUI && isActive);
        levelFailedUI.SetActive(uiObject == levelFailedUI && isActive);
    }

    private void AddButtonListener(Button button, UnityEngine.Events.UnityAction action)
    {
        button.onClick.AddListener(action);
    }

    private void RemoveButtonListener(Button button, UnityEngine.Events.UnityAction action)
    {
        button.onClick.RemoveListener(action);
    }

    private void HandleGameStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.PreLevel:
                HandlePreLevelState();
                break;
            case GameState.InProgress:
                HandleInProgressState();
                break;
            case GameState.LevelComplete:
                HandleLevelCompleteState();
                break;
            case GameState.LevelFailed:
                HandleLevelFailedState();
                break;
            // Add more cases as needed
            default:
                Debug.LogWarning("Unhandled game state: " + newState);
                break;
        }
    }

    private void HandleLevelFailedState()
    {
        EnableLevelFailedUI();
    }

    private void HandleLevelCompleteState()
    {
        EnableLevelCompleteUI();
    }

    private void HandleInProgressState()
    {
        DisablePreLevelUI();
    }

    private void HandlePreLevelState()
    {
        EnablePreLevelUI();
    
    }
}
