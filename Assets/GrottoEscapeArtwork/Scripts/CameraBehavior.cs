using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

	public Transform target; // what the camera is following
	public float smoothing;

	Vector3 offset;
	float lowY;
	float lowX;
	float highY;
	float highX;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;

		highX = 786.82074f;
		highY = 22.95f;
		lowX = transform.position.x;
		lowY = transform.position.y;
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetCamPos = target.position + offset;

		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing*Time.deltaTime);

		if (transform.position.y < lowY)
			transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
		if (transform.position.y > highY)
			transform.position = new Vector3 (transform.position.x, highY, transform.position.z);
		if (transform.position.x < lowX)
			transform.position = new Vector3 (lowX, transform.position.y, transform.position.z);
		if (transform.position.x > highX)
			transform.position = new Vector3 (highX, transform.position.y, transform.position.z);
	}
}
