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

	// shooting
	public Transform fireTip;
	public GameObject fire;
	float fireRate = 0.5f;
	float nextFire = 0;

	// References
	private GameMaster gm;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		facingRight = true;

		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
	}

	void Update() {
		if (grounded && Input.GetAxis ("Jump") > 0) {
			// play jump sound
			SoundManager.PlaySound ("jump");
			grounded = false;
			animator.SetBool ("onGround", grounded);
			rigidbody.AddForce (new Vector2 (0, jumpHeight));
		}

		// player shooting
		if (Input.GetAxisRaw ("Fire1") > 0) {
			shootFire ();
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

	void shootFire(){
		if (Time.time > nextFire) {
			animator.SetBool ("shoot", true);
			nextFire = Time.time + fireRate;
			// play fire sound
			SoundManager.PlaySound ("fire");
			if (facingRight) {
				Instantiate (fire, fireTip.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} else if (!facingRight) {
				Instantiate (fire, fireTip.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));
			}
		} else {
			animator.SetBool ("shoot", false);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag("Crystal")) {
			// play coin sound
			SoundManager.PlaySound ("coin");
			Destroy(col.gameObject);
			gm.incrementScore ();
		}

        if (col.CompareTag("ElementalOrb")) {
            SoundManager.PlaySound("coin");
            animator.SetBool("win", true);
            //gameObject.GetComponent<Animation>().Play("PlayerGlowAnimation");
            Destroy(col.gameObject);
        }
	}

	public IEnumerator Knockback (float knockDur, float knockbackPower, Vector3 knockbackDir) {
		float timer = 0;

		while (knockDur > timer) {
			timer += Time.deltaTime;
			rigidbody.AddForce (new Vector3 (knockbackDir.x * -100, knockbackDir.y * knockbackPower, transform.position.z));
		}

		yield return 0;
	}
}
