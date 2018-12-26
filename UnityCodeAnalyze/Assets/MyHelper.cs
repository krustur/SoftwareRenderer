using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyHelper
{
	public static void printMatrix (string text, Matrix4x4 m)
	{
		Debug.LogFormat ("{0} = new Matrix4X4(new Vector4({1}f,{2}f,{3}f,{4}f),new Vector4({5}f,{6}f,{7}f,{8}f),new Vector4({9}f,{10}f,{11}f,{12}f),new Vector4({13}f,{14}f,{15}f,{16}f));", 
			text, 
			m.GetRow(0).x, m.GetRow(0).y, m.GetRow(0).z, m.GetRow(0).w,
			m.GetRow(1).x, m.GetRow(1).y, m.GetRow(1).z, m.GetRow(1).w,
			m.GetRow(2).x, m.GetRow(2).y, m.GetRow(2).z, m.GetRow(2).w,
			m.GetRow(3).x, m.GetRow(3).y, m.GetRow(3).z, m.GetRow(3).w
		);
	}

	public static void printVector (string text, Vector3 v)
	{
		Debug.LogFormat ("{0} = new Vector3({1}f, {2}f, {3}f);", 
			text, v.x, v.y, v.z);
	}

	public static void printVector (string text, Vector4 v)
	{
		Debug.LogFormat ("{0} = new Vector4({1}f, {2}f, {3}f, {4}f);", 
			text, v.x, v.y, v.z, v.w);
	}

	public static void printScreenPos (string text, Camera camera, Transform t)
	{
		Vector3 screenPos = camera.WorldToScreenPoint (t.position);

		Debug.LogFormat ("{0}: {1} {2}", 
			text, screenPos.x, screenPos.y);
	}

	public static void printFloat (string text, float f)
	{
		Debug.LogFormat ("{0} = {1}f;", text, f);
	}

}


