using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour {

	public float speed = 10f; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += Vector3.forward * Time.deltaTime * speed;
	}

	private void OnTriggerEnter(Collider other){
		Debug.Log (other.name);
		Destroy (other.gameObject);
	}
}
