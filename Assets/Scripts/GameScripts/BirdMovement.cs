using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D birdRigibody;
    private bool jumpRequested = false;

    private void Awake()
    {
        birdRigibody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        birdRigibody.bodyType = RigidbodyType2D.Kinematic;
        birdRigibody.linearVelocity = Vector2.zero;
    }

    private void Update()
    {
        if (ActionManager.Instance != null && ActionManager.Instance.isUpActionPressed())
        {
            if (GameManager.Instance.CurrentState == GameState.WAITING || GameManager.Instance.CurrentState == GameState.WAITING)
            {
                birdRigibody.bodyType = RigidbodyType2D.Dynamic;
                GameManager.Instance.SetState(GameState.PLAYING);
                jumpRequested = true;
            }
            else if (GameManager.Instance.CurrentState == GameState.PLAYING)
            {
                jumpRequested = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (jumpRequested)
        {
            birdRigibody.linearVelocity = new Vector2(birdRigibody.linearVelocity.x, jumpForce);
            jumpRequested = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.Instance.CurrentState != GameState.PLAYING) return;

        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground"))
        {
            GameManager.Instance.GameOver();
        }
    }
}