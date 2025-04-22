using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// InputScript handles all of the player specific input behaviour, and passes the input information
/// to the appropriate scripts.
/// </summary>
public class InputScript : MonoBehaviour
{
    // Variables to hold refs to MovementScript and ShootingScript
    private EngineBase movementScript;
    //private ShootingScript shootingScript;
    
    private WeaponBase weapon;
    public WeaponBase Weapon
    {
        get
        {
            return weapon;
        }

        set
        {
            weapon = value;
        }
    }

    void Start()
    {
        // Getting the components attached to RigidBody
        movementScript = GetComponent<EngineBase>();
        //shootingScript = GetComponent<ShootingScript>();
        weapon = GetComponent<WeaponBase>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0.0f)
        {
            // ensure our playerMovementScript is populated to avoid errors
            if (movementScript != null)
            {
                // pass our movement input to our playerMovementScript
                movementScript.Accelerate(Vector2.right * horizontalInput);
            }
        }
/*
        if (shootingScript != null)
        {
            if (Input.GetButton("Fire1"))
            {
                // Calls function Shoot from ShootingScript if the Fire1 button was pressed
                shootingScript.Shoot();
            }
        }*/
        
        // if we press the Fire1 button
        if (Input.GetButton("Fire1"))
        {
            // if our shootingScript is populated
            if (weapon != null)
            {
                // tell shootingScript to shoot
                weapon.Shoot();
            }
        }
    }
    
    
    /// <summary>
    /// SwapWeapon handles creating a new WeaponBase component based on the given weaponType. This
    /// will popluate the newWeapon's controls and remove the existing weapon ready for usage.
    /// </summary>
    /// <param name="weaponType">The given weaponType to swap our current weapon to, this is an enum in WeaponBase.cs</param>
    public void SwapWeapon(WeaponType weaponType)
    {
        // make a new weapon dependent on the weaponType
        WeaponBase newWeapon = null;
        switch (weaponType)
        {
            case WeaponType.machineGun:
                newWeapon = gameObject.AddComponent<WeaponMachineGun>();
                break;
            case WeaponType.tripleShot:
                newWeapon = gameObject.AddComponent<WeaponTripleShot>();
                break;
        }

        // update the data of our newWeapon with that of our current weapon
        newWeapon.UpdateWeaponControls(weapon);
        // remove the old weapon
        Destroy(weapon);
        // set our current weapon to be the newWeapon
        weapon = newWeapon;
    }
}