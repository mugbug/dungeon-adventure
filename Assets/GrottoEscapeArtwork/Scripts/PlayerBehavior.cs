using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	// movement variables
	public float maxSpeed;
	private bool facingRight;

	// jumping variables
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	private Animator animator;

	private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		facingRight = true;
	}

	void Update() {
		if (grounded && Input.GetAxis ("Jump") > 0) {
			grounded = false;
			animator.SetBool ("onGround", grounded);
			rigidbody.AddForce (new Vector2 (0, jumpHeight));
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		// check if grounded
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		animator.SetBool ("onGround", grounded);

		float move = Input.GetAxis ("Horizontal");
		animator.SetFloat ("speed", Mathf.Abs (move));
		rigidbody.velocity = new Vector2 (move * maxSpeed, rigidbody.velocity.y);

		if (move > 0 && !facingRight) {
			flip ();
		} else if (move < 0 && facingRight) {
			flip ();
		}
	}

	void flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
