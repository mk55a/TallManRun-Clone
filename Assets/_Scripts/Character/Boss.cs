using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private float waitTime = 5.0f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            OnCollisionWithPlayer(player);
        }
    }

    public override void OnCollisionWithPlayer(Player player)
    {
        player.DisablePlayerRun();
        StartCoroutine(Death());
    }
    IEnumerator Death()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(waitTime);
        GameManager.Instance.SetGameState(GameState.LevelComplete);
        gameObject.SetActive(false);

    }
}
