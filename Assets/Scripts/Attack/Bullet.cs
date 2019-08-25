using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float damage = 10f;
	private void OnTriggerEnter(Collider col)
	{
		Enemy enemy = col.GetComponent<Enemy>();
	
		if(enemy)
		{
			Destroy(gameObject);
			enemy.TakeDamage(damage);
		}
		
			Destroy(gameObject);
		
	}
}
