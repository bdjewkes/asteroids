using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {
    public GameObject projectileType;
    public int ammo = 10;
    public float launchForce=10;
    public float fireDelay = 1f;
    bool fireReady = true;
    float fireTimer;

	void Awake()
    {
        if (projectileType == null)
        {
            Debug.LogError("Set the projectile type!!");
        }
    }

    void Start()
    {
        fireTimer = 0f;
    }

    void Update()
    {
        if (!fireReady)
        {
            fireTimer += Time.deltaTime;
        }
        if (fireTimer >= fireDelay)
        {
            fireReady = true;
            fireTimer = 0f;
        }
    }

    void FixedUpdate () {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo > 0 && fireReady)
            {
                fireReady = false;
                ammo -= 1;
                GameObject projectile;
                projectile = Instantiate(projectileType, transform.position + transform.forward, transform.rotation) as GameObject;
                projectile.rigidbody.velocity = rigidbody.velocity;
                projectile.rigidbody.AddForce(transform.forward * launchForce);   
            }
        }

    }    
}
