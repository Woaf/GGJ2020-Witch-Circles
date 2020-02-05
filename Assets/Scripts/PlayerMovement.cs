using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

	public Vector3 forward;
	public Vector3 up;
	private Rigidbody2D rigidBody;
	public bool isJumping;

	public Animator animator;

	void Start ()
	{
		transform.position = new Vector2 (0, 0);
		rigidBody = GetComponent<Rigidbody2D> ();
		forward = new Vector3 (4, 0, 0);
		up = new Vector3 (0, 2, 0);
	}

	void Update ()
	{
		if (Input.GetKey ("escape"))
		{
			Application.Quit ();
		}
	}

	void FixedUpdate ()
	{
		animator.SetFloat ("Horizontal", Input.GetAxis ("Horizontal"));

		float horizontalInput = Input.GetAxis ("Horizontal");
		float jumpInput = Input.GetAxis ("Jump");

		if(!horizontalInput.Equals(0.0f))
		{
			GetComponent<Transform> ().position += forward * horizontalInput * Time.deltaTime;
		}

		if (!jumpInput.Equals (0.0f))
		{
			animator.SetBool ("Jump", true);
			GetComponent<Transform> ().position += up * jumpInput * Time.deltaTime;
		} else
		{
			animator.SetBool ("Jump", false);
		}

		transform.Translate (0, 5.0f * Input.GetAxis ("Jump") * Time.deltaTime, 0);

		if(Input.GetAxis("Fire3").Equals (0.0f)) {
			forward = new Vector3 (4, 0, 0);
		} else if (!Input.GetAxis ("Fire3").Equals(0.0f))
		{
			forward = new Vector3 (7, 0, 0);
		}

	}

}
