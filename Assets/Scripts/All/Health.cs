using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int  BaseHeatlh = 3;
    public int  CurrentHealth;
    public bool IsAlive;

    private void Awake()
    {
        CurrentHealth = BaseHeatlh;
        IsAlive = true;
    }

    public void TakeDamage(int Amount)
    {
        if (IsAlive && Amount > 0)
        {
            CurrentHealth -= Amount;
            if (CurrentHealth > 0)
            {
                ReceiveDamage();
            }
            else if (CurrentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        IsAlive = false;
        SendMessage("ApplyDeathEffects");
    }

    private void ReceiveDamage()
    {
        SendMessage("ApplyDamageEffects");
    }
}