using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
	public int score = 0;
	public GameObject scoreUI;

	void Start ()
	{
		scoreUI.GetComponent<TextMeshProUGUI> ().text = "€" + score;
		DontDestroyOnLoad (scoreUI);
	}

    void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Trash")
		{
			score += 50;
			scoreUI.GetComponent<TextMeshProUGUI> ().text = "€" + score;
			Destroy (other.gameObject);
		}

	}

}
