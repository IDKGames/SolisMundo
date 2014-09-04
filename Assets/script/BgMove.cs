using UnityEngine;
using System.Collections;

public class BgMove : MonoBehaviour {

	Color aColor;
	// Update is called once per frame
	void Update () {
		aColor = renderer.material.color;
		aColor.a = (Mathf.Sin(Time.time)/2)+0.5f;
		renderer.material.color = aColor;
	}
}
