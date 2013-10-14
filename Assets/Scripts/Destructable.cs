using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour {
    public bool destruct;
    public float hull = 10; // hitpoints 
    public float armor = 1; // damage reduction
    public GameObject explosion;

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
    public void ApplyDamage(float damage)
    {
        if (damage > armor)
        {
            hull -= damage;
        }
        if (hull <= 0)
        {
            Destruct();
        }
    }
    void Destruct()
    {
        Instantiate(explosion, collider.transform.position, transform.rotation);
        Destroy(gameObject, 0.5f);
    }







}


    