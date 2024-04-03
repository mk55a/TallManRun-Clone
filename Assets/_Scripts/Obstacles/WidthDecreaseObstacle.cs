using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidthDecreaseObstacle : BaseObstacle
{
    public float widthDecreaseAmount = 0.1f;

    public override void HandleCollision(Player player)
    {
        rb.isKinematic = false;
        player.GetBody().DecreaseWidth(widthDecreaseAmount);

        GetComponent<BoxCollider>().isTrigger = true;
        rb.AddForce(Random.Range(-10, 10), Random.Range(8, 12), Random.Range(8, 12), ForceMode.Impulse);
    }
}
