using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



	public class CameraActivation : MonoBehaviour {
	
	public GameObject ActiveCamera;

	private IList<GameObject> allCameras = new List<GameObject> ();

		// Use this for initialization
		void Start () 
		{
			allCameras.Add (GameObject.Find ("/Main Camera"));
			allCameras.Add (GameObject.Find ("/TestGroup/Camera"));
			allCameras.Add (GameObject.Find ("/ZeroCamera"));
			//GameObject.Find ("/Main Camera").SetActive (false);				
			//GameObject.Find ("/TestGroup/Camera").SetActive (true);
			//GameObject.Find ("/ZeroCamera").SetActive (true);
			//Debug.Log ("Camera initialized!");
		}

		// Update is called once per frame
		void Update () {
			foreach (var cam in allCameras) {
				if (cam.Equals (ActiveCamera)) {
					cam.SetActive (true);
				} else {
					cam.SetActive (false);
				}
			}
		}


	}
