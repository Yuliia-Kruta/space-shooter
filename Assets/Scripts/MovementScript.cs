using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Acceleration and velocity for object movement
    [SerializeField] private float acceleration = 5000f;
    [SerializeField] private float velocity = 5f;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    ///<summary>
    ///Moves object based on direction and acceleration
    ///</summary>
    public void Move(Vector2 direction)
    {
        rb2d.AddForce(direction * acceleration * Time.deltaTime);
    }

    ///<summary>
    ///Applies velocity to RigidBody
    ///</summary>
    public void AddVelocity(Vector2 velocityDirection)
    {
        rb2d.velocity = velocityDirection * velocity;
    }
}