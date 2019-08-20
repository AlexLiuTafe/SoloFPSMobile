using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Reference")]
	public MasterController _moveJoystick;
	private CharacterController _charC;
	
	[Header("Attributes")]
	private float _currentSpeed;
    public float _movementSpeed = 5f;
	public float _dashSpeed = 10f;
	public float _dashTime = 2f;
	private Vector3 _motion;
    

	
	private void Start()
    {
		_currentSpeed = _movementSpeed;
		_charC = GetComponent<CharacterController>();
		
    }
    private void Update()
	{
		Move(_currentSpeed);
		_charC.Move(_motion *Time.deltaTime);
    }

    private void Move(float speed)
    {
		Vector3 direction = new Vector3(_moveJoystick.Horizontal, 0, _moveJoystick.Vertical);
		_motion.x = direction.x * speed;
		_motion.z = direction.z * speed;
		if(direction.magnitude >1f)
		{
			direction.Normalize();
		}
		
	}
	private void Dash()
	{
		StartCoroutine(DashIE(_dashSpeed, _movementSpeed, _dashTime));
	}
	#region IENumerator
	IEnumerator DashIE(float startDash,float endDash, float delay)
	{
		_currentSpeed = startDash;
		yield return new WaitForSeconds(delay);
		_currentSpeed = endDash;
	}
	#endregion
}
