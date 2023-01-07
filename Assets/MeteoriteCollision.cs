using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision collision)
	{
		// Si la météorite entre en collision avec le sol, on la détruit
		if (collision.gameObject.CompareTag("Rue"))
		{
			Destroy(gameObject);
		}
	}
}
