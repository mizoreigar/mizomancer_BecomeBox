/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

	#region Variables
	public GameObject canvas;
	public GameObject deathEffect;
	public Controller2D movement;
	public GameObject death;
	AudioSource[] sounds;
	public Renderer rend;
	public BoxCollider2D box;
	public GameManager gameManager;
	public GameObject deathEffect1;
	int n = 0;


	#endregion

	#region Unity Methods

	private void Start()
	{
		sounds = GetComponents<AudioSource>();
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		box = GetComponent<BoxCollider2D>();
		box.enabled = true;
		canvas.SetActive(false);
		deathEffect1.SetActive(false);
	}
	

	private void OnCollisionEnter2D(Collision2D collisionInfo)
	{
	
			
		if (collisionInfo.collider.tag == "obstacle" && n==0)
		{
			n++;
			deathEffect1.SetActive(true);
			rend.enabled = false;
			box.enabled = false;
			GetComponent<PlayerInput>().enabled = false;
			GetComponent<player>().enabled = false;
			sounds[1].Play();
			gameObject.layer = LayerMask.NameToLayer("Player");

		   FindObjectOfType<GameManager>().EndGame();

		}

		if (collisionInfo.collider.tag == "completelevel")
		{
			
			GetComponent<player>().enabled = false;
            box.enabled = false;
            canvas.SetActive(true);
			gameObject.layer = LayerMask.NameToLayer("Player");
			FindObjectOfType<GameManager>().LevelPass();
		}

		
	}

	private void OnCollisionExit2D(Collision2D collisionInfo)
	{

		if (collisionInfo.collider.tag == "endgame" && n == 0)
		{
			n++;
			deathEffect1.SetActive(true);
			rend.enabled = false;
			box.enabled = false;
			GetComponent<PlayerInput>().enabled = false;
			GetComponent<player>().enabled = false;
			sounds[1].Play();
			gameObject.layer = LayerMask.NameToLayer("Player");
            FindObjectOfType<GameManager>().EndGame();
         
		}
	}
		#endregion
	}
