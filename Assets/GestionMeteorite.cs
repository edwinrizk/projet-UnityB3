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
		// On charge la météorite via le prefab
		meteoritePrefab = Resources.Load("Prefabs/Meteorite") as GameObject;

		// On crée un tableau de météorites
		meteoriteTab = new GameObject[nbMeteoriteMax];
	}

	void Update()
	{
		// On fait apparêtre une météorite toutes les 1 à 3 secondes
		if (Time.time > nextMeteoriteTime)
		{
			// On cherche une entrée vide dans le tableau
			int emptyIndex = -1;
			for (int i = 0; i < meteoriteTab.Length; i++)
			{
				if (meteoriteTab[i] == null)
				{
					emptyIndex = i;
					break;
				}
			}

			// Si on a trouvé une entrée vide, on crée une nouvelle météorite
			if (emptyIndex >= 0)
			{
				// On crée une météorite
				GameObject m = Instantiate(meteoritePrefab);
				// On la place aléatoirement
				m.transform.position = new Vector3(Random.Range(-100, 100), 10, Random.Range(-100, 100));
				// On l'affiche
				m.SetActive(true);
				// On l'ajoute à la liste des météorites
				meteoriteTab[emptyIndex] = m;
			}

			// On met à jour le temps pour la prochaine météorite
			nextMeteoriteTime = Time.time + meteoriteAppearanceInterval;
			meteoriteAppearanceInterval = Random.Range(1, 3);
		}

		// On fait tomber les météorites
		for (int i = 0; i < meteoriteTab.Length; i++)
		{
			if (meteoriteTab[i] != null)
			{
				meteoriteTab[i].transform.Translate(5 * Time.deltaTime * Vector3.down);
			}
		}

		// On détruit les météorites qui touchent le sol
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


