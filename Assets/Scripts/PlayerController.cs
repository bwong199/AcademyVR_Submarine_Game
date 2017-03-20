using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public GameObject camera;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (camera != null) {
			gameObject.transform.position += camera.transform.forward * Time.deltaTime;

		}
	}


}
