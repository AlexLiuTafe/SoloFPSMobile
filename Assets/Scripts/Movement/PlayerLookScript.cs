﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookScript : MonoBehaviour
{
	[Header("Reference")]
	public MasterController _moveJoystick;
	public RotationalAxis _axis = RotationalAxis.lookX;
	[Header("Sensitivity")]
	[Range(0,5)]
	public float _lookSensitivityX = 1f;
	[Range(0,5)]
	public float _lookSensitivityY = 1f;
	[Header("Y Rotation Clamp")]
	public float _maxY = 60f;
	public float _minY = -60f;

	private float _rotationY = 0;
	
	

	// Update is called once per frame
	void Update()
	{
		// For lookX and lookY (Diagonal Input)
		if(_axis == RotationalAxis.lookXandY)
		{
			//Rotate the player according the Y axis so it look left and right
			float _rotationX = transform.localEulerAngles.y + _moveJoystick.Horizontal * _lookSensitivityX;
			//Rotate the player according on the Vertical input.
			_rotationY += _moveJoystick.Vertical * _lookSensitivityY;
			//Clamp the value so it does not rotate 360 degrees
			_rotationY = Mathf.Clamp(_rotationY, _minY, _maxY);
			// -rotationY because it is inverted
			//(we put in X axis because it is dealing with rotation and we want to rotate in X to look up and down)
			transform.localEulerAngles = new Vector3(-_rotationY, _rotationX, 0);

		}
		//For looking Horizontal (rotate Y axis base on horizontal input)
		else if (_axis == RotationalAxis.lookX)
		{
			//Rotate the player to left and right
			transform.Rotate(0, _moveJoystick.Horizontal * _lookSensitivityX,0);
			
		}
		else //For looking Vertical (rotate X axis base on vertical input)
		{
			//Player look up and down according the Vertical input value
			_rotationY += _moveJoystick.Vertical * _lookSensitivityY;
			//Clamp the value between minY and maxY
			_rotationY = Mathf.Clamp(_rotationY, _minY, _maxY);
			//Rotate the player on the X axis so it looking up and down
			transform.localEulerAngles = new Vector3(-_rotationY, 0, 0);
		}
		
	}

}
public enum RotationalAxis
{
	lookXandY, lookX, lookY,
}
