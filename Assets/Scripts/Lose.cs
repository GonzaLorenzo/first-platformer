using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public int DamageAmount = 1;
    public Player Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player HitEntity = collision.GetComponent<Player>();

        if (HitEntity == Player)
        {
            HitEntity.ApplyDeathEffects();
        }
    }
}
