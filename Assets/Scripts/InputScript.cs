using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// InputScript handles all of the player specific input behaviour, and passes the input information
/// to the appropriate scripts.
/// </summary>
public class InputScript : MonoBehaviour
{
    // Variables to hold refs to movement and weapon scripts
    private EngineBase movementScript;

    private WeaponBase weapon;

    public WeaponBase Weapon
    {
        get { return weapon; }

        set { weapon = value; }
    }

    // Duration for power-up effects
    [SerializeField] private float powerUpDuration = 5f;
    private float powerUpTimer;

    void Start()
    {
        // Getting the components attached to RigidBody
        movementScript = GetComponent<EngineBase>();
        weapon = GetComponent<WeaponBase>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0.0f)
        {
            // Move the player if the movement script is available
            if (movementScript != null)
            {
                movementScript.Accelerate(Vector2.right * horizontalInput);
            }
        }

        // If we press the Fire1 button
        if (Input.GetButton("Fire1"))
        {
            // Shoot if the weapon script is available
            if (weapon != null)
            {
                weapon.Shoot();
            }
        }

        // Handle power-up timer countdown
        if (powerUpTimer > 0)
        {
            powerUpTimer -= Time.deltaTime;
            if (powerUpTimer <= 0)
            {
                // Swap back to machine gun when power-up expires
                SwapWeapon(WeaponType.machineGun);
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
                powerUpTimer = powerUpDuration; // Start power-up timer for triple shot
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