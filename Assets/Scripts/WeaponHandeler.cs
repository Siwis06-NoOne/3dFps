using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponState
{
    unarmed,
    hitScan,
    projektile,
    pewpew,
    Total
}

public class WeaponHandeler : MonoBehaviour
{
        
    [Header("Unarmed = Element 0 \n" +
        "Hitscan = Element 1 \n" +
        "Projectile = Element 2")]
    public Weapon[] AvailableWeapons = new Weapon[(int)WeaponState.Total];
    public Weapon CurrentWeapon = null;

    public float ScrollWheelBreakpoint = 1.0f;
    private float ScrollWheelDelta = 0.0f;
    private WeaponState currentWeaponState;
    public void Update()
    {
        HandleWeaponSwap();

        if (Input.GetMouseButtonDown(0))
        {
            FireHeldWeapon();
        }
    }

    private void HandleWeaponSwap()
    {

        ScrollWheelDelta -= Input.mouseScrollDelta.y;
        if (Mathf.Abs(ScrollWheelDelta) > ScrollWheelBreakpoint)
        {
            int swapDirection = (int)Mathf.Sign(ScrollWheelDelta);
            ScrollWheelDelta /*-*/= /*swapDirection * ScrollWheelBreakpoint;*/0.0f;

            int currentWeaponIndex = (int)currentWeaponState;
            currentWeaponIndex += swapDirection;

            if (currentWeaponIndex >= (int)WeaponState.Total)
            {
                currentWeaponIndex = 0;
            }
            else if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = (int)WeaponState.Total + -1;
            }
            WeaponSwapAnimation(currentWeaponIndex);
        }
    }
    private void WeaponSwapAnimation(int currentWeaponIndex)
    {
        CurrentWeapon.gameObject.SetActive(false);
        currentWeaponState = (WeaponState)currentWeaponIndex;
        CurrentWeapon = AvailableWeapons[currentWeaponIndex];
        CurrentWeapon.gameObject.SetActive(true);
        ScrollWheelDelta = 0;
    }

    public void FireHeldWeapon()
    {
        if (CurrentWeapon != null)
        {
            CurrentWeapon.Fire();
        }
    }
}
