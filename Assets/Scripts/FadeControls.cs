using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine (StartFade ());
    }

	IEnumerator StartFade ()
	{
		yield return new WaitForSeconds (5);
		DestroyImmediate (gameObject);
	}
}
