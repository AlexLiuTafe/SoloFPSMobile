using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	[Header("Attributes")]
	private float _shootTimer;
	public float shootRate = 1f;
	public float bulletSpeed = 20f;
	public GameObject bulletPrefab;
	public Transform bulletClone;	
	private void Start()
	{
		//GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
		

	}
	public void Attack()
	{
		if(Time.time > _shootTimer)
		{
			//																						  Make bullet always facing camera direction
			GameObject bulletGO = GameObject.Instantiate(bulletPrefab, Camera.main.transform.position, Camera.main.transform.rotation);
			Bullet bullet = bulletGO.GetComponent<Bullet>();
			bullet.transform.position = transform.position + Camera.main.transform.forward * 2; //Make the bullet spawn abit further from player so doesnt collide with player
			Rigidbody rigid = bullet.GetComponent<Rigidbody>();
			rigid.velocity = Camera.main.transform.forward * bulletSpeed;
			bullet.transform.SetParent(bulletClone);
			_shootTimer = Time.time + shootRate;
		}
		

	}
	
}
