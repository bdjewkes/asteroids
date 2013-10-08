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
        ParticleSystem particleSystem = (ParticleSystem)gameObject.GetComponent<ParticleSystem>();
        if (fuel> 0) { particleSystem.enableEmission = true; }
        else { particleSystem.enableEmission = false; }
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
        DestructMissile();
    }
        


    void OnCollisionEnter(Collision theCollision)
    {
        DestructMissile();
        var destructable = theCollision.collider.GetComponent<Destructable>();
        if (destructable != null)
        {
            if (destructable.destruct)
            {
                Instantiate(destructable.explosion, theCollision.collider.transform.position, theCollision.transform.rotation);
                Destroy(theCollision.gameObject,0.5f);
            }
        }
    }
    void DestructMissile()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
        
    }


}
