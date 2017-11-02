using UnityEngine;
using System.Collections;

public class HideCanvas : MonoBehaviour
{
	public GameObject resultCanvas;

	void Start ()
	{
		resultCanvas.SetActive (false);
	}

	public void ShowCanvas()
	{
		resultCanvas.SetActive (true);
	}
}

