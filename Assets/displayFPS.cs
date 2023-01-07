using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayFPS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// On affiche le nombre de FPS
		Debug.Log("FPS: " + (1.0f / Time.deltaTime));
	}
}
