using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;
    public int GetAmmoAmount { get { return ammoAmount; } }
    public void ReduceCurrentAmmo()
    {
        ammoAmount--;
    }
}
