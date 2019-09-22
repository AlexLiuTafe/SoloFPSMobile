using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCheck : MonoBehaviour
{
	SphereCollider sphereCol;
	public GameObject gameStartText;
	public GameObject spawnMaster;
	

	private void Start()
	{
		
		sphereCol = GameObject.Find("Gate").GetComponent<SphereCollider>();
	}
	private void OnTriggerEnter(Collider other)
	{
		spawnMaster.SetActive(true);
		gameStartText.SetActive(true);
		Destroy(sphereCol);
		gameObject.SetActive(false);
		Debug.Log("Game Has Started");
		

	}
	
}
