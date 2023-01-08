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
		// On charge la m�t�orite via le prefab
		_meteoritePrefab = Resources.Load("Prefabs/Meteorite") as GameObject;

		// On cr�e un tableau de m�t�orites
		_meteoriteTab = new GameObject[_nbMeteoriteMax];
	}

	void Update()
	{
		// On fait appar�tre une m�t�orite toutes les 1 � 3 secondes
		if (Time.time > _nextMeteoriteTime)
		{
			// On cherche une entr�e vide dans le tableau
			int emptyIndex = -1;
			for (int i = 0; i < _meteoriteTab.Length; i++)
			{
				if (_meteoriteTab[i] == null)
				{
					emptyIndex = i;
					break;
				}
			}

			// Si on a trouv� une entr�e vide, on cr�e une nouvelle m�t�orite
			if (emptyIndex >= 0)
			{
				// On cr�e une m�t�orite
				GameObject m = Instantiate(_meteoritePrefab, transform);
				// On la place al�atoirement
				m.transform.position += new Vector3(Random.Range(-94, 94), 20, Random.Range(0, 150));
				// On l'affiche
				m.SetActive(true);
				// On l'ajoute � la liste des m�t�orites
				_meteoriteTab[emptyIndex] = m;
			}

			// On met � jour le temps pour la prochaine m�t�orite
			_nextMeteoriteTime = Time.time + _meteoriteAppearanceInterval;
			_meteoriteAppearanceInterval = Random.Range(1, 3);
		}

		// On fait tomber les m�t�orites
		/*
		for (int i = 0; i < _meteoriteTab.Length; i++)
		{
			if (_meteoriteTab[i] != null)
			{
				_meteoriteTab[i].transform.Translate(10 * Time.deltaTime * Vector3.down);
			}
		}
		*/

		// On d�truit les m�t�orites � la collision avec le sol
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


