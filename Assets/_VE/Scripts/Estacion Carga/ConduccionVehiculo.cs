using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConduccionVehiculo : MonoBehaviour
{
    public Transform centerOfMass;
    public WheelCollider wheelFL; // Rueda delantera izquierda
    public WheelCollider wheelFR; // Rueda delantera derecha
    public WheelCollider wheelR;  // Rueda trasera

    public float maxMotorTorque = 1500f;
    public float maxSteeringAngle = 30f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (centerOfMass != null)
        {
            rb.centerOfMass = centerOfMass.localPosition;
        }
    }

    void Update()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        // Girar las ruedas delanteras
        wheelFL.steerAngle = steering;
        wheelFR.steerAngle = steering;

        // Aplicar torque a la rueda trasera
        wheelR.motorTorque = motor;
    }

    void FixedUpdate()
    {
        ApplyLocalPositionToVisuals(wheelFL);
        ApplyLocalPositionToVisuals(wheelFR);
        ApplyLocalPositionToVisuals(wheelR);
    }

    private void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
}
