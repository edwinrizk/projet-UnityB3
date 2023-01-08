using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GestionVoiture : MonoBehaviour
{
	public GameObject[] _voiturePrefab;
	public GameObject[] _voitureTab;
	public float _nextVoitureTime = 0;
	public float _voitureAppearanceInterval = 0.20f;
	public int _nbVoitureMax = 35;
	
	// Start is called before the first frame update
	void Start()
	{
		// On charge toutes les voitures
		_voiturePrefab = new GameObject[8];
		_voiturePrefab[0] = Resources.Load("Simple Vehicle Pack/Prefabs/Bus_1") as GameObject;
		_voiturePrefab[1] = Resources.Load("Simple Vehicle Pack/Prefabs/Bus_2") as GameObject;
		_voiturePrefab[2] = Resources.Load("Simple Vehicle Pack/Prefabs/Car_1") as GameObject;
		_voiturePrefab[3] = Resources.Load("Simple Vehicle Pack/Prefabs/Car_2") as GameObject;
		_voiturePrefab[4] = Resources.Load("Simple Vehicle Pack/Prefabs/Car_3") as GameObject;
		_voiturePrefab[5] = Resources.Load("Simple Vehicle Pack/Prefabs/Car_4") as GameObject;
		_voiturePrefab[6] = Resources.Load("Simple Vehicle Pack/Prefabs/Police_car") as GameObject;
		_voiturePrefab[7] = Resources.Load("Simple Vehicle Pack/Prefabs/Taxi") as GameObject;

		// On crée un tableau de voitures
		_voitureTab = new GameObject[_nbVoitureMax];
	}

	// Update is called once per frame
	void Update()
	{
		// On fait apparêtre une voiture toutes les 1 à 3 secondes
		if (Time.time > _nextVoitureTime)
		{
			// On cherche une entrée vide dans le tableau
			int emptyIndex = -1;
			for (int i = 0; i < _voitureTab.Length; i++)
			{
				if (_voitureTab[i] == null)
				{
					emptyIndex = i;
					break;
				}
			}

			// Si on a trouvé une entrée vide, on crée une nouvelle voiture
			if (emptyIndex >= 0)
			{
				// On choisit une voiture au hasard
				int voitureIndex = Random.Range(0, _voiturePrefab.Length);
				// On crée une voiture enfant de la route
				GameObject v = Instantiate(_voiturePrefab[voitureIndex], transform);
				// On la place aléatoirement par rapport à la route parente
				v.transform.localPosition += new Vector3(Mathf.Round(Random.Range(-1f, 1f)), 0.09f, 95f);
				// On le fait tourner à 180°
				v.transform.Rotate(0, 180, 0);
				// On l'affiche
				v.SetActive(true);
				// On l'ajoute à la liste des voitures
				_voitureTab[emptyIndex] = v;
			}

			// On met à jour le temps pour la prochaine voiture
			_nextVoitureTime = Time.time + _voitureAppearanceInterval;
			_voitureAppearanceInterval = Random.Range(0.30f,1);
		}

		// On fait avancer les voitures sur l'axe z
		for (int i = 0; i < _voitureTab.Length; i++)
		{
			if (_voitureTab[i] != null)
			{
				_voitureTab[i].transform.Translate(40 * Time.deltaTime * Vector3.forward);
			}
		}

		// On supprime les voitures qui sont sorties de la zone parente
		for (int i = 0; i < _voitureTab.Length; i++)
		{
			if (_voitureTab[i] != null && _voitureTab[i].transform.localPosition.z < -96f)
			{
				Destroy(_voitureTab[i]);
				_voitureTab[i] = null;
			}
		}
	}
}
