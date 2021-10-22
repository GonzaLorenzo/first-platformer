using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public Animator             myAnimator;
    public Health               myHealth;
    public string               DeathBoolName;
    public CapsuleCollider2D    myCapsuleCollider;
    public int                  DestroyTime = 1;
    public bool                 CanBeDestroyed;
    public string               DamageBoolName;

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

    public void ApplyDeathEffects()
    {
        myAnimator.SetBool(DeathBoolName, true);
        myCapsuleCollider.enabled = false;
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
