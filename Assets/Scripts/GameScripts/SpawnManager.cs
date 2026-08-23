using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstacleObject;
    [SerializeField] private float spawnRate = 1.5f;

    [Tooltip("Độ lệch vị trí sinh toàn cụm ống trên trục Y")]
    [SerializeField] private float heightOffset = 1.2f;

    private float timer = 0f;

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.CurrentState != GameState.PLAYING) return;

        if (timer < spawnRate)
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
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);

        GameObject newObstacle = Instantiate(obstacleObject, spawnPos, Quaternion.identity);

        ObstacleTransform obsTransform = newObstacle.GetComponent<ObstacleTransform>();
        if (obsTransform != null)
        {
            obsTransform.SetupAppearance();
        }
    }
}