using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTripleShot : WeaponBase
{
    /// <summary>
    /// Shoot will spawn a three bullets, provided enough time has passed compared to our fireDelay.
    /// </summary>
    public override void Shoot()
    {
        // get the current time
        float currentTime = Time.time;

        //print("Shoot triple shot");
        // if enough time has passed since our last shot compared to our fireDelay, spawn our bullet
        if (currentTime - lastFiredTime > fireDelay)
        {
            float x = -0.5f;
            float horizontalOffset = 0.3f; // Horizontal offset between bullets
            // create 3 bullets
            for (int i = 0; i < 3; i++)
            {
                // Calculate spawn position with offset + spread bullets horizontally
                Vector2 spawnPosition = (Vector2)bulletSpawnPoint.position + bulletOffset +
                                        new Vector2(horizontalOffset * (i - 1), 0f);


                // Use spawn point's rotation for bullet direction
                Quaternion spawnRotation = bulletSpawnPoint.rotation;

                // create our bullet
                GameObject newBullet = Instantiate(bullet, spawnPosition, spawnRotation);


                if (CompareTag("Player")) // if the shooter is the player
                {
                    newBullet.GetComponent<MoveConstantly>().Direction = new Vector2(x + 0.5f * i, 0.9f); // upwards
                }
                else // if the shooter is the boss
                {
                    newBullet.GetComponent<MoveConstantly>().Direction = new Vector2(x + 0.5f * i, -0.9f); // downwards
                }
            }

            // update our shooting state
            lastFiredTime = currentTime;
        }
    }
}