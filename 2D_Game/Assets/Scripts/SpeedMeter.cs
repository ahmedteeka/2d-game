using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMeter : MonoBehaviour
{
    private const float MaxSpeedLimit = 350;
    private const float ZeroSpeedAngle = 120;
    public Transform needleTransform;
    public Transform CarControllerTransform;
    // Start is called before the first frame update
    CarController _carController;
    private float speedMax;
    private float speed;

    private void Awake()
    {
        _carController = CarControllerTransform.GetComponent<CarController>();
        speedMax = _carController.maxCarspeed;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (speed > speedMax) speed = speedMax;
        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
        print(GetSpeedRotation());
       // print(needleTransform.eulerAngles);
    }
private float GetSpeedRotation()
    {
        float totalAngleSize = MaxSpeedLimit-ZeroSpeedAngle ;
        float speedNormalized = _carController.Carspeed / speedMax;
        return ZeroSpeedAngle - speedNormalized * totalAngleSize;
    }


}
