using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
	//Still Note working
	//Trying to instantiate prefab using game asset prefab
	private static GameAssets _instance;
	public static GameAssets instance
	{
		get
		{
			if (_instance == null)
				_instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
			return _instance;
		}
	}

	public Transform damagePop;
}
