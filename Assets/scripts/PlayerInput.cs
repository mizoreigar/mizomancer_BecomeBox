using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(player))]
public class PlayerInput : MonoBehaviour
{
	player player;

	void Start()
	{
		player = GetComponent<player>();
	}

	void Update()

	{
		//Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		Vector2 directionalInput = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal"),CrossPlatformInputManager.GetAxisRaw("Vertical"));
		player.SetDirectionalInput(directionalInput);

		if (Input.GetKeyDown(KeyCode.Space))
		{
		
			player.OnJumpInputDown();
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			
			player.OnJumpInputUp();
		}

	/*	if (CrossPlatformInputManager.GetButtonDown("Jump"))
		{

			player.OnJumpInputDown();
		}
		if ((CrossPlatformInputManager.GetButtonDown("Jump")))
		{
		
			player.OnJumpInputUp();
		}
*/

	}
}