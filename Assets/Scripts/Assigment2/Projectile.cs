using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 directionNormalized, float power = 20)
    {
        _rb.useGravity = false;
        _rb.AddForce(directionNormalized * power, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision other)
    {
        _rb.useGravity = true;
    }
}