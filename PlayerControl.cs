using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {	

	public GameControlScript control;
	CharacterController controller;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;

	public CountdownScript count;  
	public PauseMenuScript pause;  

	public AudioSource powerupCollectSound;
	public AudioSource jumpSound;
	public AudioSource snagCollectSound;

	#if UNITY_ANDROID
	Vector3 zeroAcc;  //zero reference input.acceleration
	Vector3 currentAcc;  //In-game input.acceleration
	float sensitivityH = 3; //alter this to change the sensitivity of the accelerometer
	float smooth = 0.5f; //determines how smooth the acceleration(horizontal movement, in our case) control is
	float GetAxisH = 0;  //variable used to hold the value equivalent to Input.GetAxis("Horizontal")
	#endif


	void Start () {
		controller = GetComponent<CharacterController>();
		#if UNITY_ANDROID
		zeroAcc = Input.acceleration;
		currentAcc = Vector3.zero;
		#endif
	}


	void Update (){		
		#if UNITY_ANDROID
		currentAcc = Vector3.Lerp(currentAcc, Input.acceleration-zeroAcc, Time.deltaTime/smooth);
		GetAxisH = Mathf.Clamp(currentAcc.x * sensitivityH, -1, 1);
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
		if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
		fingerCount++; 
		}
		#endif
		if (controller.isGrounded && count.isCountDown  ) {
			
			GetComponent<Animation> ().Play ("Run");          

			if(pause.paused==false)
				gameObject.GetComponent<AudioSource>().enabled = true;
			else
				gameObject.GetComponent<AudioSource>().enabled = false;
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);  
			#if UNITY_ANDROID
			moveDirection = new Vector3(GetAxisH, 0, 0);
			#endif
			moveDirection = transform.TransformDirection(moveDirection);  
			moveDirection *= speed;             

			jumpSound.Stop();
			#if UNITY_ANDROID
			if (fingerCount >= 1){
			GetComponent<Animation>().Stop("run");
			GetComponent<Animation> ().Play ("jump_pose");

			jumpSound.Play();
			gameObject.GetComponent<AudioSource>().enabled = false;
			moveDirection.y = jumpSpeed;
			}
			#endif
			if (Input.GetButton ("Jump")) {          
				GetComponent<Animation>().Stop("run");
				GetComponent<Animation> ().Play ("jump_pose");

				jumpSound.Play();
				gameObject.GetComponent<AudioSource>().enabled = false;
				moveDirection.y = jumpSpeed;         
			}
			//if(controller.isGrounded)           //set the flag isGrounded to true if character is grounded
				//isGrounded = true;
		}


		if(control.isGameOver){ 
			gameObject.GetComponent<AudioSource>().enabled = false;
		}

		moveDirection.y -= gravity * Time.deltaTime;         
		controller.Move(moveDirection * Time.deltaTime);      
	}


	void OnTriggerEnter(Collider other)
	{               
		if(other.gameObject.CompareTag("PowerUp"))
		{
			powerupCollectSound.Play();  
			control.PowerupCollected();
		}
		else if(other.gameObject.CompareTag("Obstacle"))
		{
			snagCollectSound.Play();  
			control.Obstacles();
		}

		Destroy(other.gameObject);

	}


}