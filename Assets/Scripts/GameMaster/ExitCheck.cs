using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCheck : MonoBehaviour
{
	SphereCollider sphereCol;
	public GameObject spawnMaster;

	private void Start()
	{
		
		sphereCol = GameObject.Find("Gate").GetComponent<SphereCollider>();
	}
	private void OnTriggerEnter(Collider other)
	{
		spawnMaster.SetActive(true);
		Destroy(gameObject);
		Destroy(sphereCol);
		Debug.Log("Game");
	}
}
