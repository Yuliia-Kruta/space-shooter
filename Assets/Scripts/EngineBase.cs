﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBase : MonoBehaviour
{
    [SerializeField] private float acceleration = 5000f;
    [SerializeField] private float velocity = 5f;

    private Rigidbody2D ourRigidbody;

    void Start()
    {
        // populate ourRigidbody
        ourRigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Accelerate takes a direction as a parameter, and applies a force in this provided direction
    /// to ourRigidbody, based on the acceleration variables and the delta time.
    /// </summary>
    /// <param name="horizontalInput">A direction vector, expected to be a unit vector (magnitude of 1).</param>
    public void Accelerate(Vector2 direction)
    {
        //calculate our force to add
        Vector2 forceToAdd = direction * acceleration * Time.deltaTime;
        // apply forceToAdd to ourRigidbody
        ourRigidbody.AddForce(forceToAdd);
    }

    ///<summary>
    ///Applies velocity to RigidBody
    ///</summary>
    public void AddVelocity(Vector2 velocityDirection)
    {
        ourRigidbody.velocity = velocityDirection * velocity;
    }
}