using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSubmarine : MonoBehaviour {
	public float speed = 10f;
	public Transform cameraTransform;
	public Transform submarineHolder;
	public GameObject torpedoPrefab;
	public Transform firePointTransform;


	public bool alive = true; 
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(alive){
				if (cameraTransform != null && submarineHolder != null) {
				// Move the Player Forward
				gameObject.transform.position += cameraTransform.forward * Time.deltaTime * speed;
				//submarineHolder.transform.rotation = cameraTransform.rotation;
				Quaternion submarineRotation = submarineHolder.transform.rotation;
				Quaternion cameraRotation = cameraTransform.transform.rotation;

				// Rotate the Submarine Shell
				submarineHolder.transform.rotation = Quaternion.Slerp (submarineRotation, cameraRotation, 5f * Time.deltaTime);

				// Check if button is triggered
				if(GvrViewer.Instance.Triggered)
				{
					Instantiate (torpedoPrefab, firePointTransform.position, submarineRotation);
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other){
		alive = false; 
		UIHelper_Example.ChangeText ("You Lost");
		Debug.Log (other.name);
	}

}
