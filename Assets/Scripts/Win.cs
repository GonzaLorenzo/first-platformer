using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public Player Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.SendMessage("ApplyWinEffects");
    }
}
