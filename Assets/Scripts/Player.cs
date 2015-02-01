using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float Speed;
	public float JumpForce;
	public LayerMask WhatIsGround;

	private bool facingRight = true;
	private bool grounded = false;
	public Transform groundCheck;
	private float groundRadius = 0.2f;

//	// Use this for initialization
//	void Start () {
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		if(grounded && Input.GetKeyDown(KeyCode.Space))
//		{
//			rigidbody2D.AddForce(new Vector2(0, JumpForce));
//		}
//		Physics2D.IgnoreLayerCollision( LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ground"), rigidbody2D.velocity.y > 0 );
//	}
//
//	void FixedUpdate() {
//		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGround);
//
//		float move = Input.GetAxis ("Horizontal");
//
//		rigidbody2D.velocity = new Vector2(Speed * move, rigidbody2D.velocity.y);
//		
//		if(move > 0 && !facingRight) {
//			Flip();
//		}
//		else if(move < 0 && facingRight) {
//			Flip();
//		}
//	}
//
//	void Flip() {
//		facingRight = !facingRight;
//		Vector3 scale = transform.localScale;
//		scale.x *= -1;
//		transform.localScale = scale;
//	}
}
