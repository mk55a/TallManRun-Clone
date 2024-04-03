using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level", menuName = "ScriptableObjects/Info", order = 1)]
public class LevelInfo : ScriptableObject
{
    public string levelNumber;

    public GameObject levelPrefab; 
}
