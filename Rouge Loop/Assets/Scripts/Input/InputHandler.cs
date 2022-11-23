using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private UserInput userInput;
    private InputAction buttonNordAction, buttonEastAction, buttonSouthAction, buttonWestAction, movementInputAction;
    private Vector2 movementInput;
    private double buttonNordDuration, buttonEastDuration, buttonSouthDuration, buttonWestDuration;
    private double buttonNordTimeStamp, buttonEastTimeStamp, buttonSouthTimeStamp, buttonWestTimeStamp;
    private bool isButtonNordDown, isButtonEastDown, isButtonSouthDown, isButtonWestDown;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        userInput = new UserInput();
        userInput.Enable();
        if (playerInput.user.index == 0)
        {
            userInput.PlayerActionMap1.Disable();
            userInput.PlayerActionMap.Disable();
            playerInput.SwitchCurrentActionMap("PlayerActionMap");
            print("assign player 0");
            buttonNordAction = userInput.PlayerActionMap.ButtonNord;
            buttonEastAction = userInput.PlayerActionMap.ButtonEast;
            buttonSouthAction = userInput.PlayerActionMap.ButtonSouth;
            buttonWestAction = userInput.PlayerActionMap.ButtonWest;
            movementInputAction = userInput.PlayerActionMap.MovementAction;
            userInput.Disable();
            print(userInput.asset.enabled);

        }

        if (playerInput.user.index == 1)
        {
            playerInput.SwitchCurrentActionMap("PlayerActionMap1");
            userInput.PlayerActionMap.Disable();
            userInput.PlayerActionMap1.Disable();
            print("assign player 1");
            buttonNordAction = userInput.PlayerActionMap1.ButtonNord;
            buttonEastAction = userInput.PlayerActionMap1.ButtonEast;
            buttonSouthAction = userInput.PlayerActionMap1.ButtonSouth;
            buttonWestAction = userInput.PlayerActionMap1.ButtonWest;
            movementInputAction = userInput.PlayerActionMap1.MovementAction;
        }

        buttonNordAction.Enable();
        buttonEastAction.Enable();
        buttonSouthAction.Enable();
        buttonWestAction.Enable();
        movementInputAction.Enable();

        #region Subscribtions to Action.performed

        movementInputAction.performed += context => { movementInput = context.ReadValue<Vector2>(); };

        #endregion

        #region Subscribtions to Action.started

        buttonNordAction.started += context => { isButtonNordDown = context.ReadValueAsButton(); };

        buttonEastAction.started += context => { isButtonEastDown = context.ReadValueAsButton(); };

        buttonSouthAction.started += context => { isButtonSouthDown = context.ReadValueAsButton(); };

        buttonWestAction.started += context => { isButtonWestDown = context.ReadValueAsButton(); };

        #endregion

        #region Subscribtions to Action.canceled

        buttonNordAction.canceled += context =>
        {
            isButtonNordDown = context.ReadValueAsButton();
            buttonNordTimeStamp = buttonNordDuration;
            buttonNordDuration = 0;
        };

        buttonEastAction.canceled += context =>
        {
            isButtonEastDown = context.ReadValueAsButton();
            buttonEastTimeStamp = buttonEastDuration;
            buttonEastDuration = 0;
        };

        buttonSouthAction.canceled += context =>
        {
            isButtonSouthDown = context.ReadValueAsButton();
            buttonSouthTimeStamp = buttonSouthDuration;
            buttonSouthDuration = 0;
        };

        buttonWestAction.canceled += context =>
        {
            isButtonWestDown = context.ReadValueAsButton();
            buttonWestTimeStamp = buttonWestDuration;
            buttonWestDuration = 0;
        };

        #endregion
    }
    private void OnDisable()
    {
        userInput.Disable();
    }

    private void Update()
    {
        SetButtonDurationTimer();
    }

    #region Getter

    public UserInput UserInput => userInput;

    public InputAction ButtonNordAction => buttonNordAction;

    public InputAction ButtonEastAction => buttonEastAction;

    public InputAction ButtonSouthAction => buttonSouthAction;

    public InputAction ButtonWestAction => buttonWestAction;

    public InputAction MovementInputAction => movementInputAction;

    public Vector2 MovementInput => movementInput;

    public double ButtonNordDuration => buttonNordDuration;

    public double ButtonEastDuration => buttonEastDuration;

    public double ButtonSouthDuration => buttonSouthDuration;

    public double ButtonWestDuration => buttonWestDuration;

    public double ButtonNordTimeStamp => buttonNordTimeStamp;

    public double ButtonEastTimeStamp => buttonEastTimeStamp;

    public double ButtonSouthTimeStamp => buttonSouthTimeStamp;

    public double ButtonWestTimeStamp => buttonWestTimeStamp;

    public bool IsButtonNordDown => isButtonNordDown;
    public bool IsButtonEastDown => isButtonEastDown;
    public bool IsButtonSouthDown => isButtonSouthDown;
    public bool IsButtonWestDown => isButtonWestDown;
    public double DurationButtonNord => buttonNordDuration;
    public double DurationButtonEast => buttonEastDuration;
    public double DurationButtonSouth => buttonSouthDuration;
    public double DurationButtonWest => buttonWestDuration;

    #endregion


    private void SetButtonDurationTimer()
    {
        if (isButtonNordDown) buttonNordDuration += Time.deltaTime;

        if (isButtonEastDown) buttonEastDuration += Time.deltaTime;

        if (IsButtonSouthDown) buttonSouthDuration += Time.deltaTime;

        if (IsButtonWestDown) buttonWestDuration += Time.deltaTime;
    }

}