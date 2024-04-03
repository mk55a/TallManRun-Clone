using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurdle : BaseObstacle
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandleCollision(collision.gameObject.GetComponent<Player>());
        }
    }

    public override void HandleCollision(Player player)
    {
        //rb.isKinematic = false;
        if (player.transform.GetChild(1).transform.localScale.y > 0.5f)
        {
            player.GetBody().DecreaseHeight(0.15f);
        }
        else
        {
            player.GetBody().DecreaseWidth(0.1f);
        }

        GetComponent<BoxCollider>().isTrigger = true;
        //rb.AddForce(Random.Range(-10, 10), Random.Range(8, 12), Random.Range(8, 12), ForceMode.Impulse);
    }
}
