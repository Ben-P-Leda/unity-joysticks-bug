using UnityEngine;

public class AvatarController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public int AxisIndex;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 inputDirection = MovementDirection();

        Vector3 velocity = _rigidbody.velocity * Drag;
        velocity += (inputDirection * Acceleration);

        velocity = Vector3.ClampMagnitude(velocity, Max_Speed);

        _rigidbody.velocity = velocity;   
    }

    private Vector3 MovementDirection()
    {
        return (AxisIndex >= 0)
            ? new Vector3(Input.GetAxis("Joystick " + (AxisIndex + 1) + " Horizontal"), 0.0f, -Input.GetAxis("Joystick " + (AxisIndex + 1) + " Vertical"))
            : Vector3.zero;
    }

    private const float Acceleration = 2.0f;
    private const float Drag = 0.85f;
    private const float Max_Speed = 7.5f;
}
