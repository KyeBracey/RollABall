using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	void Start () {
		offset = transform.position - player.transform.position;
	}

	// Runs every frame, just like update, but is guaranteed to run after
	// all items have been processed in update
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
