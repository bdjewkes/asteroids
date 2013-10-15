using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FireControl))]
public class FireAI : MonoBehaviour {
    
    public bool firewhenready;
    public bool spin;

    public float spinperiod = 5.0f;
    public float spinspeed = 1.0f;
    bool fired;
    float startTime;

    public Vector3 leftArc; 
    public Vector3 rightArc;

    Quaternion leftRotation; 
    Quaternion rightRotation;
    Quaternion nextRotate;

    // Use this for initialization
	void Start () {

        startTime = Time.time;
        leftRotation = Quaternion.LookRotation(leftArc);
        rightRotation = Quaternion.LookRotation(rightArc);
        nextRotate = rightRotation;
        Debug.Log("Left Rotation: " + leftRotation.eulerAngles.y);
        Debug.Log("Right Rotation: " + rightRotation.eulerAngles.y);

    }

	// Update is called once per frame
    
	void Update () {
        if (firewhenready)
        {
            fired = GetComponent<FireControl>().QueueFireAction();
        }
        if (spin)
        {
           // if (Time.time - startTime > spinperiod)
           // {
           //     spinspeed *= -1;
           //     startTime = Time.time;
           // }
            
            
            //Quaternion.Slerp
            //Mathf.PingPong
           // float t = Mathf.PingPong(leftRotati

            transform.localRotation = Quaternion.Slerp(leftRotation, rightRotation, Mathf.PingPong(Time.time, 1.0f));
        
        }
	}

    void ScanFiringArc()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.parent.rotation * rightArc * 5);
        Gizmos.DrawLine(transform.position, transform.position + transform.parent.rotation * leftArc * 5);
        Gizmos.DrawLine(transform.position, transform.position + transform.forward*10);

    }
}