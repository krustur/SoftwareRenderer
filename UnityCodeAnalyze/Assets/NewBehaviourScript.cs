using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var translate = Matrix4x4.Translate (new Vector3 (3, 4, 5));
		//MyHelper.printMatrix ("translate 3,4,5", translate);

		var fov = 1.0472f;
		fov = 60;//~Mathf.Rad2Deg (1.0472f);
		var aspectRatio = (float) 640 / 480;
		var fovm = Matrix4x4.Perspective(fov, aspectRatio, 0.3f, 1000f);
		//MyHelper.printMatrix ("fov", fovm);

		//var fovoffm = Matrix4x4.off(fov, aspectRatio, 0.3f, 1000f);


	}


	
	// Update is called once per frame
	void Update () {
		
	}
}

