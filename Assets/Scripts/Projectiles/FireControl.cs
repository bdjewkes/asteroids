using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInput))]
public class FireControl : MonoBehaviour
{
    public GameObject projectileType;
    public int ammo = 10;
    public float launchForce = 10;
    public float fireDelay = 1f;
    bool fireReady = true;
    bool fire = false;
    string fireButton;
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
        fireButton = GetComponent<PlayerInput>().fire;
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

