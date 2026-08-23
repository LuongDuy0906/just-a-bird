using UnityEngine;
using UnityEngine.InputSystem;

public class ActionManager : MonoBehaviour
{
    public static ActionManager Instance { get; private set; }

    public ActionInput inputActions;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        inputActions = new ActionInput();
    }

    private void OnEnable()
    {
        if(inputActions != null)
        {
            inputActions.GameAction.Enable();
        }
    }

    private void OnDisable()
    {
        if (inputActions != null)
        {
            inputActions.GameAction.Disable();
        }
    }

    private void OnDestroy()
    {
        // Dọn dẹp hoàn toàn khi đối tượng bị Destroy lúc load lại Scene
        if (inputActions != null)
        {
            inputActions.Dispose();
        }
    }

    public bool isUpActionPressed()
    {
        return inputActions.GameAction.Up.IsPressed();
    }

    public bool isDownActionPressed()
    {
        return inputActions.GameAction.Down.WasReleasedThisFrame();
    }
}
