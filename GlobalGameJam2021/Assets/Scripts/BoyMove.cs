﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoyMove : MonoBehaviour
{
	private float Speed = 5.0f;

	private void Start()
	{

	}

	private void Update()
	{
		var rigidBody = gameObject.GetComponent<Rigidbody2D>();

		// ------------------- LeftRight ---------------------------------------
		if (Input.GetAxisRaw("Horizontal") > 0.01)
		{
			if (rigidBody != null)
			{
				rigidBody.velocity = new Vector2(this.Speed, rigidBody.velocity.y);
				gameObject.GetComponent<SpriteRenderer>().flipX = false;
			}
		}

		else if (Input.GetAxisRaw("Horizontal") < -0.01)
		{
			if (rigidBody != null)
			{
				rigidBody.velocity = new Vector2(-this.Speed, rigidBody.velocity.y);
				gameObject.GetComponent<SpriteRenderer>().flipX = true;
			}
		}

		else
		{
			if (rigidBody != null)
			{
				rigidBody.velocity = new Vector2(0.0f, rigidBody.velocity.y);
			}
		}

        // ---------------------------------------------------------------------

        gameObject.GetComponent<Animator>().SetFloat("Velocity", Mathf.Abs(rigidBody.velocity.x / 5.0f));

        if (gameObject.GetComponent<Animator>().GetFloat("Velocity") > 0.01f)
        {
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
                gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
		

	}
}
