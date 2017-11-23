using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlatform : MonoBehaviour {

    public float velocity;
    private Rigidbody2D rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(velocity, rigidbody.velocity.y);
        if (rigidbody.transform.position.x < -25f)
        {
            rigidbody.transform.position = new Vector3(0.6f, rigidbody.transform.position.y, rigidbody.transform.position.z);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Application.LoadLevel(0);
        }
    }
}
