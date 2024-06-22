using System;
using UnityEngine;

namespace Bullets
{
[RequireComponent(typeof(Rigidbody2D))]
public sealed class Bullet : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D _rigidbody2D;
	[SerializeField]
	private SpriteRenderer _spriteRenderer;


	public event Action<Bullet, Collision2D> OnCollisionEntered;


	public bool IsPlayer { get; private set; }
	public int  Damage   { get; private set; }


	private void OnCollisionEnter2D(Collision2D collision)
	{
		OnCollisionEntered?.Invoke(this, collision);
	}

	public void Setup(BulletSystem.Args args)
	{
		_rigidbody2D.velocity = args.Velocity;
		gameObject.layer      = args.PhysicsLayer;
		transform.position    = args.Position;
		_spriteRenderer.color = args.Color;
		IsPlayer              = args.IsPlayer;
		Damage                = args.Damage;
	}
}
}