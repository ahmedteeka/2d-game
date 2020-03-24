using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float fuel = 1;
    public float fuleconsumption = .01f;
    public Rigidbody2D carRiggedBody;
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public Image  FuelIcon;
    // Start is called before the first frame update
    public float Speed=200;
    public float CarTourque=200;
   

    private float movement;
    void Start()
    {
        
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
            backTire.AddTorque(-movement * Speed * Time.fixedDeltaTime);
            frontTire.AddTorque(-movement * Speed * Time.fixedDeltaTime);
          //  frontTire.AddTorque(-movement * Speed * Time.fixedDeltaTime);
            carRiggedBody.AddTorque(-movement * CarTourque * Time.fixedDeltaTime);
        }
        fuel -= fuleconsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;

    }
}
