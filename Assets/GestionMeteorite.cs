using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionMeteorite : MonoBehaviour
{
	public GameObject meteoritePrefab;
	public GameObject[] meteoriteTab;
	public float nextMeteoriteTime = 0;
	public float meteoriteAppearanceInterval = 1;
	public int nbMeteoriteMax = 10;

	void Start()
	{
		// On charge la m�t�orite via le prefab
		meteoritePrefab = Resources.Load("Prefabs/Meteorite") as GameObject;

		// On cr�e un tableau de m�t�orites
		meteoriteTab = new GameObject[nbMeteoriteMax];
	}

	void Update()
	{
		// On fait appar�tre une m�t�orite toutes les 1 � 3 secondes
		if (Time.time > nextMeteoriteTime)
		{
			// On cherche une entr�e vide dans le tableau
			int emptyIndex = -1;
			for (int i = 0; i < meteoriteTab.Length; i++)
			{
				if (meteoriteTab[i] == null)
				{
					emptyIndex = i;
					break;
				}
			}

			// Si on a trouv� une entr�e vide, on cr�e une nouvelle m�t�orite
			if (emptyIndex >= 0)
			{
				// On cr�e une m�t�orite
				GameObject m = Instantiate(meteoritePrefab);
				// On la place al�atoirement
				m.transform.position = new Vector3(Random.Range(-100, 100), 10, Random.Range(-100, 100));
				// On l'affiche
				m.SetActive(true);
				// On l'ajoute � la liste des m�t�orites
				meteoriteTab[emptyIndex] = m;
			}

			// On met � jour le temps pour la prochaine m�t�orite
			nextMeteoriteTime = Time.time + meteoriteAppearanceInterval;
			meteoriteAppearanceInterval = Random.Range(1, 3);
		}

		// On fait tomber les m�t�orites
		for (int i = 0; i < meteoriteTab.Length; i++)
		{
			if (meteoriteTab[i] != null)
			{
				meteoriteTab[i].transform.Translate(5 * Time.deltaTime * Vector3.down);
			}
		}

		// On d�truit les m�t�orites qui touchent le sol
		for (int i = 0; i < meteoriteTab.Length; i++)
		{
			if (meteoriteTab[i] != null && meteoriteTab[i].transform.position.y < 0)
			{
				Destroy(meteoriteTab[i]);
				meteoriteTab[i] = null;
			}
		}
	}
}


