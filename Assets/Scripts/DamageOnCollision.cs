using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deals damage to objects with an IHealth component on collision.
/// </summary>
public class DamageOnCollision : DetectCollisionBase
{
    [SerializeField] private int damageToDeal;

    protected override void ProcessCollision(GameObject other)
    {
        base.ProcessCollision(other);
        if (other.GetComponent<IHealth>() != null)
        {
            other.GetComponent<IHealth>().TakeDamage(damageToDeal);
        }
        else
        {
            Debug.Log(other.name + " does not have an IHealth component");
        }
    }
}