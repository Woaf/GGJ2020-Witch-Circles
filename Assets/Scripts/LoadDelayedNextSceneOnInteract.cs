using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDelayedNextSceneOnInteract : MonoBehaviour
{
	IEnumerator DelayStartNextLevel ()
	{
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		transform.position = new Vector2 (0, 0);
	}

    void OnTriggerEnter2D (Collider2D finishZone)
	{
		if(finishZone.tag == "Finish")
		{
			StartCoroutine (DelayStartNextLevel ());
		}
	}
}
