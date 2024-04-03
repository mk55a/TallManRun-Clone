using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightDecreaseObstacle : BaseObstacle
{
    public float heightDecreaseAmount = 0.15f;

    public override void HandleCollision(Player player)
    {
        rb.isKinematic = false;
        if (player.transform.GetChild(1).transform.localScale.y > 0.5f)
        {
            player.GetBody().DecreaseHeight(heightDecreaseAmount);
        }
        else
        {
            player.GetBody().DecreaseWidth(heightDecreaseAmount);
        }

        GetComponent<BoxCollider>().isTrigger = true;
        rb.AddForce(Random.Range(-10, 10), Random.Range(8, 12), Random.Range(8, 12), ForceMode.Impulse);
    }
}
