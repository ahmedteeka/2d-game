using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public float Carspeed = 80;
    //public float MaxCarspeed = 80;
    public float movement;
    public float carRotation;
    public float carMovement;
    public float rotationSpeed=100;
   // public Joystick Hjoystick;
    public Joystick Vjoystick;
    public Joystick Floatingjoystick;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            RestartLevel();
        }
        Debug.Log(Vjoystick.Vertical);
       
        //-1 to 1
        carRotation = Floatingjoystick.Horizontal* rotationSpeed;
        carMovement = Vjoystick.Vertical* Carspeed;
        FuelIcon.fillAmount = fuel;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void FixedUpdate()
    {
         //Un check Use Motor
        if (carMovement == 0f|| fuel <=0)
            {
                backTire.useMotor = false;
                frontTire.useMotor = false;
            }

           else
                {
            backTire.useMotor = true;
            frontTire.useMotor = true;
            JointMotor2D motor = new JointMotor2D { motorSpeed = (carMovement *600 * Time.fixedDeltaTime), maxMotorTorque = 10000 };
                   backTire.motor = motor;
                    frontTire.motor = motor;
           
        }
        if (fuel > 0)
        {
            fuel -= fuleconsumption * Mathf.Abs(Vjoystick.Vertical) * Time.fixedDeltaTime;
        }
        // rotate the car   

        carRiggedBody.AddTorque(-carRotation *rotationSpeed * Time.fixedDeltaTime);
    }
}
