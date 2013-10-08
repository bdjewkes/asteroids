using UnityEngine;
using System.Collections;


[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(PlayerInput))]
public class Propulsion : MonoBehaviour
{
      public float turnspeed = 5.0f;
      public float maxturnspeed = 10f;
      public float thrustPower = 5.0f;
      public float maxVelocity=1f;
      string powerButton;
      string yawButton;
        
  
      float yaw; // the current state of the Yaw axis
      float forwardThrust; // the current state of the Power axis

      void Start()
      {
          powerButton = GetComponent<PlayerInput>().thrust;
          yawButton = GetComponent<PlayerInput>().yaw;
      }

    void Update() 
      {
        // Behavior for the particle system
           ParticleSystem particlesystem = (ParticleSystem)gameObject.GetComponent("ParticleSystem");
           if (Input.GetAxis(powerButton) > 0) { particlesystem.enableEmission = true; }
           else { particlesystem.enableEmission = false; }
       
        // Input behavior
           yaw = Input.GetAxis(yawButton);
           forwardThrust = Input.GetAxis(powerButton);
      }
    
    void FixedUpdate()
    {  
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
