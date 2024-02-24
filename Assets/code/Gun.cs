using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Camera cameraForTest;
    [SerializeField] GunData gunData;
    [SerializeField] Transform gunMuzzle;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletForce;

    [SerializeField] AudioSource weaponShoot;
    [SerializeField] AudioSource reloadingSound;
    [SerializeField] AudioClip kickerSound;
    [SerializeField] AudioClip emptyClick;

    [SerializeField] Animator _animator;
    string _currentState;
    const string SHOOT = "ak74 shooting";
    const string RELOADING = "Reloading";

    [SerializeField] float grafityForce;
    [SerializeField] float bulletLifeTime;

    float timeSinceLastShoot;

    void Start()
    {
        //Chaining ShootOutput class shoot input with method shoot
        ShootOutput.shootInput += Shoot;
        ShootOutput.reloadInput += StartReload;
        bulletForce = gunData.bulletEnergy;
        bulletSpeed = gunData.bulletSpeed;
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        timeSinceLastShoot += Time.deltaTime;  
    }
    public void StartReload()
    {
        if (!gunData.reloading)
        {
            StartCoroutine(Reload());
        }

        
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;

        AudioSource currentStuff = Instantiate(reloadingSound, gunMuzzle.position, Quaternion.identity);


        ChangeAnimationState(RELOADING);

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magazineCapacity;

        gunData.reloading = false;

        Destroy(currentStuff, gunData.reloadTime);
        Destroy(currentStuff.gameObject, gunData.reloadTime);
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShoot > 1f / (gunData.firerate / 60);

    public void Shoot()
    {   
        if(gunData.currentAmmo > 0)
        {

            if(CanShoot())
            {
                gunData.ammoInAmmoChamber--;
                switch (gunData.currentAmmo)
                {
                    default:
                        gunData.currentAmmo--;
                        gunData.ammoInAmmoChamber++;
                        break;
                }
                timeSinceLastShoot = 0;

                OnGunShoot();

            }

        }
        /*
        else
        {
                //Штуки для удара отбойника и просто шелчков спускового механизма
                switch (gunData.ammoInAmmoChamber)
                {
                    case 1:
                        if (CanShoot())
                        {
                            Debug.Log("Bum");
                            gunData.ammoInAmmoChamber = 0;
                            timeSinceLastShoot = 0;
                        }

                        OnGunShoot();
                        break;

                    case 0:
                        if (CanShoot()) {
                            Debug.Log("No ammo");
                            //звук удара отбойника
                            timeSinceLastShoot = 0;
                        }
                        gunData.ammoInAmmoChamber--;
                        break;

                    case -1:
                        if (CanShoot())
                        {
                            Debug.Log("THERE IS NO AMMO");
                            //Звук нажатия на спуск
                            timeSinceLastShoot = 0;
                        }
                        break;
                }
            }
    */
    }

    public void ChangeAnimationState(string newState)
    {
        _animator.Play(newState);
    }



    private void OnGunShoot()
    {

        GameObject currentBullet = Instantiate(bulletPrefab, gunMuzzle.position, Quaternion.identity);

        Bullet bulletScript = currentBullet.GetComponent<Bullet>();
        if (bulletScript)
        {

            ChangeAnimationState(SHOOT);
            bulletScript.Initialize(gunMuzzle.transform, bulletSpeed, grafityForce);

        }


        AudioSource currentStuff = Instantiate(weaponShoot, gunMuzzle.position, Quaternion.identity);

        Destroy(currentBullet, bulletLifeTime);
        Destroy(bulletScript, bulletLifeTime);
        Destroy(currentStuff, bulletLifeTime);
        Destroy(currentStuff.gameObject, bulletLifeTime);
    }
}
