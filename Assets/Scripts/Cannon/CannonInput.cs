using UnityEngine;
using UnityEngine.InputSystem;

public class CannonInput : MonoBehaviour
{
    [SerializeField] private bool isPlayer1 = true;

    private Controls controls;
    private InputAction moveAction;
    private InputAction fireAction;

    private void Awake()
    {
        controls = new Controls();
        if (isPlayer1)
        {
            moveAction = controls.Player1.Move;
            fireAction = controls.Player1.Fire;
        }
        else
        {
            moveAction = controls.Player2.Move;
            fireAction = controls.Player2.Fire;
        }
    }

    private void OnEnable()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        fireAction.Disable();

    }

    public float GetVerticalInput()
    {
        return moveAction.ReadValue<float>();

    }
    public bool FirePressedThisFrame()
    {
        return fireAction.WasPressedThisFrame();
    }
}