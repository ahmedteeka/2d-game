using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float            fuel = 1;
    public float            fuleconsumption = .01f;
    public GameObject       Location;
    public Rigidbody2D      carRiggedBody;
    public WheelJoint2D     backTire;
    public WheelJoint2D     frontTire;
    public Image            FuelIcon;
    public float            Carspeed = 80;
    public float            maxCarspeed = 80;
    public float            carRotation;
    public float            carMovement;
    public float            rotationSpeed = 100;
    public FixedJoystick    Right_joystick;
    public Joystick         Floatingjoystick;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            RestartLevel();
        }
        //-1 to 1
        carRotation = Floatingjoystick.Horizontal * rotationSpeed;
        
        //carMovement = Right_joystick.Vertical * Carspeed;

        FuelIcon.fillAmount = fuel;
        
        if (Right_joystick.Vertical > 0)
        {
            if(Carspeed<maxCarspeed)
            Carspeed+=20*Time.deltaTime;
            carMovement = Right_joystick.Vertical * Carspeed;

        }


        if (carMovement > 0)
        {
            Carspeed -= 1 * Time.deltaTime;
        }
        
        Location.transform.Translate(Vector3.left * carMovement * Time.deltaTime);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void FixedUpdate()
    {
        //Un check Use Motor
        if (carMovement == 0f || fuel <= 0)
        {
          //  backTire.useMotor = false;
          //    frontTire.useMotor = false;
        }

        else
        {
           // transform.Translate(Vector3.left * Carspeed * Time.deltaTime);
           // backTire.useMotor = true;
            // frontTire.useMotor = true;
           
          //  JointMotor2D motor = new JointMotor2D { motorSpeed = (carMovement * 800 * Time.fixedDeltaTime), maxMotorTorque = 10000 };

        //    backTire.motor = motor;
          //  frontTire.motor = motor;
        }
        if (fuel > 0)
        {
          //  fuel -= fuleconsumption * Mathf.Abs(Right_joystick.Vertical) * Time.fixedDeltaTime;
        }


        // rotate the car   
           carRiggedBody.AddTorque(-carRotation * rotationSpeed * Time.fixedDeltaTime);
        
    }
}
