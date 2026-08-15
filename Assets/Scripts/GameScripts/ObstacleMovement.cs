using UnityEngine;
using UnityEngine.Rendering;

public class ObstacleMovement : MonoBehaviour
{
    public float speed;
    private float deadZone = -33f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
