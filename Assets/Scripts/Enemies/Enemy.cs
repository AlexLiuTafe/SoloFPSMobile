using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	[Header("Attributes")]
	public float health;

	[Header("Attacking")]
	public float damage = 5f;
	public float attackRadius;
	public float attackRange;
	private float _attackTimer;
	public float attackRate = 1.5f;

	[Header("Reference")]
	public Transform _target;
	private GameObject _player;
	private NavMeshAgent _agent;
	public Transform attackCol;
	public Text healthText;

	private void OnDrawGizmos()
	{

		Gizmos.color = Color.red; //Set gizmos color as red
		Gizmos.DrawWireSphere(attackCol.position, attackRadius); //Show a sphere gizmos for the attack range
	}
	private void Start()
	{
		float randHealth = Random.Range(15f, 30f); //Random health when spawned
		health = randHealth; // assign health from the random value
		_agent = GetComponent<NavMeshAgent>(); //Get Meshagent component
		_player = GameObject.FindGameObjectWithTag("Player"); //Find game object with the tag Player
		_target = _player.transform; //Set the target position
	}
	private void Update()
	{
		//getting the direction from the target and the enemy
		float distance = Vector3.Distance(_target.position, transform.position);
		//make the enemy chase to the target
		_agent.SetDestination(_target.position);
		//set text and convert it into string
		healthText.text = Mathf.Round(health).ToString();

		if (distance <= attackRange) // Checking attack range
		{
			Attack(); // Call the attack function
			LookAtTarget(); //Call the LookAtTarget function
		}
	}
	#region FUNCTION
	public void TakeDamage(float damage)
	{
		health -= damage;//reduce health base on the damage dealt
		Debug.Log("Enemy Take Damage" + " " + damage);
		if (health <= 0)
		{
			//if health less than 0 destroy the gameobject
			Destroy(gameObject);
		}
	}

	private void Attack()
	{
		//Get all colliders and make an overlapsphere at the enemy position and set the radius
		Collider[] hits = Physics.OverlapSphere(attackCol.position, attackRadius);
		foreach (var hit in hits)
		{
			//Get the gameobject that has Playermovement script
			PlayerMovement player = hit.GetComponent<PlayerMovement>();
			if (player)
			{
				if (Time.time >= _attackTimer)
				{
					//Make the player take damage (enemy is attacking)
					player.TakeDamage(damage);
					//Reset the timer
					_attackTimer = Time.time + attackRate;
				}
			}

		}

	}
	private void LookAtTarget()
	{
		//Get the direction of the target and enemy
		Vector3 direction = (_target.position - transform.position).normalized;
		//Set the target lookat direction only on X and Z axis (left and right)
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		//Rotate the enemy according to the target position
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 4f);
	}
	#endregion
}
