using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {
    public GameObject projectileType;
    public int ammo = 10;
    public float launchForce=10;
 
	void Awake()
    {
        if (projectileType == null)
        {
            Debug.LogError("Set the projectile type!!");
        }
    }
    void FixedUpdate () {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo > 0)
            {
                ammo -= 1;
                GameObject projectile;
                projectile = Instantiate(projectileType, transform.position + transform.forward, transform.rotation) as GameObject;
                projectile.rigidbody.velocity = rigidbody.velocity;
                projectile.rigidbody.AddForce(transform.forward * launchForce);
            }
        }
    }    
}
