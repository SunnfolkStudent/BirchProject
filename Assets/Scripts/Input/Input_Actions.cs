using UnityEngine;

public class Input_Actions : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    
    //public float Horizontal;
    //public float Vertical;

    public Vector2 moveDirection;

    public bool Throw;

    public void Update()
    {
        //moveDirection = _inputActions.Player.Move.ReadValue<Vector2>();
        //Horizontal = _inputActions.Player.Move.ReadValue<Vector2>().x;
        //Vertical = _inputActions.Player.Move.ReadValue<Vector2>().y;

        moveDirection = RemoveDiagonal(_inputActions.Player.Move.ReadValue<Vector2>());
        Throw = _inputActions.Player.Jump.WasPressedThisFrame();
    }

    private Vector2 RemoveDiagonal(Vector2 _input)
    {
        float X = _input.x;
        float Y = _input.y;
        if (X * X > Y * Y)
        {
            return new Vector2(X, 0);
        }
        else
        {
            return new Vector2(0, Y);
        }
    }
    
    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }
}