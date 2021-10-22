using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    public int              PlayerContact;
    public int              DamageAmount = 1;
    public Animator         myAnimator;
    public string           HitBoolName;
    public Goblin           Goblin;
    public BoxCollider2D    myBoxCollider;

    public void Awake()
    {
        myBoxCollider = this.GetComponent<BoxCollider2D>();
    }
    public bool IsHitting()
    {
        return (PlayerContact > 0);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerContact++;

        Health HitEntity = collision.GetComponent<Health>();

        if (HitEntity != null)
        {
            HitEntity.TakeDamage(DamageAmount);
            Goblin.SendMessage("ApplyHitEffects");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        PlayerContact--;
    }

    
}
