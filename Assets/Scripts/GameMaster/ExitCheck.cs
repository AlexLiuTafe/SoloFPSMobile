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
		//Find gameobject name Gate and get the Collider Component
		sphereCol = GameObject.Find("Gate").GetComponent<SphereCollider>();
	}
	private void OnTriggerEnter(Collider other)
	{
		//When collide*
		spawnMaster.SetActive(true); //set spawnmaster gameobject to true
		gameStartText.SetActive(true);//set game start text gameobject to true
		Destroy(sphereCol);//Destroy the collider so it does not open the door again when player already in the field
		gameObject.SetActive(false);//Just incase* disable the gameobject
		Debug.Log("Game Has Started");
		

	}
	
}
