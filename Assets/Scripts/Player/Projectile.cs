using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 Speed;
    public Rigidbody2D MyRigidbody2D;
    public float DestroyTime = 3f;

    private void Start()
    {
        MyRigidbody2D.velocity = Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        DestroyTime -= Time.deltaTime;

        if(DestroyTime <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

}
