﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		if (!Input.GetAxis("Cancel").Equals(0.0f))
		{
			Application.Quit ();
		}
	}
}
