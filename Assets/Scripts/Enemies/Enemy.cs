using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	[Header("Attributes")]
	public float health = 70f;

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
	private void OnDrawGizmos()
	{
		
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackCol.position, attackRadius);
	}
	private void Start()
	{
		_agent = GetComponent<NavMeshAgent>();
		_player = GameObject.FindGameObjectWithTag("Player");
		_target = _player.transform;
	}
	private void Update()
	{
		float distance = Vector3.Distance(_target.position, transform.position);

		
			_agent.SetDestination(_target.position);
		
		if(distance <=attackRange)
		{
			Attack();
			LookAtTarget();
		}
	}
	#region FUNCTION
	public void TakeDamage(float damage)
	{
		health -= damage;
		Debug.Log("Enemy Take Damage" + " " + damage);
		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void Attack()
	{

		Collider[] hits = Physics.OverlapSphere(attackCol.position, attackRadius);
		foreach (var hit in hits)
		{
			PlayerMovement player = hit.GetComponent<PlayerMovement>();
			if(player)
			{
				if(Time.time >= _attackTimer)
				{
					player.TakeDamage(damage);
					_attackTimer = Time.time + attackRate;
				}
			}

		}
		
	}
	private void LookAtTarget()
	{
		Vector3 direction = (_target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 4f);
	}
	#endregion
}
