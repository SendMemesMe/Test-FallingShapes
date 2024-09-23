using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] shapePrefabs;  
    private DifficultySettings difficultySettings;  
    [SerializeField]private DifficultyController difficultyController;  
    public Transform spawnArea;  
    private float nextSpawnTime;


    private void OnEnable()
    {
        difficultySettings = difficultyController.GetCurrentSettings();
        ScheduleNextSpawn();
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnShape();
            ScheduleNextSpawn();
        }
    }

    private void SpawnShape()
    {
        int randomIndex = Random.Range(0, shapePrefabs.Length);
        GameObject shape = Instantiate(shapePrefabs[randomIndex]);

        Vector3 spawnPosition = GetRandomSpawnPosition();

        shape.transform.position = spawnPosition;

        float fallSpeed = Random.Range(difficultySettings.minFallSpeed, difficultySettings.maxFallSpeed);
        shape.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -fallSpeed);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float screenWidthInWorld = Camera.main.orthographicSize * Camera.main.aspect * 2;
        float halfScreenWidth = screenWidthInWorld / 2;

        float randomX = Random.Range(-halfScreenWidth, halfScreenWidth);
        float spawnY = Camera.main.orthographicSize; 

        return new Vector3(randomX, spawnY, 0);  
    }

    private void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + difficultySettings.spawnSpeed; 
    }

    public void RemoveShapes()
    {
        Square[] shapes = FindObjectsOfType<Square>();
        foreach (Square shape in shapes)
        {
            Destroy(shape.gameObject);
        }
    }
}
