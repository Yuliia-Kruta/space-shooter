using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMachineGun : WeaponBase {

    /// <summary>
    /// Shoot will spawn a new bullet, provided enough time has passed compared to our fireDelay.
    /// </summary>
    public override void Shoot() {
        // get the current time
        float currentTime = Time.time;

        // if enough time has passed since our last shot compared to our fireDelay, spawn our bullet
        if (currentTime - lastFiredTime > fireDelay) {
            
            // Calculate spawn position with offset
            Vector2 spawnPosition = (Vector2)bulletSpawnPoint.position + bulletOffset;

            // Use spawn point's rotation for bullet direction (optional)
            Quaternion spawnRotation = bulletSpawnPoint.rotation;

            // create our bullet
            Instantiate(bullet, spawnPosition, spawnRotation);
            // update our shooting state
            lastFiredTime = currentTime;
        }
    }
}
