using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    public bool canRun;
    private void Awake()
    {
       
    }
    private void Update()
    {
        if (canRun)
        {
            MoveForward();
        }
        
    }
    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }
}
