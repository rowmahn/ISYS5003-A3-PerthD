using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _moveSpeed;

    int score = 0;
    public int winScore;
    public GameObject winText;


    private void FixedUpdate()
    {
        // Calculate movement direction based on joystick input
        Vector3 movementDirection = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical).normalized;

        // Apply movement force
        _rigidbody.velocity = movementDirection * _moveSpeed;

        // Rotate the player to face the movement direction
        if (movementDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f); // Adjust interpolation value if needed
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("Coin collected!"); // Check if coin is detected
                                          //Deactivate the coin when collided
            other.gameObject.SetActive(false);
            score++;

            //You win text display
            if (score >= winScore)
            {
                winText.SetActive(true);
            }
        }
    }
}