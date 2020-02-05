using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BannerTimer : MonoBehaviour
{
	private IEnumerator BannerDisplay ()
	{
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine (BannerDisplay ());
    }
}
