using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSensor : MonoBehaviour
{
    public int WallContact;

    public bool HasContact()
    {
        return (WallContact > 0);
    }

    void OnTriggerEnter2D()
    {
        WallContact++;
    }

    void OnTriggerExit2D()
    {
        WallContact--;
    }
}
