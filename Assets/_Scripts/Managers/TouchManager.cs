using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeedSide;
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private bool isMoving = false;

    private float maxXPosition = 4f;
    private float minXPosition =-4f; 

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions.FindAction("TouchScreen");
        touchPositionAction = playerInput.actions.FindAction("TouchPosition");

    }

    private void OnEnable()
    {
        EnableTouch();
    }

    private void OnDisable()
    {
        DisableTouch();
    }
    
    public void EnableTouch()
    {
        touchPressAction.performed += TouchPressed;
        touchPressAction.canceled += TouchCancelled;
    }

    public void DisableTouch()
    {
        touchPressAction.performed -= TouchPressed;
        touchPressAction.canceled -= TouchCancelled;
    }
    
    private void TouchPressed(InputAction.CallbackContext context)
    {
        if(GameManager.Instance.GetCurrentGameState() == GameState.PreLevel)
        {
            GameManager.Instance.SetGameState(GameState.InProgress);
        }
        else
        {
            isMoving = true;
        }
        

    }

    private void TouchCancelled(InputAction.CallbackContext context)
    {
        isMoving = false; 
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector2 position = touchPositionAction.ReadValue<Vector2>();
            Vector3 worldTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, Camera.main.nearClipPlane));
            float xPosition = Mathf.Clamp(worldTouchPosition.x, minXPosition, maxXPosition);

            player.transform.position = new Vector3(xPosition, player.transform.position.y, player.transform.position.z); 
            /*Vector3 playerNewPosition = new Vector3(xPosition, player.transform.position.y, player.transform.position.z);
            player.transform.Translate(playerNewPosition * Time.deltaTime * moveSpeedSide);*/
        }
    }
}
