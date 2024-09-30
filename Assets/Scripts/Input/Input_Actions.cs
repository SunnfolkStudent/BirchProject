using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Actions : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    public Vector2 MoveDirection;

    [SerializeField] private bool[] LRUD = new []{false, false, false, false};
    [SerializeField] private Vector2[] dir = new [] {new Vector2(-1,0), new Vector2(1, 0), new Vector2(0,1), new Vector2(0, -1) };
    [SerializeField] private List<Vector2> directions;
    
    public bool Throw;

    public void Update()
    {
        SetMoveDirection();
        Throw = _inputActions.Player.Jump.WasPressedThisFrame();
    }
    
    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
    }

    void SetMoveDirection()
    {
        if (Gamepad.current != null)
        {
            //Joystick is a bit funky, but otherwise the dpad is working as intended.
            LRUD[0] = Keyboard.current.aKey.isPressed || Gamepad.current.dpad.left.isPressed ||
                      Gamepad.current.leftStick.value.x < 0
                ? true
                : false;
            LRUD[1] = Keyboard.current.dKey.isPressed || Gamepad.current.dpad.right.isPressed ||
                      Gamepad.current.leftStick.value.x > 0
                ? true
                : false;
            LRUD[2] = Keyboard.current.wKey.isPressed || Gamepad.current.dpad.up.isPressed ||
                      Gamepad.current.leftStick.value.y > 0
                ? true
                : false;
            LRUD[3] = Keyboard.current.sKey.isPressed || Gamepad.current.dpad.down.isPressed ||
                      Gamepad.current.leftStick.value.y < 0
                ? true
                : false;

        }
        else
        {
            LRUD[0] = Keyboard.current.aKey
                .isPressed; //|| Gamepad.current.dpad.left.isPressed  || Gamepad.current.leftStick.value.x < 0 ? true : false;
            LRUD[1] = Keyboard.current.dKey
                .isPressed; //|| Gamepad.current.dpad.right.isPressed || Gamepad.current.leftStick.value.x > 0 ? true : false;
            LRUD[2] = Keyboard.current.wKey
                .isPressed; //|| Gamepad.current.dpad.up.isPressed    || Gamepad.current.leftStick.value.y > 0 ? true : false;
            LRUD[3] = Keyboard.current.sKey
                .isPressed; //|| Gamepad.current.dpad.down.isPressed  || Gamepad.current.leftStick.value.y < 0 ? true : false;

        }

        for (int i = 0; i < LRUD.Length; i++)
        {
            if (LRUD[i] == true && !directions.Contains(dir[i]))
            {
                directions.Add(dir[i]);
            }
            else if (LRUD[i] == false)
            {
                directions.Remove(dir[i]);
            }
        }

        MoveDirection = directions.Count > 0 ? directions.Last() : Vector2.zero;
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