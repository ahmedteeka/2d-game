using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float fuel = 1;
    public float fuleconsumption = .01f;

    public Rigidbody2D carRiggedBody;
    
    public WheelJoint2D backTire;
    public WheelJoint2D frontTire;
    //JointMotor2D backTireMotor;
    JointMotor2D frontTireMotor;

    public Image  FuelIcon;
    //public float Speed=200;
    public float CarTourque = 0;
    public float movement;

       public void FuelBttnPressed()
    {
        CarTourque = 0;
        movement = 2;
    }
    public void BreakBttnPressed()
    {
        backTire.useMotor = true;
        frontTire.useMotor = true;
        CarTourque =300;
        movement = .001f;
    }
        // Update is called once per frame
    void Update()
    {

        FuelIcon.fillAmount = fuel;
    }
    private void FixedUpdate()
    {
         //Un check Use Motor
        if (movement == 0f|| fuel <=0)
            {
                backTire.useMotor = false;
                frontTire.useMotor = false;
            }

           else
                {
            backTire.useMotor = true;
            frontTire.useMotor = true;
            JointMotor2D motor = new JointMotor2D { motorSpeed = (movement * 18000 * Time.fixedDeltaTime), maxMotorTorque = 10000 };
                    backTire.motor = motor;
                    frontTire.motor = motor;
              // rotate the car      carRiggedBody.AddTorque(- CarTourque * Time.fixedDeltaTime);
        }
        if (fuel > 0)
        {
            fuel -= fuleconsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;
        }
    }
}
