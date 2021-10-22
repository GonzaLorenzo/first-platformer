using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomProjectile : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float ShotSpeed;


    private void Start()
    {
        myRigidBody.AddForce(Vector2.up * (ShotSpeed * Time.deltaTime));
        myRigidBody.AddForce(Vector2.left * (ShotSpeed * Time.deltaTime));
    }
}
