using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int DamageAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       Health HitEntity = collision.GetComponent<Health>();
        
        if(HitEntity != null)
        {
            HitEntity.TakeDamage(DamageAmount);
        }       
    }
}
