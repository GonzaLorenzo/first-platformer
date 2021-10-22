using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Animator myAnimator;
    public string CoinDestroyBoolName;
    public int DestroyTime = 1;
    public bool CanBeDestroyed;
    static public int CollectedAmount;
    public int CoinValue;

    private void Awake()
    {
        myAnimator = this.GetComponent<Animator>();
        CanBeDestroyed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectedAmount += CoinValue;
        Debug.Log("Agarraste una moneda! Ahora tenés " + CollectedAmount + ".");
        myAnimator.SetBool(CoinDestroyBoolName, true);
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
