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
            public AudioClip coinCollectSound, winSound, gameOverSound;

        public float fallThreshold = -2f; 
        private bool isGameOver = false;
        public GameObject gameOverText;

    public GameObject joystick;




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
                audioPlayer.clip = coinCollectSound;
                audioPlayer.Play();

                    //Deactivate the coin when collided
                    other.gameObject.SetActive(false);
                    score++;

                    //You win text display
                    if (score >= winScore)
                    {
                        //Hide Joystick
                        joystick.SetActive(false);

                        

                        // Play audio clip
                        audioPlayer.clip = winSound;
                        audioPlayer.Play();

                        //Display text
                        winText.SetActive(true);
                    }
                }
            }
        void Update()
        {
            // Check if the game is already over to avoid redundant checks
            if (!isGameOver)
            {
                // Check if the ball falls below the threshold
                if (transform.position.y < fallThreshold)
                {
            
                    GameOver();
                }
            }
        }

        void GameOver()
        {
            // Set the game over flag to true to prevent redundant game over calls
            isGameOver = true;

            //Hide joystick
            joystick.SetActive(false);

            

        //Play sound
        audioPlayer.clip = gameOverSound;
            audioPlayer.Play();

            //Display text
            gameOverText.SetActive(true);
        }
    }