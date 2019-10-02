using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
   //NOTE* THIS IS JUST TO DESTROY THE "GAME START" text after it is active

    // Update is called once per frame
    void Update()
    {
		Destroy(gameObject, 5f);
	}
}
