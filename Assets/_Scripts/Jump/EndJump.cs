using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndJump : Jump
{
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnEnterArea(other.gameObject.GetComponent<Player>());
        }
    }*/
    public override void OnEnterArea(Player player)
    {
        player.EnablePlayerRun();
    }
}
