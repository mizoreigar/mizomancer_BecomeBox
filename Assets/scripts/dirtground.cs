/*
*  Copyright (c) Mizoreigar
*
*/
using UnityEngine;

public class dirtground : MonoBehaviour {

	#region Variables
	//public GameObject dirtparticle;
	public Renderer rend;
	public BoxCollider2D box;
	AudioSource[] sounds;
	public float destroySpeed = 0.8f;
	public float particleDestroy = 0.6f;
	public GameObject dirteffect;
	#endregion

	#region Unity Methods

	void Start () 
	{
		sounds = GetComponents<AudioSource>();
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		box = GetComponent<BoxCollider2D>();
		box.enabled = true;
		dirteffect.SetActive(false);

	}
	
	
	void Update () 
	{
		
	}

	private void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (collisionInfo.collider.tag == "Player")
		{
			Invoke("Destroydirt", destroySpeed);
			//Destroy(gameObject, destroySpeed);	
			Invoke("particleDirt", particleDestroy);
			dirteffect.SetActive(true);


		}
	}

	void particleDirt()
	{
		dirteffect.SetActive(true);
		sounds[0].Play();
	}

	void Destroydirt()
	{
		rend = GetComponent<Renderer>();
		rend.enabled = false;
		box = GetComponent<BoxCollider2D>();
		box.enabled = false;
	}
	#endregion
}
