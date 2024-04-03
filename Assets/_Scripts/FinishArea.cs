using UnityEngine;

public class FinishArea : MonoBehaviour, IPlatform
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnEnterArea(other.gameObject.GetComponent<Player>());
        }
    }

    public void OnEnterArea(Player player )
    {
        Debug.Log("Player is now on finish area");
        Time.timeScale = 0.5f;
        player.EnableBossAttack();
        //GameManager.Instance.SetGameState(GameState.LevelComplete);
        
    }
}
