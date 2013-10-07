using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour
{
    public GameObject projectileType;
    public int ammo = 10;
    public float launchForce = 10;
    public float fireDelay = 1f;
    public string fireButton;
    public bool playerControlled = true;
    bool fireReady = true;
    bool fire = false;
    float fireTimer;


    void Awake()
    {
        if (projectileType == null)
        {
            Debug.LogError("Set the projectile type!!");
        }
        if (Input.GetKey(fireButton) == null)
        {
            Debug.LogError("You must set a valid firing button!");
            fireButton = "Fire1";
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
        if (Input.GetButtonDown(fireButton) && fireReady && ammo > 0)
        {
            fireReady = false;
            ammo -= 1;
            fire = true;
        }
    }

    void FixedUpdate()
    {
        if (fire)
        {
            fire = false;
            GameObject projectile;
            projectile = Instantiate(projectileType, transform.position + transform.forward, transform.rotation) as GameObject;
            projectile.rigidbody.velocity = rigidbody.velocity;
            projectile.rigidbody.AddForce(transform.forward * launchForce);
        }

    }
}

