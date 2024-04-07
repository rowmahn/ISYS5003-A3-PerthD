using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    
    [SerializeField]private float Speed = 5;
    

    int score = 0;
    public int winScore;
    public GameObject winText;


    private void FixedUpdate()
    {
     
    
        //Step #2
        //Change Input.GetAxis (or the input that you using) to Joystick.Vertical or Joystick.Horizontal
        float v = _joystick.Vertical; //get the vertical value of joystick
        float h = _joystick.Horizontal;//get the horizontal value of joystick
    
        //in case you using keys instead of axis (due keys are bool and not float) you can do this:
        //bool isKeyPressed = (Joystick.Horizontal > 0) ? true : false;

        //ready!, you not need more.
        Vector3 translate = (new Vector3(h, 0, v) * Time.deltaTime)*Speed;
        transform.Translate(translate);
    
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