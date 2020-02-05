using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	private GameObject playerObject;

	void Start ()
	{
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		DontDestroyOnLoad (this);
	}

    void LateUpdate ()
    {
		GetComponent<Transform> ().position = playerObject.GetComponent<Transform> ().position - new Vector3 (0, 0, 2);
    }
}
