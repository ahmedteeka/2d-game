using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float fuel = 1;
    public float fuleconsumption = .01f;
    public Rigidbody2D carRiggedBody;
    //public GameObject backTire;
   // public GameObject frontTire;
    public WheelJoint2D backTire;
     public WheelJoint2D frontTire;
    JointMotor2D backTireMotor;
    JointMotor2D frontTireMotor;


    public Image  FuelIcon;

    // Start is called before the first frame update
    public float Speed=200;
    public float CarTourque=200;
    private float movement;


    void Start()
    {
        //backTireMotor = backTire.GetComponent<WheelJoint2D>();
       // frontTireMotor = frontTire.GetComponent<WheelJoint2D>();


    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        FuelIcon.fillAmount = fuel;

    }
    private void FixedUpdate()
    {
        if (fuel > 0)
        {
            backTireMotor.motorSpeed = movement*8 * Speed * Time.fixedDeltaTime;
            backTireMotor.maxMotorTorque = 5000;
            backTire.motor = backTireMotor;

            frontTireMotor.motorSpeed = movement *8* Speed * Time.fixedDeltaTime;
            frontTireMotor.maxMotorTorque = 5000;
            frontTire.motor = backTireMotor;
            //backTire.motor.maxMotorTorque = 500f;

            //  backTire.AddTorque(-movement * Speed * Time.fixedDeltaTime);
            // frontTire.AddTorque(-movement * Speed * Time.fixedDeltaTime);
               carRiggedBody.AddTorque(Mathf.Abs(movement) * CarTourque * Time.fixedDeltaTime);

        }
        fuel -= fuleconsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;

    }
}
