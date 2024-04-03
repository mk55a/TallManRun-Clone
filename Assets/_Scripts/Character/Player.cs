using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private GameObject playerBody;
    private Animator animator;
    private CharacterMovement movement;
    private TouchManager playerInput; 
    private Body body;

    public bool startRun = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        playerBody = this.gameObject;
        animator = GetComponent<Animator>();
        movement = GetComponent<CharacterMovement>();
        body = GetComponent<Body>();
        playerInput = GetComponent<TouchManager>();
    }

    private void Start()
    {

    }
    private void Update()
    {
        if (IsDead())
        {
            
            GameManager.Instance.SetGameState(GameState.LevelFailed);
        }
    }

    public CharacterMovement GetMovement()
    {
        return movement;
    }

    public GameObject GetPlayerBody()
    {
        return playerBody;
    }

    public Body GetBody()
    {
        return body; 
    }

    private bool IsDead()
    {
        if (playerBody.transform.position.y < -5f || !body.IsBodyThere())
        {
            if (!body.IsBodyThere())
            {
                body.Death();
            }
            //Debug.Log("IS DEAD");
            return true;
        }
        else
        {
            return false;
        }
    }

    
    public void EnablePlayerRun()
    {
        startRun = true;
        movement.canRun = true;
        animator.SetBool("Run", true);
    }
    public void DisablePlayerRun()
    {
        PlayerIdle();
        startRun = false;
        movement.canRun = false;
    }
    public void PlayerIdle()
    {
        animator.SetBool("Run", false);
        animator.SetBool("BossAttack", false);
    }
    public void EnableBossAttack()
    {
        animator.SetBool("BossAttack", true);
        playerInput.DisableTouch();
    }

}
