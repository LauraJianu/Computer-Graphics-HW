using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour {	

	public GameControlScript control;
	CharacterController controller;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	private bool grounded = false;
	public ScoreManager scor;
	public PickupCoins puncte;


	void Start () {
		controller = GetComponent<CharacterController>();
	}
		

	void Update ()
	{				
			if (grounded)
			{				
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;

				if (Input.GetButton ("Jump"))  moveDirection.y = jumpSpeed;
			}			
			moveDirection.y -= gravity * Time.deltaTime;

			CharacterController controller = (CharacterController)GetComponent(typeof(CharacterController));
			CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
			grounded = (flags & CollisionFlags.CollidedBelow) != 0;			
	}		

	void OnTriggerEnter(Collider other)
	{               
		if(other.gameObject.CompareTag("PowerUp"))
		{			 
			control.PowerupCollected();
		}
		else if(other.gameObject.CompareTag("Obstacle"))
		{			 
			control.Obstacles();
		}
		Destroy(other.gameObject);

		if (other.gameObject.CompareTag("coin"))
		{
			scor.AddScore (puncte.puncte);
		}
	}
}

