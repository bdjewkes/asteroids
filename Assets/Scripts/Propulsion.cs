using UnityEngine;
using System.Collections;

public class Propulsion : MonoBehaviour
{
      public bool active=false;
      public float turnspeed = 5.0f;
      public float rateofturn;
      public float maxturnspeed = 10f;
      public float thrustPower = 5.0f;
      public float trueSpeed = 0.0f;
      public float maxthrustahead=1f;
      public float maxthrustastern=-0.6f;

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
        currentVelocity += transform.forward*forwardThrust*thrustPower*Time.deltaTime;
        if (currentVelocity.magnitude > maxthrustahead)
        {
            currentVelocity = currentVelocity.normalized * maxthrustahead;
        }
        rigidbody.velocity = currentVelocity;
    }
}

/*  Logic for rotation with momentum
 * 
 * 
 *   rateofturn += yaw * turnspeed * Time.deltaTime;
         rigidbody.AddRelativeTorque(0, yaw * turnspeed * Time.deltaTime, 0);
         if ( rateofturn >= maxturnspeed)
         {
             rateofturn = (maxturnspeed - 0.1f);
             rigidbody.AddRelativeTorque(0, yaw * turnspeed * -1.0f * Time.deltaTime, 0);
         }
         if (rateofturn <= maxturnspeed * -1)
         {
              rateofturn = (maxturnspeed * -1 + 0.1f);
              rigidbody.AddRelativeTorque(0, yaw * turnspeed * -1.0f * Time.deltaTime, 0);

          }
 * 
 * 
*/