using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] float hitCooldown = 1f;

    [SerializeField] ParticleSystem muzzhleFlash;
    [SerializeField] GameObject hitEffect;

    [SerializeField] Ammo ammoSlot;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }       
    }

    void Shoot()
    {
        if(ammoSlot.GetAmmoAmount > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }
    }

    void PlayMuzzleFlash()
    {
        muzzhleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, hitCooldown);
    }
}
