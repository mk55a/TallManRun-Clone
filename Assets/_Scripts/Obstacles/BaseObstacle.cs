using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObstacle : MonoBehaviour, IObstacle
{
    protected Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public abstract void HandleCollision(Player player);
}
