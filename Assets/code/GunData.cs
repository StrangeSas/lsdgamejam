using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WeaponBlock", menuName = "Weapon/Gun")]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public string name;
    [Header("Shooting")]
    public float firerate;
    public float bulletEnergy;
    public float bulletSpeed;
    [Header("Weapon stats")]
    public int magazineCapacity;
    public int currentAmmo;
    public int ammoInAmmoChamber;
    public float reloadTime;
    public bool reloading;
}
