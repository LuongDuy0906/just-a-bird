using UnityEngine;

public class ObstacleTransform : MonoBehaviour
{
    [SerializeField] private GameObject topPipe;
    [SerializeField] private GameObject bottomPipe;

    [Header("Top Pipe Positions")]
    [Tooltip("Vị trí khi cột trên rút cao lên trời")]
    [SerializeField] private float topRetractedY = 24f;
    [Tooltip("Vị trí khi cột trên thò dài xuống cản đường")]
    [SerializeField] private float topExtendedY = 16f;

    [Header("Bottom Pipe Positions")]
    [Tooltip("Vị trí khi cột dưới rút sâu xuống đáy")]
    [SerializeField] private float botRetractedY = -24f;
    [Tooltip("Vị trí khi cột dưới nhô dài lên cản đường")]
    [SerializeField] private float botExtendedY = -16f;

    public void SetupAppearance()
    {
        if (topPipe == null || bottomPipe == null) return;

        topPipe.SetActive(true);
        bottomPipe.SetActive(true);

        // Chỉ chọn 1 trong 2: hoặc trên thò, hoặc dưới thò
        int patternCase = Random.Range(0, 2);

        if (patternCase == 0)
        {
            // Cột TRÊN thò dài xuống -> Cột DƯỚI rút sâu xuống
            SetY(topPipe, topExtendedY);
            SetY(bottomPipe, botRetractedY);
        }
        else
        {
            // Cột DƯỚI nhô dài lên -> Cột TRÊN rút cao lên
            SetY(topPipe, topRetractedY);
            SetY(bottomPipe, botExtendedY);
        }
    }

    private void SetY(GameObject pipe, float y)
    {
        pipe.transform.localPosition = new Vector3(pipe.transform.localPosition.x, y, 0);
    }
}