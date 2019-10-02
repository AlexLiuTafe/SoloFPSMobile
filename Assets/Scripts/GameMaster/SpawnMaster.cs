using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMaster : MonoBehaviour
{
	public GameObject enemy;
	public Transform[] spawnPoints;
	private Transform spawnParent;//for storing purpose
	private float spawnTimer;
	public float spawnRate;

	private void Awake()
	{
		//get gameobject children position
		spawnPoints = new Transform[transform.childCount];
		for (int i = 0; i < spawnPoints.Length; i++)
		{
			//loop through all the children
			spawnPoints[i] = transform.GetChild(i);
		}
	}
	private void Start()
	{
		spawnTimer = 7f;
		spawnParent = GameObject.Find("EnemyClones").GetComponent<Transform>();//Find gameobject named EnemyClones and get the transform component
	}
	// Update is called once per frame
	void Update()
	{
		//Time.time always going up 
		if (Time.time > spawnTimer)
		{
			Spawn();
			//Reset timer
			spawnTimer = Time.time + spawnRate;
			
		}
	}
	void Spawn()
	{
		//Storing a random value from the spawnpoint length
		int randomPos = Random.Range(0, spawnPoints.Length);
		//Storing prefab as a GameObject
		GameObject clone = Instantiate(enemy, spawnPoints[randomPos].position, Quaternion.identity);
		//Storing the GameObject in an empty gameobject in a hierarchy
		clone.transform.SetParent(spawnParent);
	}
}
