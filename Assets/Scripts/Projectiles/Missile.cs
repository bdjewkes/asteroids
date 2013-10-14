using UnityEngine;
using System.Collections;


[RequireComponent(typeof(ParticleSystem))]
public class Missile : MonoBehaviour {

    public float fuel= 3;
    public float thrustPower = 5;
    public float damage = 5f;
    public GameObject explosion;
    public float explosiveRange = 3f;    

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
    }
    void DestructMissile()
    {
        ExplosiveDamage();
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
        
    }

    void ExplosiveDamage()
    {
        Collider[] inRange = Physics.OverlapSphere(gameObject.transform.position, explosiveRange);
        foreach (Collider obj in inRange)
        {
            var destructable = obj.GetComponent<Destructable>();
            if (destructable != null)
            {
                Vector3 closestPoint = obj.ClosestPointOnBounds(gameObject.transform.position);
                float distance = Vector3.Distance(closestPoint, gameObject.transform.position);
                float explodeDam = (1 - distance / explosiveRange) * damage;
                destructable.ApplyDamage(explodeDam);
                Debug.Log(obj.gameObject.name + " " + explodeDam);
            }

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, explosiveRange);

    }

}
