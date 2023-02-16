using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float speed;
	public float rotationSpeed;

	private Rigidbody2D rigidbody;

	private PlayerAwarenessController playerAwarenessController;

	private Vector2 targetDirection;
	
	void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		playerAwarenessController = GetComponent<PlayerAwarenessController>();
	}
	
	void FixedUpdate()
	{
		UpdateDirection();
		RotateTowardsTarget();
		SetVelocity();
	}

	void UpdateDirection()
	{
		if (playerAwarenessController.awareOfPlayer)
		{
			targetDirection = playerAwarenessController.directionToPlayer;
		}
		else
		{
			targetDirection = Vector2.zero;
		}
	}

	void RotateTowardsTarget()
	{
		if (targetDirection == Vector2.zero) return;

		Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
		Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		rigidbody.SetRotation(rotation);
	}

	void SetVelocity()
	{
		if (targetDirection == Vector2.zero)
		{
			rigidbody.velocity = Vector2.zero;
		}
		else
		{
			rigidbody.velocity = transform.up * speed;
		}
	}
}