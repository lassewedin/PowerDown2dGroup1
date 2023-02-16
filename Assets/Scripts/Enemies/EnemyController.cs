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
	private Health health;
	public GameObject dead;
	
	void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		playerAwarenessController = GetComponent<PlayerAwarenessController>();
		attack = GetComponent<EnemyAttack>();
		health = GetComponent<Health>();
	}
	
	void FixedUpdate()
	{
		UpdateDirection();
		RotateTowardsTarget();
		SetVelocity();
		if (health.isDead)
		{
			var ant = Instantiate(dead);
			ant.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
			ant.transform.position = this.transform.position;
			ant.transform.rotation = this.transform.rotation;
			Destroy(gameObject);
		}
	}

	void UpdateDirection()
	{
		if (playerAwarenessController.awareOfPlayer)
		{
			targetDirection = playerAwarenessController.directionToPlayer;
			GetComponent<SpriteRenderer>().flipX = !(targetDirection.x < 0);
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
				if(attack != null) attack.Attack(playerAwarenessController.directionToPlayer);
			}
		}
	}
}