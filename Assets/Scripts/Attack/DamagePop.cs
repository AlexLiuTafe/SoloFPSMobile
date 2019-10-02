using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePop : MonoBehaviour
{
	//*STILL NOT WORKING DAMAGE POP UP
	//NOTE : 30% Chance Crit
	//bool isCritHit= Random.Range(0,100) < 30; 
	// function name (bool isCritHit)
	private TextMeshPro textMesh;
	private float disappearTimer;
	private Color textColor;
	private void Awake()
	{
		textMesh = transform.GetComponent<TextMeshPro>();
	}
	public void Setup(float damageAmount)
	{
		textMesh.SetText(damageAmount.ToString());
		//textColor = textMesh.color;
		disappearTimer = 1f;
	}
	//Create DamagePopUp Text
	public static DamagePop Create(Vector3 position, float damageAmount)
	{
		//Instantiate the damage text prefab
		Transform damagePopTransform = Instantiate(GameAssets.instance.damagePop, position, Quaternion.identity);
		//Get the gameobject position
		DamagePop damagePop = damagePopTransform.GetComponent<DamagePop>();
		//Return damage value into the text
		damagePop.Setup(damageAmount);

		return damagePop;
	}
	private void Update()
	{
		//store the variable for the text speed
		float moveYSpeed = 20f;
		//Make the damage text move in the y axis overtime
		transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
		//make the text disappear overtime
		disappearTimer -= Time.deltaTime;
		if (disappearTimer < 0)
		{
			//Start Disappearing
			float disappearSpeed = 3f;
			//reduce the alpha color overtime
			textColor.a -= disappearSpeed * Time.deltaTime;
			//assign the text into the text color
			textMesh.color = textColor;
			if (textColor.a < 0)
			{
				//Destroy gameobject when the alpha is less than 0
				Destroy(gameObject);
			}
		}
	}
	

	
}

