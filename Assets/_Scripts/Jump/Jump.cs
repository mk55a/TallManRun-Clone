using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour, IPlatform
{
    [SerializeField]
    protected float yJumpForce;
    [SerializeField]
    protected float zJumpForce;
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnEnterArea(other.gameObject.GetComponent<Player>());
        }
    }
    public virtual void OnEnterArea(Player player)
    {
        player.PlayerIdle();
        player.GetComponent<Rigidbody>().AddForce(0, yJumpForce, zJumpForce, ForceMode.Impulse);
    }
}
