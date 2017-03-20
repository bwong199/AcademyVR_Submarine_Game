using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

public GameObject gameObject;
public MeshRenderer mRenderer;
public Material goMaterial;
public Material goMaterial2;

	protected bool toggled = true;

		void Start () {
				
	}

	void Awake()
	{
		goMaterial = mRenderer.material;
	}

	// Update is called once per frame
	void Update () {
		if(GvrViewer.Instance.Triggered){
			ChangeMaterial ();
		}
	}

	public void ChangeMaterial ()
	{
		if(toggled){
			mRenderer.material = goMaterial;
		} else {
			mRenderer.material = goMaterial2;
		}

		toggled = !toggled;
		gameObject.GetComponent <AudioSource> ().Play ();

	}
}
