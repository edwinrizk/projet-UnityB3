using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayFPS : MonoBehaviour
{
	private float time = 0;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		// On affiche le nombre de FPS toutes les secondes
		if (Time.timeSinceLevelLoad > time + 1)
		{
			Debug.Log("FPS: " + (1 / Time.deltaTime));
			time = Time.timeSinceLevelLoad;
		}
	}
}
