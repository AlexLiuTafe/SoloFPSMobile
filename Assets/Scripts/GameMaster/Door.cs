using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	//NOTE* FOR DOOR ANIMATION
	Animator anim;
	SphereCollider col;

    void Start()
    {
		//Get all the compenents when the its in play mode
		anim = GetComponent<Animator>();
		col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
	private void OnTriggerEnter(Collider other)
	{
		//Set animation when hit the collider
		anim.SetTrigger("GateOpen");
		
	}

}
