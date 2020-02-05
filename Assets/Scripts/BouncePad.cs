using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{

	private static Vector2 upJump = new Vector2(0, 3);

	private void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (upJump, ForceMode2D.Impulse);
		}
	}

}
