using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FireControl))]
public class FireAI : MonoBehaviour {
    public bool firewhenready;
    public bool spin;

    public float spinperiod = 5.0f;
    public float spinspeed = 10.0f;
    bool fired;
    float startTime;
    
    // Use this for initialization
	void Start () {
        startTime = Time.time; 
 	}
	
	// Update is called once per frame
	void Update () {
        if (firewhenready)
        {
            fired = GetComponent<FireControl>().QueueFireAction();
        }
        if (spin)
        {
            if (Time.time - startTime > spinperiod)
            {
                spinspeed *= -1;
                startTime = Time.time;
            }
            transform.Rotate(0, spinspeed*Time.deltaTime, 0);
        }
	}
}
