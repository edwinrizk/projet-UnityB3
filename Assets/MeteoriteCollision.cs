using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteCollision : MonoBehaviour
{
	public AudioSource _audioSource;
	public AudioClip _audioClip;
	// Start is called before the first frame update
	void Start()
	{
		_audioSource = gameObject.AddComponent<AudioSource>();
		_audioClip = Resources.Load("bakuhatu64") as AudioClip;
		_audioSource.clip = _audioClip;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		// Si la météorite touche le sol, on la détruit
		if (other.gameObject.CompareTag("Rue"))
		{
			_audioSource.Play();
			Destroy(gameObject);
		}
	}
}
