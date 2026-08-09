using UnityEngine;
using UnityEngine.InputSystem;

public class ActionManager : MonoBehaviour
{
    public static ActionManager Instance { get; private set; }

    public ActionInput inputActions;

    private void Awake()
    {
        Instance = this;
        inputActions = new ActionInput();

        inputActions.Enable();
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
