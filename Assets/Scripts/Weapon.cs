using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Ammunition = 1337;
    public LayerMask weaponRayMask;
    public float weaponRange = 421.68f;

    //public LayerMask weaponRayMask;
    //public float weaponRange = 100;

    //public WeaponState WeaponType = WeaponState.Total;
    //public int Ammunition = 1337;

    //public LayerMask IgnoreHitMask = 0;

    public virtual bool Fire()
    {
        if (Ammunition < 1)
        {
            return false;
        }
        else
        {
            Ammunition--;
            return true;
        }
    }
}
