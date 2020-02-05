using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public GameObject cameraPosition;
	public List<Sprite> daycycle;
	private bool needsChange = true;
	private float offset = 0.1f;

	private int index = 0;

	void Start ()
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		renderer.transform.localScale = new Vector3 (2.83f, 2.83f, 2.83f);
		renderer.transform.position = new Vector3 (-3.5f, -3.9f, 5);
		renderer.sprite = daycycle[0];
	}

	void Update ()
	{
		if (transform.position.y <= -7 && needsChange)
		{
			needsChange = false;
			index++;
			GetComponent<SpriteRenderer> ().sprite = daycycle[index % 2];
		}

		if (transform.position.y > -7 && !needsChange)
		{
			needsChange = true;
		}
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		transform.position = new Vector3 ( cameraPosition.GetComponent<Transform> ().position.x, 
															(10 * Mathf.Sin(offset) - 7), 
															15);
		offset += 0.02f;
    }
}
