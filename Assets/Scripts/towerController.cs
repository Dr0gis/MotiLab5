using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start ()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Creep")
        {
            //collision2D.gameObject.SendMessage("ApplyDamage", 10);

            UiScript uiScript = GameObject.Find("EventSystem").GetComponent<UiScript>();
            //uiScript.listGOCreepsPlayer1.Remove(collider2D.gameObject);
            //uiScript.listGOCreepsPlayer2.Remove(collider2D.gameObject);
            //uiScript.listGOTowersPlayer1.Remove(gameObject);
            //uiScript.listGOTowersPlayer2.Remove(gameObject);


            collider2D.gameObject.GetComponent<creepController>().CheckFinishAndDestroy();
            //Destroy(collider2D.gameObject);
            Destroy(gameObject);
        }
    }
}
