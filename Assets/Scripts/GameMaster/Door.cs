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
		
		anim = GetComponent<Animator>();
		col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
		//Set animation when hit the collider
		anim.SetTrigger("GateOpen");
		
	}

}
