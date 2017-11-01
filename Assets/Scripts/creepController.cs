using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creepController : MonoBehaviour
{
    public bool finish;

    private Rigidbody2D rigidbody2D;
    private Animator animator;

	// Use this for initialization
	void Start ()
	{
	    rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        finish = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void walk(bool right)
    {
        GetComponent<Animator>().SetFloat("Speed", 1);
        if (right)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left;
        }
    }

    public void stop()
    {
        rigidbody2D.velocity = Vector2.zero;
        GetComponent<Animator>().SetFloat("Speed", 0);
    }

    public void finished()
    {
        GetComponent<Animator>().SetBool("Finish", true);
        finish = true;
    }

    public void destoyed()
    {
        stop();
        GetComponent<Animator>().SetBool("Die", true);
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    private void checkAllFinish()
    {
        bool finishAll = true;

        UiScript uiScript = GameObject.Find("EventSystem").GetComponent<UiScript>();
        foreach (var creep in uiScript.listGOCreepsPlayer1)
        {
            if (creep != null)
            {
                finishAll = creep.GetComponent<creepController>().finish;
            }
        }

        if (finishAll)
        {
            uiScript.result();
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "TownHall")
        {
            stop();
            finished();

            checkAllFinish();
        }
    }

    void OnDestroy()
    {
        checkAllFinish();
    }
}
