using UnityEngine;

public enum ObstaclePattern
{
    Standard,
    Oscillating
}

public class ObstacleMovement : MonoBehaviour
{
    public float speed;
    private float deadZone = -33f;

    [Header("Dynamic Movement")]
    [SerializeField] private float verticalSpeed = 2f;
    [SerializeField] private float verticalAmplitude = 0.8f;

    private ObstaclePattern pattern = ObstaclePattern.Standard;
    private float initialY;

    private void Start()
    {
        initialY = transform.position.y;
    }

    public void SetPattern(ObstaclePattern newPattern)
    {
        pattern = newPattern;
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.CurrentState != GameState.PLAYING) return;

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (pattern == ObstaclePattern.Oscillating)
        {
            float newY = initialY + Mathf.Sin(Time.time * verticalSpeed) * verticalAmplitude;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
        if (transform.position.x < deadZone)
        { 
            Destroy(gameObject);
        }
    }
}