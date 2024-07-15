using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _transform;
    private Character _character;

    private void Awake()
    {
        _character = new Character();
        _transform = GetComponent<Transform>();

        _character.CharacterMovement.Move.performed += OnMove;
        _character.CharacterMovement.ColorChange.performed += ChangeColor;
    }

    private void OnEnable()
    {
        _character.Enable();

        _character.CharacterMovement.Move.performed += OnMove;
        _character.CharacterMovement.ColorChange.performed += ChangeColor;
    }

    private void OnDisable()
    {
        _character.CharacterMovement.Move.performed -= OnMove;
        _character.CharacterMovement.ColorChange.performed -= ChangeColor;

        _character.Disable();
    }

    private void ChangeColor(InputAction.CallbackContext context)
    {
        Debug.Log("Click");
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector3 moveDirecion = context.action.ReadValue<Vector3>();

        _transform.position += moveDirecion;
    }
}
