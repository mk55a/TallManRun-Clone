using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; 

    [SerializeField]
    private TextMeshProUGUI coinScoreText;
    [HideInInspector] public static int coinScore;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        coinScoreText.text = coinScore.ToString();
    }

    public void UpdateScore(int value)
    {
        coinScore += value;
        coinScoreText.text = coinScore.ToString();
    }

}
