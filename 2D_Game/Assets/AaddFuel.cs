using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AaddFuel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public CarController carController;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        carController.fuel = 1;
    }
    
}
