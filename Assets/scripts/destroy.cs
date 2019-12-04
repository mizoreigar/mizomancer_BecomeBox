using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class destroy : MonoBehaviour
{

	public float destroyTime;
	AudioSource [] sounds;

	// Use this for initialization
	public void Start()
	{
        sounds[0].Play();
        //Destroy(this.gameObject, destroyTime);
    }

	// Update is called once per frame
	void Update()
	{
        
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "cannon" && other.tag != "Player")
			Destroy(this.gameObject,0.1f);

	}
}