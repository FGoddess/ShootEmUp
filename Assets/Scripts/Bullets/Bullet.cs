using System;
using Common;
using UnityEngine;

namespace Bullets
{
[RequireComponent(typeof(Rigidbody2D))]
public sealed class Bullet : MonoBehaviour, IGamePauseListener, IGameResumeListener
{
	[SerializeField]
	private Rigidbody2D _rigidbody2D;
	[SerializeField]
	private SpriteRenderer _spriteRenderer;


	private Vector2 _velocity;
	
	public event Action<Bullet, Collision2D> OnCollisionEntered;


	public bool IsPlayer { get; private set; }
	public int  Damage   { get; private set; }

	
	public void OnPause()
	{
		_rigidbody2D.velocity = Vector2.zero;
	}

	public void OnResume()
	{
		_rigidbody2D.velocity = _velocity;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		OnCollisionEntered?.Invoke(this, collision);
	}

	public void Setup(BulletSystem.Args args)
	{
		_velocity             = args.Velocity;
		_rigidbody2D.velocity = _velocity;
		gameObject.layer      = args.PhysicsLayer;
		transform.position    = args.Position;
		_spriteRenderer.color = args.Color;
		IsPlayer              = args.IsPlayer;
		Damage                = args.Damage;
	}

	
}
}