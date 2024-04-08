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
        public AudioSource audioPlayer;


        private void FixedUpdate()
        {
     
            float v = _joystick.Vertical; //get the vertical value of joystick
            float h = _joystick.Horizontal;//get the horizontal value of joystick
    
       
            Vector3 translate = (new Vector3(h, 0, v) * Time.deltaTime)*Speed;
            transform.Translate(translate);
    
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Coin")
            {
                // Check if coin is detected
                Debug.Log("Coin collected!"); 

                //Play sound when coin is collected
                audioPlayer.Play();

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