using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.InputSystem;
using SceneContext = SceneInstallers.SceneContext;

namespace Player
{
public class PlayerMoveController : MonoBehaviour
{
	[SerializeField]
	private SceneEntity _entity;
	[SerializeField]
	private PlayerInput _input;
	[SerializeField]
	private Camera _camera;

	private const float PointDistance = 12f;
	
	
	private void Start()
	{
		_input.actions["Fire"].started  += _ => _entity.GetIsShootingPressed().Value = true;
		_input.actions["Fire"].canceled += _ => _entity.GetIsShootingPressed().Value = false;
	}

	private void Update()
	{
		if (!SceneContext.Instance.GetIsPlaying().Value)
			return;

		_entity.SetInputDir(_input.actions["Move"].ReadValue<Vector2>());

		float mouseX = Mouse.current.position.x.ReadValue();
		float mouseY = Mouse.current.position.y.ReadValue();
		var ray = _camera.ScreenPointToRay(new Vector3(mouseX, mouseY, 0f));

		_entity.SetLookTarget(ray.GetPoint(PointDistance));
	}
}
}