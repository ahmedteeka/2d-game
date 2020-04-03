using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform CarControllerTransform;
    CarController _carController;

    public Transform target;
    private Vector3 offset;
    // Start is called before the first frame update
    private void Awake()
    {
        _carController = CarControllerTransform.GetComponent<CarController>();
        
    }
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        transform.GetComponent<Camera>().orthographicSize =  (_carController.Carspeed / _carController.maxCarspeed)*5+33;
    }
}
