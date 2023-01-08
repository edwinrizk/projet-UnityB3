using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionMeteorite : MonoBehaviour
{
	public GameObject _meteoritePrefab;
	public GameObject[] _meteoriteTab;
	public float _nextMeteoriteTime = 0;
	public float _meteoriteAppearanceInterval = 1;
	public int _nbMeteoriteMax = 10;

	void Start()
	{
		// On charge la météorite via le prefab
		_meteoritePrefab = Resources.Load("Prefabs/Meteorite") as GameObject;

		// On crée un tableau de météorites
		_meteoriteTab = new GameObject[_nbMeteoriteMax];
	}

	void Update()
	{
		// On fait apparêtre une météorite toutes les 1 à 3 secondes
		if (Time.time > _nextMeteoriteTime)
		{
			// On cherche une entrée vide dans le tableau
			int emptyIndex = -1;
			for (int i = 0; i < _meteoriteTab.Length; i++)
			{
				if (_meteoriteTab[i] == null)
				{
					emptyIndex = i;
					break;
				}
			}

			// Si on a trouvé une entrée vide, on crée une nouvelle météorite
			if (emptyIndex >= 0)
			{
				// On crée une météorite
				GameObject m = Instantiate(_meteoritePrefab, transform);
				// On la place aléatoirement
				m.transform.position += new Vector3(Random.Range(-94, 94), 20, Random.Range(0, 150));
				// On l'affiche
				m.SetActive(true);
				// On l'ajoute à la liste des météorites
				_meteoriteTab[emptyIndex] = m;
			}

			// On met à jour le temps pour la prochaine météorite
			_nextMeteoriteTime = Time.time + _meteoriteAppearanceInterval;
			_meteoriteAppearanceInterval = Random.Range(1, 3);
		}

		// On fait tomber les météorites
		/*
		for (int i = 0; i < _meteoriteTab.Length; i++)
		{
			if (_meteoriteTab[i] != null)
			{
				_meteoriteTab[i].transform.Translate(10 * Time.deltaTime * Vector3.down);
			}
		}
		*/

		// On détruit les météorites à la collision avec le sol
		for (int i = 0; i < _meteoriteTab.Length; i++)
		{
			if (_meteoriteTab[i] != null && _meteoriteTab[i].transform.position.y < 0)
			{
				Destroy(_meteoriteTab[i]);
				_meteoriteTab[i] = null;
			}
		}
	}
}


