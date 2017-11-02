using UnityEngine;
using System.Collections;

public class HideCanvas : MonoBehaviour
{
	public GameObject resultCanvas;


	// Use this for initialization
	void Start ()
	{
		resultCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ShowCanvas()
	{
		resultCanvas.SetActive (true);
	}
}

