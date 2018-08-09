using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	protected Rigidbody playerRigidbody;

	protected Vector2 prevMousePos, currentMousePos;

	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		prevMousePos = Input.mousePosition;
	}
}