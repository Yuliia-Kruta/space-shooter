using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireDelay = 1f;

    private float lastFiredTime = 0f;
    private float bulletOffset = 2f;

    void Start()
    {
        // Do some math to perfectly spawn bullets in front of us
        bulletOffset = GetComponent<Renderer>().bounds.size.y / 2 // Half of our size
                       + bullet.GetComponent<Renderer>().bounds.size.y / 2; // Plus half of the bullet size
    }

    /// <summary>
    /// Spawns a bullet
    /// </summary>
    public void Shoot()
    {
        float CurrentTime = Time.time;

        // Have a delay so we don't shoot too many bullets
        if (CurrentTime - lastFiredTime > fireDelay)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + bulletOffset);

            Instantiate(bullet, spawnPosition, transform.rotation);

            lastFiredTime = CurrentTime;
        }
    }
}