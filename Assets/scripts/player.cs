using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class player : MonoBehaviour
{

	public float maxJumpHeight = 6;
	public float minJumpHeight = 3;
	public float timeToJumpApex = 0f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .00000000f;
	float moveSpeed = 20;

	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;
	bool doubleJump = false;

	public float wallSlideSpeedMax = 5;
	public float wallStickTime = .25f;
	float timeToWallUnstick;

	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;
	//public GameObject jump;
	Controller2D controller;
	AudioSource [] sounds;
	
	Vector2 directionalInput;
	bool wallSliding;
	int wallDirX;

	private void Awake()
	{
		
	}
	void Start()
	{
		controller = GetComponent<Controller2D>();
		sounds = GetComponents<AudioSource>();
		
		gravity = -(2.5f * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
		//minJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
	}

	void Update()
	{
		Time.timeScale = 0.70f;
		CalculateVelocity();
		HandleWallSliding();
		controller.Move(velocity * Time.deltaTime, directionalInput);


		if (controller.collisions.above || controller.collisions.below)
		{

			if (controller.collisions.slidingDownMaxSlope)
			{
				velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;

			}
			else
			{
				velocity.y = 0;
			}
		}

		
	}
	public void SetDirectionalInput(Vector2 input)
	{
		directionalInput = input;
		

	}

	public void OnJumpInputDown()
	{
		

			if (controller.collisions.below)
			{
				velocity.y = maxJumpVelocity;
				doubleJump = true;
			}
			else if (doubleJump)
			{
				//double jumps the player
				doubleJump = false;
				velocity.y = maxJumpVelocity;
				sounds[0].Play();
			}
			

		if (wallSliding)
		{

			if (wallDirX == directionalInput.x)
			{
				sounds[0].Play();
				//Destroy(Instantiate(jump.gameObject), 0.1f);
				velocity.x = -wallDirX * wallJumpClimb.x;
				velocity.y = wallJumpClimb.y;
			}
			else if (directionalInput.x == 0)
			{
				velocity.x = -wallDirX * wallJumpOff.x;
				velocity.y = wallJumpOff.y;
				//Destroy(Instantiate(jump.gameObject), 0.1f);
				sounds[0].Play();
			}
			else
			{
				velocity.x = -wallDirX * wallLeap.x;
				velocity.y = wallLeap.y;
				//Destroy(Instantiate(jump.gameObject), 0.1f);
				sounds[0].Play();
			}
		}
		if (controller.collisions.below)
		{
			sounds[0].Play();
			//Destroy(Instantiate(jump.gameObject), 0.1f);
			if (controller.collisions.slidingDownMaxSlope)
			{
				if (directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x))
				{ // not jumping against max slope
					velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
					velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;

				}
			}
			else
			{
				velocity.y = maxJumpVelocity;
			}

		}
	}

	public void OnJumpInputUp()
	{
		
		if (velocity.y > minJumpVelocity)
		{
			velocity.y = minJumpVelocity;
		}

	}


	void HandleWallSliding()
	{
		wallDirX = (controller.collisions.left) ? -1 : 1;
		wallSliding = false;
		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
		{
			wallSliding = true;

			if (velocity.y < -wallSlideSpeedMax)
			{
				velocity.y = -wallSlideSpeedMax;
			}

			if (timeToWallUnstick > 0)
			{
				velocityXSmoothing = 0;
				velocity.x = 0;

				if (directionalInput.x != wallDirX && directionalInput.x != 0)
				{
					timeToWallUnstick -= Time.deltaTime;
				}
				else
				{
					timeToWallUnstick = wallStickTime;
				}
			}
			else
			{
				timeToWallUnstick = wallStickTime;
			}

		}

	}

	void CalculateVelocity()
	{
		float targetVelocityX = directionalInput.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
	}
}