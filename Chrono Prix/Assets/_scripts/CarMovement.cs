using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private OldInput _oldInput;
    public CarSO car;
    public WheelCollider[] wheelCollider;
    public Transform[] transforms;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        _oldInput = GetComponent<OldInput>();
        speed = car.speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MotorSpeed();
        Brake();
        AngleOfWheels();
        UpdateWheels();
    }

    public void MotorSpeed()
    {
        foreach (var wheel in wheelCollider)
        {
            wheel.motorTorque = speed * _oldInput.vertical;
        }
    }

    public void Brake()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var wheel in wheelCollider)
            {
                wheel.brakeTorque = car.brake;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (var wheel in wheelCollider)
            {
                wheel.brakeTorque = 0;
            }
        }
    }

    public void AngleOfWheels()
    {
        wheelCollider[2].steerAngle = car.angle * _oldInput.horizontal;
        wheelCollider[3].steerAngle = car.angle * _oldInput.horizontal;
    }

    public void UpdateSingleWheel(WheelCollider collider, Transform transform)
    {
        Vector3 pos;
        Quaternion rot;

        collider.GetWorldPose(out pos, out rot);
    }

    public void UpdateWheels()
    {
        for (int i = 0;i<wheelCollider.Length; i++)
        {
            UpdateSingleWheel(wheelCollider[i], transforms[i]);
        }
    }

}
