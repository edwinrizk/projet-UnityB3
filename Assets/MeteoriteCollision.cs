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
		// Si la m�t�orite entre en collision avec le sol, on la d�truit
		if (collision.gameObject.CompareTag("Rue"))
		{
			Destroy(gameObject);
		}
	}
}
