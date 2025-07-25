﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pickup is an object aimed at passing weapon functionality to player objects. Depending on
/// the specified weaponType, the Pickup will tell the player object what object it should now
/// use as it's weapon.
/// </summary>
public class Pickup : MonoBehaviour
{
    [SerializeField] public WeaponType weaponType;
    [SerializeField] private int healAmount = 10;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = col.gameObject;
            HandlePlayerPickup(player);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = col.gameObject;
            HandlePlayerPickup(player);
        }
    }

    /// <summary>
    /// HandlePlayerPickup handles all of the actions after a player has been collided with.
    /// It grabs the IWeapon component from the player, transfers all information to a
    /// new IWeapon (based on the provided weaponType).
    /// </summary>
    /// <param name="player"></param>
    private void HandlePlayerPickup(GameObject player)
    {
        // get the playerInput from the player
        InputScript playerInput = player.GetComponent<InputScript>();
        // handle a case where the player doesnt have a PlayerInput
        if (playerInput == null)
        {
            Debug.LogError("Player doesn't have a PlayerInput component.");
            return;
        }

        if (CompareTag("Pickup")) // the triple shot pickup
        {
            // tell the playerInput to SwapWeapon based on our weaponType
            playerInput.SwapWeapon(weaponType);
        }
        else if (CompareTag("Heal")) // any other pickup (the health)
        {
            player.GetComponent<IHealth>().Heal(healAmount);
        }
    }
}

public enum WeaponType
{
    machineGun,
    tripleShot
}