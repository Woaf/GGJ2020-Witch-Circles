using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void LoadNextScene ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	void Update ()
	{
		if (!Input.GetAxis ("Submit").Equals(0))
		{
			LoadNextScene ();
		}
	}
}
