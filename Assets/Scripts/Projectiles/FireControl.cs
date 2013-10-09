using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerInput))]
public class FireControl : MonoBehaviour
{
    public GameObject projectileType;
    public int ammo = 10;
    public float launchForce = 10;
    public float fireDelay = 1.0f;
    bool fireReady = true;
    bool fire = false;  
    string fireButton;
    float fireTimer;

    void Awake()
    {
        if (projectileType == null)
        {
            Debug.LogError("Set the projectile type for " + this);
        }
    }

    void Start()
    {
        fireTimer = 0f;
        fireButton = GetComponent<PlayerInput>().fire;
    }

    public bool QueueFireAction()
    {
        if ( fireReady && ammo > 0)
        {
            fireReady = false;
            fire = true;
            ammo--;
            return true;
        }
        else return false;
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
        if (Input.GetButtonDown(fireButton))
        {
            QueueFireAction();
        }
    }

    void FixedUpdate()
    {
        if (fire)
        {
            fire = false;
            GameObject projectile;
            Vector3 launchorigin = transform.position + transform.forward;
            while (collider.bounds.Contains(launchorigin)) launchorigin = launchorigin + transform.forward;
            projectile = Instantiate(projectileType, launchorigin, transform.rotation) as GameObject;
            projectile.rigidbody.velocity = rigidbody.velocity;
            projectile.rigidbody.AddForce(transform.forward * launchForce);
        }

    }
}

