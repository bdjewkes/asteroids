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
        if (fuel > 0)
        {
            fuel -= Time.deltaTime;
            rigidbody.velocity += transform.forward * thrustPower * Time.deltaTime;
        }   
	}
    void OnCollisionEnter(Collision theCollision)
    {
        GameObject explode;
        Destroy(gameObject);
        explode = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        DelayRemove(3,explode);
        
    }


    IEnumerable DelayRemove(int n,GameObject obj)
    {
        yield return new WaitForSeconds(n);
        Destroy(obj);
        
    }

}
