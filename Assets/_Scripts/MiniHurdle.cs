using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniHurdle : Hurdle
{
    public override void HandleCollision(Player player)
    {
        base.HandleCollision(player);
        rb.isKinematic = false;
        rb.AddForce(Random.Range(-10, 10), Random.Range(8, 12), Random.Range(8, 12), ForceMode.Impulse);
    }
}
