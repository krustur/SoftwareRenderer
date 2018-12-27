using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotCube : MonoBehaviour {

	private float yrot = 0;
	private Transform cube;
	// Use this for initialization
	void Start () {
		cube = GameObject.Find("/RotCube").GetComponent<Transform>();
		//var grandparentTransform = GameObject.Find("/TestGroup/GrandParent").GetComponent<Transform>();
		Debug.LogFormat ("cube: {0}", cube);
		//Matrix4x4.tra
	}
	
	// Update is called once per frame
	void Update () {
		if (cube != null) {
			yrot += 1f;

			//Debug.LogFormat ("yrot: {0}", yrot);

			Quaternion rotation = Quaternion.Euler (0, yrot, 0);
			//Matrix4x4 matrix = Matrix4x4.Rotate (rotation);

			cube.rotation = rotation;
		}
	}
}
