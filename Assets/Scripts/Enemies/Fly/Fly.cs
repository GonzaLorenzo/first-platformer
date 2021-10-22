using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Animator             myAnimator;
    public Health               myHealth;
    public string               DeathBoolName;
    public CircleCollider2D     myCircleCollider;
    public int                  DestroyTime = 1;
    public bool                 CanBeDestroyed;

    private void Awake()
    {
        myAnimator = this.GetComponent<Animator>();
        myHealth = this.GetComponent<Health>();
        myCircleCollider = this.GetComponent<CircleCollider2D>();
    }

    public void ApplyDeathEffects()
    {
        myAnimator.SetBool(DeathBoolName, true);
        myCircleCollider.enabled = false;
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
