using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    // Variables to hold refs to MovementScript and ShootingScript
    private MovementScript movementScript;
    private ShootingScript shootingScript;

    void Start()
    {
        // Getting the components attached to RigidBody
        movementScript = GetComponent<MovementScript>();
        shootingScript = GetComponent<ShootingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0.0f)
        {
            // Moves object if there was a Horizontal input
            movementScript.Move(Vector2.right * horizontalInput);
        }

        if (shootingScript != null)
        {
            if (Input.GetButton("Fire1"))
            {
                // Calls function Shoot from ShootingScript if the Fire1 button was pressed
                shootingScript.Shoot();
            }
        }
    }
}