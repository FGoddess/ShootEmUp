using System.Collections.Generic;
using System.Linq;
using Types;
using UnityEngine;
using Views;
using Object = UnityEngine.Object;

namespace Factory
{
public class ArrowViewFactory : IArrowFactory
{
	private readonly Contexts        _contexts;
	private readonly ArrowView       _arrowPrefab;
	private readonly Transform       _container;
	private readonly List<ArrowView> _pool;

	public ArrowViewFactory(Contexts contexts, ArrowView arrowPrefab, Transform container)
	{
		_contexts    = contexts;
		_arrowPrefab = arrowPrefab;
		_container   = container;
		_pool        = new List<ArrowView>();
	}

	public void CreateArrow(GameEntity attacker, GameEntity target)
	{
		var entity = _contexts.game.CreateEntity();
		entity.isArrowTag = true;
		entity.AddPosition(attacker.position.Value);
		entity.AddNearestTarget(target);
		entity.AddMove(10f);
		entity.AddAttackRange(0.5f);
		entity.AddDamage(attacker.damage.Value);

		var direction = (target.position.Value - attacker.position.Value).normalized;
		entity.AddFacing(direction);

		var view = GetArrowView();
		view.transform.position = attacker.position.Value;
		view.Link(_contexts, entity);
	}

	private ArrowView GetArrowView()
	{
		var view = _pool.FirstOrDefault(v => !v.gameObject.activeInHierarchy);

		if (view != null)
		{
			view.gameObject.SetActive(true);
			return view;
		}

		view = Object.Instantiate(_arrowPrefab, _container);
		_pool.Add(view);
		return view;
	}
}
}