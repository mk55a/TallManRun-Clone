using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToFinish : Jump
{
    
    public override void OnEnterArea(Player player)
    {
        player.GetComponent<Rigidbody>().AddForce(0, yJumpForce, zJumpForce, ForceMode.Impulse);
        Debug.Log("Player is now on finish area");
        Time.timeScale = 0.5f;
        player.EnableBossAttack();
    }
}
