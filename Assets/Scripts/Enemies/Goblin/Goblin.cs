using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public Animator             myAnimator;
    public Health               myHealth;
    public string               DeathBoolName;
    public CapsuleCollider2D    myCapsuleCollider;
    public int                  DestroyTime = 1;
    public bool                 CanBeDestroyed;
    public string               DamageBoolName;
    public PlayerSensor         myPlayerSensor;
    public string               HitBoolName;

    private void Awake()
    {
        myAnimator = this.GetComponent<Animator>();
        myHealth = this.GetComponent<Health>();
        myCapsuleCollider = this.GetComponent<CapsuleCollider2D>();
    }

    public void ApplyDamageEffects()
    {
        myAnimator.SetBool(DamageBoolName, true);
    }

    public void ApplyHitEffects()
    {
        myAnimator.SetBool(HitBoolName, true);
    }

    public void ApplyDeathEffects()
    {
        myCapsuleCollider.enabled = false;
        myAnimator.SetBool(DeathBoolName, true);
        myPlayerSensor.myBoxCollider.enabled = false;
        StartCoroutine(StartDestroyTime());
        
    }

    public IEnumerator StartDestroyTime()
    {
        CanBeDestroyed = false;

        yield return new WaitForSeconds(DestroyTime);

        CanBeDestroyed = true;

        if (CanBeDestroyed)
        {
            Destroy(this.gameObject);
        }
    }

}
