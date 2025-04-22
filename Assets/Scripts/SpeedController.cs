using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    // Vector2 variables for direction and velocityDirection
    [SerializeField] private Vector2 direction;
    [SerializeField] private Vector2 velocityDirection;

    // Variable to hold ref to MovementScript 
    private EngineBase engineBase;


    // Use this for initialization
    void Start()
    {
        // Getting the movementScript component attached to RigidBody
        engineBase = GetComponent<EngineBase>();
        // Applies velocity to RigidBody
        engineBase.AddVelocity(velocityDirection);
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the object by calling Move function from movementScript
       engineBase.Accelerate(direction);
    }
}