using System;
using System.Diagnostics.Metrics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    [SerializeField] private GameObject cannonballPrefab;
    [SerializeField] private CannonInput input;
    [SerializeField] private CannonStats stats;
    [SerializeField] private Transform muzzle;

    [SerializeField] private float firePower = 15f;
    [SerializeField] private float reloadTime = 1f;
    private float reloadTimer = 0f;


    private void Update()
    {

        if(reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
        }
        if (input.FirePressedThisFrame() && reloadTimer <= 0f)
        {
         
            Fire();
            reloadTimer = reloadTime/stats.reloadSpeedMultiplier;  
        }
        
    }

    private void Fire()
    {
       GameObject cannonball  = Instantiate(cannonballPrefab,muzzle.position,muzzle.rotation);
       Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();
        Debug.Log(muzzle.eulerAngles.z);
        rb.linearVelocity = muzzle.right * firePower * stats.bulletSpeedMultiplier;

       // Collider2D ballCollider = cannonball.GetComponent<Collider2D>();
       // Physics2D.IgnoreCollision(ballCollider, ownCollider);
    }
}
