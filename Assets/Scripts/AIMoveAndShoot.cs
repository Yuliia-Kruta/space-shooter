using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles movement and shooting behavior for EnemySpaceship and EnemyBoss
/// </summary>
public class AIMoveAndShoot : MonoBehaviour
{
    // state
    private Vector2 movementDirection;

    // local references
    private EngineBase engineBase;
    private WeaponBase weapon;

    void Start()
    {
        // populate our local references
        engineBase = GetComponent<EngineBase>();
        weapon = GetComponent<WeaponBase>();

        // get a random direction between South-East and South-West
        float x = Random.Range(-0.5f, 0.5f);
        float y = -0.5f;
        movementDirection = new Vector2(x, y).normalized; // ensure it is normalised
    }

    // Update is called once per frame
    void Update()
    {
        // move our enemy if we have a EnemyMovement component attached
        if (engineBase != null)
        {
            engineBase.Accelerate(movementDirection);
        }

        // shoot if we have a IWeapon component attached
        if (weapon != null)
        {
            weapon.Shoot();
        }
    }

    // Trigger event to detect collision with the border
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy is colliding with the left or right border
        if (other.CompareTag("Border"))
        {
            // Reverse the x-direction to make the enemy move in the opposite direction
            movementDirection.x = -movementDirection.x;
        }
    }
}