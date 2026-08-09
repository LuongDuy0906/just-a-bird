using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D birdRigibody;

    private void Awake()
    {
        birdRigibody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (ActionManager.Instance.isUpActionPressed())
        {
            birdRigibody.linearVelocity = new Vector2(birdRigibody.linearVelocity.x, jumpForce);
        }
    }
}
