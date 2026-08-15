using UnityEngine;
using UnityEngine.Rendering;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstacleObject;
    private float spawnRate = 1f;

    public float heightOffset = 2f;

    private float timer = 0f;

    private void Start()
    {
        SpawnObstacle();
    }

    private void Update()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        float randomY = Random.Range(transform.position.y - heightOffset, transform.position.y + heightOffset);

        Vector3 spawnPos = new Vector3(transform.position.x, randomY);
        Instantiate(obstacleObject, spawnPos, Quaternion.identity);
    }
}
