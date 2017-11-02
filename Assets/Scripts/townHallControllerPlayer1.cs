using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class townHallControllerPlayer1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision2D)
	{
		UiScript uiScript = GameObject.Find ("EventSystem").GetComponent<UiScript> ();

		if (collision2D.gameObject.tag == "Creep")
		{
			uiScript.Coins -= uiScript.CreepFail;
			uiScript.setTextCoins ();
		}
	}
}
