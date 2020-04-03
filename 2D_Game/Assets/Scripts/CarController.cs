using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public  Text              directionText;
    private Touch            theTouch;
    private Vector2          touchStartPosition, touchEndPosition;
    private string           direction;


    public float            fuel = 1;
    public float            fuleconsumption = .01f;
    public GameObject       Location;
    public Rigidbody2D      carRiggedBody;
    public WheelJoint2D     backTire;
    public WheelJoint2D     frontTire;
    public Image            FuelIcon;
    public float            Carspeed = 80;
    public float            carBodyWeight = 0;
    public float            maxCarspeed = 80;
    public float            carRotation;
    public float            rotationSpeed = 100;
    public float            carMovement;
    public float            distToGround = 0;
    public int              slowDownSpeedValue = 20;
    public bool             speedUp =false;
    public LayerMask         groundLayer;
    // Update is called once per frame
    void Start()
    {
        carBodyWeight = carRiggedBody.GetComponent<Rigidbody2D>().mass;
    }
        void Update()
    {

        // Move location to lefr when speed Up
           Location.transform.Translate(Vector3.left * Carspeed * Time.deltaTime);
                

        // rotate the car   
             carRiggedBody.AddTorque(carRotation*100 * carBodyWeight * Time.deltaTime);

        if (Input.touchCount > 0)
            {
                theTouch = Input.GetTouch(0);
                if (theTouch.phase == TouchPhase.Ended)
                {
                       speedUp = false;
                        carRotation = 0;

            }
            if (theTouch.phase == TouchPhase.Began)
                {
                    touchStartPosition = theTouch.position;
                if(IsGrounded()) speedUp = true;

                }

                else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
                {
                    touchEndPosition = theTouch.position;

                    float x = touchEndPosition.x - touchStartPosition.x;
                    float y = touchEndPosition.y - touchStartPosition.y;

                    if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                    {
                        direction = "Tapped";

                    }
                    else if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        direction = x > .3 ? "Right" : "Left";
                        if (direction == "Right") carRotation =- rotationSpeed;
                        if (direction == "Left") carRotation = rotationSpeed;

                        
                    }

                    else
                    {
                        direction = y > 0 ? "Up" : "Down";
                    }
                }
             }
        if (speedUp)
        {
                carMovement = Carspeed;
                if (Carspeed < maxCarspeed&& (IsGrounded()))
                   Carspeed += 20 * Time.deltaTime;
        }

        if (!speedUp && Carspeed>0)
        {
                 Carspeed -= slowDownSpeedValue * Time.deltaTime;
                carRotation = 0;
        }

        //Update the text according to touch Event
        directionText.text = direction;
        FuelIcon.fillAmount = fuel;
        // Restart
        if (Input.GetKeyDown("space"))
        {
            RestartLevel();
        }
    }

    //Test Void
    public void speedUp1()
    {
        Debug.Log("speed up please");

    }
    bool IsGrounded()
    {
         // calculate the Distance from the back tire to layer mask 10 ground 
        //and return true if its in range "Distance"

        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        
        RaycastHit2D hit = Physics2D.Raycast(backTire.transform.position, direction, distToGround, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
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
          //  transform.Translate(Vector3.right * Carspeed * Time.deltaTime);
            backTire.useMotor = true;
            // frontTire.useMotor = true;
           
            JointMotor2D motor = new JointMotor2D { motorSpeed = (carMovement * 400 * Time.fixedDeltaTime), maxMotorTorque = 10000 };

            backTire.motor = motor;
          //  frontTire.motor = motor;
        }
        if (fuel > 0)
        {
          //  fuel -= fuleconsumption * Mathf.Abs(Right_joystick.Vertical) * Time.fixedDeltaTime;
        }


        
        
    }
}
