using UnityEngine;
using System.Collections;


[RequireComponent(typeof(ParticleSystem))]
public class Propulsion : MonoBehaviour
{
      public bool active=false;
      public float turnspeed = 5.0f;
      public float rateofturn;
      public float maxturnspeed = 10f;
      public float thrustPower = 5.0f;
      public float maxVelocity=1f;
      void Update() // particlesystem behavior
      {
           ParticleSystem particlesystem = (ParticleSystem)gameObject.GetComponent("ParticleSystem");

           if (Input.GetAxis("Power") > 0) { particlesystem.enableEmission = true; }
           else { particlesystem.enableEmission = false; }
      }
    
    void FixedUpdate()
    {  
        float yaw = Input.GetAxis("Yaw");
        float forwardThrust = Input.GetAxis("Power");
        var currentVelocity = rigidbody.velocity;
        currentVelocity += transform.forward * forwardThrust * thrustPower * Time.deltaTime;
        if (currentVelocity.magnitude > maxVelocity)
        {
            currentVelocity = currentVelocity.normalized * maxVelocity;
        }
        rigidbody.velocity = currentVelocity;
        transform.Rotate(0, turnspeed * yaw * Time.deltaTime, 0);
    }
}
