using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour, ICollectibles
{
    private GameObject diamondParticle;
    private int value = 1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnCollect();
        }
    }

    public void OnCollect()
    {
        ScoreManager.Instance.UpdateScore(value);
        Destroy(gameObject);
    }
}
