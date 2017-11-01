using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creepController : MonoBehaviour
{
    public bool finish;

    private Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start ()
	{
	    rigidbody2D = GetComponent<Rigidbody2D>();
	    finish = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "TownHall")
        {
            rigidbody2D.velocity = Vector2.zero;
            finish = true;

            bool finishAll = true;

            UiScript uiScript = GameObject.Find("EventSystem").GetComponent<UiScript>();
            foreach (var creep in uiScript.listGOCreepsPlayer1)
            {
                finishAll = creep.GetComponent<creepController>().finish;
            }

            if (finishAll)
            {
                uiScript.result();
            }
        }
    }
}
