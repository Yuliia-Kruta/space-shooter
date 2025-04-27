using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnOverTimeScript : MonoBehaviour
{
    /*
    // Object to spawn
    [SerializeField] private GameObject spawnObject;

    // Delay between spawns
    [SerializeField] private float spawnDelay = 2f;*/

    [System.Serializable]
    public class SpawnableObject
    {
        public GameObject prefab;
        public float spawnDelay;
    }
    
    // List of spawnable objects with individual delays
    [SerializeField] private List<SpawnableObject> spawnableObjects;
    
    private Renderer ourRenderer;

    // Use this for initialization
    void Start()
    {
        ourRenderer = GetComponent<Renderer>();

        // Stop our Spawner from being visible!
        ourRenderer.enabled = false;

        // Call the given function after spawnDelay seconds, 
        // and then repeatedly call it after spawnDelay seconds.
        //InvokeRepeating("Spawn", spawnDelay, spawnDelay);
        
        // Start spawning coroutines for each object type
        foreach (var spawnable in spawnableObjects)
        {
            StartCoroutine(SpawnRoutine(spawnable));
        }
    }
    
    IEnumerator SpawnRoutine(SpawnableObject spawnable)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnable.spawnDelay-8);
            Spawn(spawnable.prefab);
            yield return new WaitForSeconds(spawnable.spawnDelay);
        }
    }
    
    void Spawn(GameObject prefab)
    {
        float x1 = transform.position.x - ourRenderer.bounds.size.x / 2f;
        float x2 = transform.position.x + ourRenderer.bounds.size.x / 2f;

        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        Instantiate(prefab, spawnPoint, Quaternion.identity);
    }
/*
    void Spawn()
    {
        float x1 = transform.position.x - ourRenderer.bounds.size.x / 2;
        float x2 = transform.position.x + ourRenderer.bounds.size.x / 2;

        // Randomly pick a point within the spawn object
        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        // Spawn the object at the 'spawnPoint' position
        Instantiate(spawnObject, spawnPoint, Quaternion.identity);
    }*/
}