using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // to do: create a focus on enemy (lock positionFactors when enemy is focused) - maybe just don't lock positionRollFactor, if locked then unlock only if the player uses the 360° skill
    // to do: create a skill button where the spaceship rotate 360° (increase positionRollFactor)

    [SerializeField] float xControlSpeed = 0f;
    [SerializeField] float yControlSpeed = 0f;
    [SerializeField] float xRange = 0f;
    [SerializeField] float yRange = 0f;

    [SerializeField] float positionPitchFactor = -0f;
    [SerializeField] float controlPitchFactor = -0f;

    [SerializeField] float positionYawFactor = 0f;
    [SerializeField] float controlYawFactor = 0f;

    [SerializeField] float positionRollFactor = -0f;
    [SerializeField] float controlRollFactor = -0f;

    [SerializeField] GameObject[] lasers;
    
    float xThrow, yThrow;

    void Start()
    {
        
    }

    void Update()
    {
        ShipMovement();
        ShipRotation();
        ShipFiring();
    }

    void ShipMovement()
    {
        // Getting the raw position of the spaceship
        xThrow = Input.GetAxis("Horizontal"); // remember to store it on a variable if the string is used many times (prevent from typing error)
        yThrow = Input.GetAxis("Vertical");
        
        // Control of the spaceship speed
        float xOffset = xThrow * Time.deltaTime * xControlSpeed;
        float yOffset = yThrow * Time.deltaTime * yControlSpeed;

        // Local raw position + speed (it moves the spaceship)
        float xRawPos = transform.localPosition.x + xOffset;
        float yRawPos = transform.localPosition.y + yOffset;

        // Clamping it so the spaceship is always constrained at screen
        float xClampedPos = Mathf.Clamp(xRawPos, -xRange, xRange);
        float yClampedPos = Mathf.Clamp(yRawPos, -yRange, yRange);

        transform.localPosition = new Vector3(xClampedPos, yClampedPos, transform.localPosition.z); // get the local position of the ship
    }

    void ShipRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor; 
        float pitchDueToThrow = yThrow * controlPitchFactor;  

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueToThrow = xThrow * controlYawFactor;

        float rollDueToPosition = transform.localPosition.x * positionRollFactor;
        float rollDueToThrow = xThrow * controlRollFactor;

        float pitch = pitchDueToPosition + pitchDueToThrow; // rotation on x axis
        float yaw = yawDueToPosition + yawDueToThrow; // rotation on y axis
        float roll = rollDueToPosition + rollDueToThrow; // rotation on z axis

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); // y rotation, x rotation, z rotation
    }

    void ShipFiring()
    {
        if (Input.GetButton("Fire1")) {
            SetLasersActive(true);
            Debug.Log("AAAA");
        }
        
        else {
            SetLasersActive(false);
        }
        
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
