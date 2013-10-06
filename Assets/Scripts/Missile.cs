using UnityEngine;
using System.Collections;


[RequireComponent(typeof(ParticleSystem))]
public class Missile : MonoBehaviour {

    public float fuel= 3;
    public float thrustPower = 5;
    public GameObject explosion;
    void Awake()
    {
        if (explosion == null)
        {
            Debug.LogError("Set the explosion animation!!");
        }
    }
	// Update is called once per frame
    void Update()
    {
        ParticleSystem particlesystem = (ParticleSystem)gameObject.GetComponent("ParticleSystem");
        if (fuel> 0) { particlesystem.enableEmission = true; }
        else { particlesystem.enableEmission = false; }
    }

	void FixedUpdate () {
        bool destructCountDown = false;
        if (fuel > 0)
        {
            fuel -= Time.deltaTime;
            rigidbody.velocity += transform.forward * thrustPower * Time.deltaTime;
        }
        if (fuel <= 0)
        {
            if (!destructCountDown) StartCoroutine(MissileTimer(3, gameObject));
            else destructCountDown = true;
        }
	}
    IEnumerator MissileTimer(int time,GameObject obj)
    {
        yield return new WaitForSeconds(time);
        DestructMissile(obj);
    }
        


    void OnCollisionEnter(Collision theCollision)
    {
        DestructMissile(gameObject);
    }
    void DestructMissile(GameObject missile)
    {
        GameObject explode;
        Destroy(gameObject);
        explode = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        Destroy(explode, 3);
    }


}
