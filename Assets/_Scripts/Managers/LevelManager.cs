using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    /*private static LevelManager Instance;*/

    [SerializeField]
    public GameObject startingPoint;
    
    /*public static LevelManager instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<LevelManager>();
                if (Instance == null)
                {
                    GameObject go = new GameObject("LevelManager");
                    Instance = go.AddComponent<LevelManager>();
                }
            }
            return Instance;
        }
    }*/

    private void Awake()
    {
        /*if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }*/

        GameManager.Instance.levelManager = this;
    }
    
}
