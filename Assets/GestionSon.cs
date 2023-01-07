using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSon : MonoBehaviour
{
	public AudioSource _audioSource;
	public AudioClip _audioClip;
	
	// Start is called before the first frame update
	void Start()
	{
		_audioSource = gameObject.AddComponent<AudioSource>();
		_audioClip = Resources.Load("Vehicle_Car_Drive_Exterior_Short_Loop") as AudioClip;
		_audioSource.clip = _audioClip;
		_audioSource.Play();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
