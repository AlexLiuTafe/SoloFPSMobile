using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	[Header("Reference")]
	public MasterController _moveJoystick;
	private CharacterController _charC;
	//private Rigidbody rigid;

	[Header("Attributes")]
	private float _currentSpeed;
    public float _movementSpeed = 5f;
	public float _dashSpeed = 10f;
	public float _dashTime = 2f;
	private Vector3 _motion;

	[Header("Health")]
	public float health = 100f;
	public Text healthText;

	
	private void Start()
    {
		//rigid = GetComponent<Rigidbody>();
		_currentSpeed = _movementSpeed;
		_charC = GetComponent<CharacterController>();
		
    }
    private void Update()
	{
		healthText.text = Mathf.Round(health).ToString();
		float inputH = _moveJoystick.Horizontal;
		float inputV = _moveJoystick.Vertical;
		Vector3 inputDir = new Vector3(inputH, 0f, inputV);
		inputDir = transform.TransformDirection(inputDir);
		if(inputDir.magnitude>1f)
		{
			inputDir.Normalize();
		}
		Move(inputDir.x,inputDir.z,_currentSpeed);
		_charC.Move(_motion *Time.deltaTime);
		
    }
	#region FUNCTION
	private void Move(float inputH,float inputV,float speed)
    {
		Vector3 direction = new Vector3(inputH, 0, inputV);
		_motion.x = direction.x * speed;
		_motion.z = direction.z * speed;
			
	}
	//public void Dash()
	//{
	//	StartCoroutine(DashIE(_dashSpeed, _movementSpeed, _dashTime));
	//}
	public void TakeDamage(float damage)
	{
		health -= damage;
		Debug.Log("Player Take damage" + " " + damage);
		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}
	#endregion
	#region IENumerator
	//IEnumerator DashIE(float startDash,float endDash, float delay)
	//{
	//	_currentSpeed = startDash;
	//	yield return new WaitForSeconds(delay);
	//	_currentSpeed = endDash;
	//}
	#endregion
}
