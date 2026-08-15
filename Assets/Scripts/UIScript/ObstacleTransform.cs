using UnityEngine;

public class ObstacleTransform : MonoBehaviour
{
    [SerializeField] private GameObject topPipe;
    [SerializeField] private GameObject bottomPipe;

    private int displayCase;

    private void Start()
    {
        displayCase = Random.Range(0, 3);
        
        switch (displayCase)
        {
            case 0:
                topPipe.SetActive(true);
                bottomPipe.SetActive(false);
                break;
            case 1:
                bottomPipe.SetActive(true);
                topPipe.SetActive(false);
                break;
            default:
                topPipe.SetActive(true);
                bottomPipe.SetActive(true);
                break;
        }
    }
}
