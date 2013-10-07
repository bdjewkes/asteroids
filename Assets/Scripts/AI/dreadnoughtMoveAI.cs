using UnityEngine;
using System.Collections;

public class dreadnoughtMoveAI : MonoBehaviour {
    public GameObject toOrbit;
    private Transform orbitFocus; // The transform of the object to be orbited
    public float orbitRadius = 10.0f; // How large the orbit should be
    public float orbitSpeed = 10; // for adjusting the speed of orbit

    void Start()
    {
        orbitFocus = toOrbit.transform;
        transform.position = (transform.position - orbitFocus.position).normalized * orbitRadius + orbitFocus.position;
    }

    void Update()
    {
        transform.RotateAround(orbitFocus.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }

      
}





  /*  public float orbitradius = 10.0f;
    Quaternion rotation;
    float currentRotation = 0.0f;
    Vector3 radius;

    void Start()
    {
        radius = new Vector3(orbitradius, 0, 0);
    }


	// Update is called once per frame
	void Update () {
        currentRotation += 10 * Time.deltaTime;
        rotation.eulerAngles =  new Vector3(0, currentRotation, 0);
        transform.position = rotation * radius;
        transform.Rotate(0,currentRotation,0);*/