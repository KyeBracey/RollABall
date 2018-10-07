using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	private Vector3 jump;
	private bool isGrounded;

	// Start is called once, on the very first frame that the script is active
	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "<WASD>\nor\n<arrow keys>\nto move";

		jump = new Vector3(0.0f, 5.0f, 0.0f);
	}

	// Update is called before rendering each frame
	// Most game code will go here
	void Update () {
		if (
			Input.GetKeyDown("space") &&
			isGrounded &&
			count >= 8
		) {
			rb.AddForce(jump, ForceMode.Impulse);
			isGrounded = false;
		}
	}

	// FixedUpdate is called just before performing any physics calculations
	// Physics code will go here
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pickup")) {
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}

	void OnCollisionStay() {
		if (rb.velocity.y == 0) {
			isGrounded = true;
		}
	}

	void SetCountText() {
		countText.text = "Score: " + count .ToString();

		if (count >= 8) {
			winText.text = "<WASD>\nor\n<arrow keys>\nto move\n\n<space> to jump";
		}
	}

	// 'MonoDevelop' has a shortcut which searches the Unity API
	// cmd + '
	// This sounds super helpful, find out what it works with/how to get
}
