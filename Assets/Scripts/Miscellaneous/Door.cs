using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Collider2D   DoorCollider;
    public Animator     myAnimator;
    public string       OpenBoolName;
    int                 CoinsNeeded = 22;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Coin.CollectedAmount >= CoinsNeeded)
        {
            Open();
        }
    }
    public void Open()
    {
        DoorCollider.enabled = false;
        myAnimator.SetBool(OpenBoolName, true);
    }

    public void Close()
    {
        DoorCollider.enabled = true;
    }
}
