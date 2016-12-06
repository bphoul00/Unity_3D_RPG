using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;
	private CharacterController controller;
	public float speed = 6.0f;
	public float turnspeed = 60.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponentInChildren<Animator> ();
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("up") || Input.GetKey("w") || Input.GetKey ("down") || Input.GetKey("s")) {
			anim.SetInteger("AnimPar", 1);
		} else {
			anim.SetInteger("AnimPar", 0);
		}

		if (controller.isGrounded) {
			moveDirection = transform.forward * Input.GetAxis ("Vertical") * speed;
		}

		float turn = Input.GetAxis ("Horizontal");
		transform.Rotate (0, turn * turnspeed * Time.deltaTime, 0);
		controller.Move (moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime; 
	
	}
}
