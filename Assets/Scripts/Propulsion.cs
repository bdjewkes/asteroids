using UnityEngine;
using System.Collections;

public class Propulsion : MonoBehaviour
{
      public bool active=false;
      public float turnspeed = 5.0f;
      public float rateofturn;
      public float maxturnspeed = 10f;
      public float thrust = 5.0f;
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
        if (active)
        {
            float yaw = Input.GetAxis("Yaw");
            float power = Input.GetAxis("Power");
            
       
           //Truespeed controls
            if (trueSpeed < maxthrustahead && trueSpeed > maxthrustastern)
            {
             trueSpeed += thrust*power;
            }
            if (trueSpeed > maxthrustahead)
            {
                trueSpeed = maxthrustahead-0.1f;
            }
            if (trueSpeed < maxthrustastern)
            {
                trueSpeed = maxthrustastern+0.1f;
            }
            if (Input.GetKey("backspace"))
            {
                trueSpeed = 0;
                rateofturn = 0;

            }

            if (power != 0)
            {
                rigidbody.AddRelativeForce(0, 0, trueSpeed * thrust * Time.deltaTime);
            }
            if (yaw != 0)
            {
                transform.Rotate(0, turnspeed * yaw * Time.deltaTime, 0);
            }
        }   
    }
}
