using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTripleShot : WeaponBase {

    /// <summary>
    /// Shoot will spawn a three bullets, provided enough time has passed compared to our fireDelay.
    /// </summary>
    public override void Shoot() {
        // get the current time
        float currentTime = Time.time;

        print("Shoot triple shot");
        // if enough time has passed since our last shot compared to our fireDelay, spawn our bullet
        if (currentTime - lastFiredTime > fireDelay) {
            float x = -0.5f;
            // create 3 bullets
            for (int i = 0; i < 3; i++) {
                
                // Calculate spawn position with offset
                Vector2 spawnPosition = (Vector2)bulletSpawnPoint.position + bulletOffset;

                // Use spawn point's rotation for bullet direction
                Quaternion spawnRotation = bulletSpawnPoint.rotation;

                // create our bullet
                GameObject newBullet = Instantiate(bullet, spawnPosition, spawnRotation);
                
                // set their direction
                newBullet.GetComponent<MoveConstantly>().Direction = new Vector2(x + 0.5f * i, 0.5f);
            }

            // update our shooting state
            lastFiredTime = currentTime;
        }
    }
}
