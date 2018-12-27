using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGroupScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var oneScale = Matrix4x4.Scale (new Vector3 (1, 1, 1));
		MyHelper.printMatrix("_oneScaleUnity", oneScale);

		var zeroCamera = GameObject.Find("/ZeroCamera").GetComponent<Camera>();
		MyHelper.printMatrix("_zeroCameraTransformLocalToWorldMatrixUnity", zeroCamera.transform.localToWorldMatrix);
		MyHelper.printMatrix("_zeroCameraTransformLocalToWorldMatrixInverseUnity", zeroCamera.transform.localToWorldMatrix.inverse);
		MyHelper.printMatrix("_zeroCameraTransformWorldToLocalMatrixUnity", zeroCamera.transform.worldToLocalMatrix);
		MyHelper.printMatrix("_zeroCameraTransformWorldToLocalMatrixInverseUnity", zeroCamera.transform.worldToLocalMatrix.inverse);
		MyHelper.printMatrix("_zeroCameraCameraToWorldMatrixUnity", zeroCamera.cameraToWorldMatrix);
		MyHelper.printMatrix("_zeroCameraCameraToWorldMatrixInverseUnity", zeroCamera.cameraToWorldMatrix.inverse);
		MyHelper.printMatrix("_zeroCameraWorldToCameraMatrixUnity", zeroCamera.worldToCameraMatrix);
		MyHelper.printMatrix("_zeroCameraWorldToCameraMatrixInverseUnity", zeroCamera.worldToCameraMatrix.inverse);


		var camera = GameObject.Find("/TestGroup/Camera").GetComponent<Camera>();
		MyHelper.printMatrix("_cameraTransformLocalToWorldMatrixUnity", camera.transform.localToWorldMatrix);
		MyHelper.printMatrix("_cameraTransformLocalToWorldMatrixInverseUnity", camera.transform.localToWorldMatrix.inverse);
		MyHelper.printMatrix("_cameraTransformWorldToLocalMatrixUnity", camera.transform.worldToLocalMatrix);
		MyHelper.printMatrix("_cameraTransformWorldToLocalMatrixInverseUnity", camera.transform.worldToLocalMatrix.inverse);
		MyHelper.printMatrix("_cameraCameraToWorldMatrixUnity", camera.cameraToWorldMatrix);
		MyHelper.printMatrix("_cameraCameraToWorldMatrixInverseUnity", camera.cameraToWorldMatrix.inverse);
		MyHelper.printMatrix("_cameraWorldToCameraMatrixUnity", camera.worldToCameraMatrix);
		MyHelper.printMatrix("_cameraWorldToCameraMatrixInverseUnity", camera.worldToCameraMatrix.inverse);
		MyHelper.printMatrix("_cameraProjectionMatrixUnity", camera.projectionMatrix);
		MyHelper.printFloat("_cameraFarClipPlaneUnity", camera.farClipPlane);
		MyHelper.printFloat("_cameraNearClipPlaneUnity", camera.nearClipPlane);
		MyHelper.printFloat("_cameraPixelWidthUnity", camera.pixelWidth);
		MyHelper.printFloat("_cameraPixelHeightUnity", camera.pixelHeight);
		MyHelper.printFloat("_cameraAspectUnity", camera.aspect);
		MyHelper.printFloat("_cameraFieldOfViewUnity", camera.fieldOfView);

		var rotCube = GameObject.Find ("/RotCube");//.GetComponent<GameObject>();
		MyHelper.printMatrix("_rotCubeTransformLocalToWorldUnity", rotCube.GetComponent<Transform>().localToWorldMatrix);
		MyHelper.printMatrix("_rotCubeTransformLocalToWorldInverseUnity", rotCube.GetComponent<Transform>().localToWorldMatrix.inverse);
		MyHelper.printMatrix("_rotCubeTransformWorldToLocalUnity", rotCube.GetComponent<Transform>().worldToLocalMatrix);
		MyHelper.printMatrix("_rotCubeTransformWorldToLocalInverseUnity", rotCube.GetComponent<Transform>().worldToLocalMatrix.inverse);
		MyHelper.printVector("_rotCubeTransformLocalPositionUnity", rotCube.GetComponent<Transform>().localPosition);
		MyHelper.printVector("_rotCubeTransformWorldPositionUnity", rotCube.GetComponent<Transform>().position);
		MyHelper.printVector("_rotCubeTransformLocalRotationUnity", rotCube.GetComponent<Transform>().localRotation.eulerAngles);
		MyHelper.printVector("_rotCubeTransformWorldRotationUnity", rotCube.GetComponent<Transform>().rotation.eulerAngles);

		var grandParent = GameObject.Find ("/TestGroup/GrandParent");
		MyHelper.printMatrix("_grandParentTransformLocalToWorldUnity", grandParent.GetComponent<Transform>().localToWorldMatrix);
		MyHelper.printMatrix("_grandParentTransformLocalToWorldInverseUnity", grandParent.GetComponent<Transform>().localToWorldMatrix.inverse);
		MyHelper.printMatrix("_grandParentTransformWorldToLocalUnity", grandParent.GetComponent<Transform>().worldToLocalMatrix);
		MyHelper.printMatrix("_grandParentTransformWorldToLocalInverseUnity", grandParent.GetComponent<Transform>().worldToLocalMatrix.inverse);
		MyHelper.printVector("_grandParentTransformLocalPositionUnity", grandParent.GetComponent<Transform>().localPosition);
		MyHelper.printVector("_grandParentTransformWorldPositionUnity", grandParent.GetComponent<Transform>().position);
		MyHelper.printVector("_grandParentTransformLocalRotationUnity", grandParent.GetComponent<Transform>().localRotation.eulerAngles);
		MyHelper.printVector("_grandParentTransformWorldRotationUnity", grandParent.GetComponent<Transform>().rotation.eulerAngles);


		var parent = GameObject.Find ("/TestGroup/GrandParent/Parent");
		MyHelper.printMatrix("_parentTransformLocalToWorldUnity", parent.GetComponent<Transform>().localToWorldMatrix);
		MyHelper.printMatrix("_parentTransformLocalToWorldInverseUnity", parent.GetComponent<Transform>().localToWorldMatrix.inverse);
		MyHelper.printMatrix("_parentTransformWorldToLocalUnity", parent.GetComponent<Transform>().worldToLocalMatrix);
		MyHelper.printMatrix("_parentTransformWorldToLocalInverseUnity", parent.GetComponent<Transform>().worldToLocalMatrix.inverse);
		MyHelper.printVector("_parentTransformLocalPositionUnity", parent.GetComponent<Transform>().localPosition);
		MyHelper.printVector("_parentTransformWorldPositionUnity", parent.GetComponent<Transform>().position);
		MyHelper.printVector("_parentTransformLocalRotationUnity", parent.GetComponent<Transform>().localRotation.eulerAngles);
		MyHelper.printVector("_parentTransformWorldRotationUnity", parent.GetComponent<Transform>().rotation.eulerAngles);

		var child = GameObject.Find ("/TestGroup/GrandParent/Parent/Child");
		MyHelper.printMatrix("_childTransformLocalToWorldUnity", child.GetComponent<Transform>().localToWorldMatrix);
		MyHelper.printMatrix("_childTransformLocalToWorldInverseUnity", child.GetComponent<Transform>().localToWorldMatrix.inverse);
		MyHelper.printMatrix("_childTransformWorldToLocalUnity", child.GetComponent<Transform>().worldToLocalMatrix);
		MyHelper.printMatrix("_childTransformWorldToLocalInverseUnity", child.GetComponent<Transform>().worldToLocalMatrix.inverse);
		MyHelper.printVector("_childTransformLocalPositionUnity", child.GetComponent<Transform>().localPosition);
		MyHelper.printVector("_childTransformWorldPositionUnity", child.GetComponent<Transform>().position);
		MyHelper.printVector("_childTransformLocalRotationUnity", child.GetComponent<Transform>().localRotation.eulerAngles);
		MyHelper.printVector("_childTransformWorldRotationUnity", child.GetComponent<Transform>().rotation.eulerAngles);

		var childViewPointInZeroCamera = zeroCamera.WorldToViewportPoint (child.GetComponent<Transform>().position);
		var childScreenPointInZeroCamera = zeroCamera.WorldToScreenPoint (child.GetComponent<Transform>().position);
		MyHelper.printVector("_childViewPointInZeroCameraUnity", childViewPointInZeroCamera);
		MyHelper.printVector("_childScreenPointInZeroCameraUnity", childScreenPointInZeroCamera);

		var grandParentViewPointInZeroCamera = zeroCamera.WorldToViewportPoint (grandParent.GetComponent<Transform>().position);
		var grandParentScreenPointInZeroCamera = zeroCamera.WorldToScreenPoint (grandParent.GetComponent<Transform>().position);
		MyHelper.printVector("_grandParentViewPointInZeroCameraUnity", grandParentViewPointInZeroCamera);
		MyHelper.printVector("_grandParentScreenPointInZeroCameraUnity", grandParentScreenPointInZeroCamera);

		var xxx = (zeroCamera.projectionMatrix * zeroCamera.worldToCameraMatrix) * grandParent.GetComponent<Transform> ().position;
		MyHelper.printVector("WorldPos:  ", grandParent.GetComponent<Transform> ().position);
		MyHelper.printVector("ViewPos: ", xxx);
		//var yyy = zeroCamera.projectionMatrix * xxx;
		//MyHelper.printVector("ClipPos:   ", yyy);
		//var zzz = zeroCamera.cullingMatrix * yyy;
		//MyHelper.printVector("Culla:      ", zzz);
		MyHelper.printMatrix ("ProjMatrix ", zeroCamera.projectionMatrix);






		var childViewPointInCamera = camera.WorldToViewportPoint (child.GetComponent<Transform>().position);
		var childScreenPointInCamera = camera.WorldToScreenPoint (child.GetComponent<Transform>().position);
		MyHelper.printVector("_childViewPointInCameraUnity", childViewPointInCamera);
		MyHelper.printVector("_childScreenPointInCameraUnity", childScreenPointInCamera);
		}
	
	// Update is called once per frame
	void Update () {
		
	}
}
