using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
	private float time = 0;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		// timer de 3 minutes
		if (Time.timeSinceLevelLoad > 180)
		{
			// On affiche le message de fin de partie
			Debug.Log("Fin de partie");
			// On arr?te le jeu
			Time.timeScale = 0;
		}
		// affiche le temps restant toutes les secondes
		if (Time.timeSinceLevelLoad > time + 1)
		{
			Debug.Log("Temps restant: " + (180 - Time.timeSinceLevelLoad));
			time = Time.timeSinceLevelLoad;
		}
	}
}
