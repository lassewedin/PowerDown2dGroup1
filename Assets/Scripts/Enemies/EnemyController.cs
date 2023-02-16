using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float speed;
	public float rotationSpeed;

	private Rigidbody2D rigidbody;
	private PlayerAwarenessController playerAwarenessController;
	private Vector2 targetDirection;
	private EnemyAttack attack;
	
	void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		playerAwarenessController = GetComponent<PlayerAwarenessController>();
		attack = GetComponent<EnemyAttack>();
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
			Vector2 enemyToPlayerVector =playerAwarenessController.player.transform.position - transform.position;


			if (enemyToPlayerVector.magnitude > playerAwarenessController.minDistanceToPlayerBeforeAttack)
			{
				rigidbody.velocity = transform.up * speed;
			}
			else
			{
				rigidbody.velocity = Vector2.zero;
				if(attack != null) attack.Attack();
			}
		}
	}
}