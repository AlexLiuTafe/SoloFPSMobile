using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float damage; 
	private Enemy enemy;
	private void Start()
	{
		enemy = GetComponent<Enemy>(); //Get the component from Enemy script
	}
	private void OnTriggerEnter(Collider col)
	{
		//random value between 5 and 10
		damage = Random.Range(5f, 10f);
		// Getiing enemy collider from the gameobject that has enemy script
		Enemy enemy = col.GetComponent<Enemy>();
	
		if(enemy)
		{
			//DamagePop.Create(enemy.transform.position, damage);
			Destroy(gameObject); //Destroy gameobject when hit enemy
			enemy.TakeDamage(damage); //Enemy taking damage when hit by the bullet
		}
			//Destoy bullet when hit another collider beside enemy
			Destroy(gameObject);
		
	}
}
