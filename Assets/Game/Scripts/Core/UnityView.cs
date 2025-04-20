using Entitas.Unity;
using UnityEngine;

namespace Core
{
public abstract class UnityView : MonoBehaviour
{
	protected Contexts   Contexts;
	protected GameEntity LinkedEntity;
	
	
	public virtual void Link(Contexts contexts, GameEntity entity)
	{
		Contexts     = contexts;
		LinkedEntity = entity;
		gameObject.Link(entity);
	}

	public virtual void Unlink()
	{
		gameObject.Unlink();
		LinkedEntity = null;
	}

	public virtual void SetViewActive(bool isActive)
	{
		gameObject.SetActive(isActive);
	}
}
}