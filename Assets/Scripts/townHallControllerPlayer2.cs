using UnityEngine;
using System.Collections;

public class townHallControllerPlayer2 : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D(Collision2D collision2D)
	{
		UiScript uiScript = GameObject.Find ("EventSystem").GetComponent<UiScript> ();

		if (collision2D.gameObject.tag == "Creep")
		{
			uiScript.Coins += uiScript.CreepSuccess;
			uiScript.setTextCoins ();
		}
	}

}

