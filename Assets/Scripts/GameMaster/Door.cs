using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	// Start is called before the first frame update
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
		anim.SetTrigger("GateOpen");
		
	}

}
