using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoController : MonoBehaviour {

	public float speed = 10f;
	public float maxLifetime = 10f;
	public GameObject explosionPrefab;

	public float lifetime = 0;


	// Use this for initialization
	void Start () {
		Destroy (gameObject, maxLifetime);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += this.transform.forward * Time.deltaTime * speed; 

	}

	private void OnTriggerEnter(Collider other)
	{
		// Destroy other object if it has destroy tag
		if(other.tag == "Destroy"){
			Destroy (other.gameObject);

			int destructableCount = GameObject.FindGameObjectsWithTag ("Destroy").Length - 1;

			UIHelper_Example.ChangeText ("You have " + destructableCount + " mines reminainining");
			Debug.Log("There are " + destructableCount + " bombs left");
			if(destructableCount == 0){
				GameObject player = GameObject.FindGameObjectWithTag ("Player");
				PlayerControllerSubmarine playerController = player.GetComponent <PlayerControllerSubmarine> ();

				UIHelper_Example.ChangeText ("You WIN!!!");
				playerController.alive = false;

			}

		}

		//If explosion exists, create explosion
		if(explosionPrefab != null){
			Instantiate (explosionPrefab, gameObject.transform.position, Quaternion.identity);
		} else {
			Debug.Log ("You forgot to put in the explosion prefab.");
		}
		Destroy (gameObject);

	}
}
