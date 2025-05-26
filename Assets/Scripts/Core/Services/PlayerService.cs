using System.Collections.Generic;
using UnityEngine;

namespace Core.Services
{
public class PlayerService
{
	public List<HeroData> BluePlayerHeroes;
	public List<HeroData> RedPlayerHeroes;

	public HeroData SelectedAttacker;
	public HeroData SelectedTarget;

	public bool IsBluePlayerTurn { get; private set; } = true;

	public IReadOnlyList<HeroData> CurrentPlayerHeroes => IsBluePlayerTurn ? BluePlayerHeroes : RedPlayerHeroes;
	public IReadOnlyList<HeroData> CurrentEnemyHeroes  => IsBluePlayerTurn ? RedPlayerHeroes : BluePlayerHeroes;


	public void SetNextPlayerTurn()
	{
		IsBluePlayerTurn = !IsBluePlayerTurn;
	}

	public HeroData GetRandomHero(bool isBlue)
	{
		var heroes = IsBluePlayerTurn ? BluePlayerHeroes : RedPlayerHeroes;
		return heroes[Random.Range(0, heroes.Count)];
	}

	public void Cleanup()
	{
		SelectedAttacker.View.SetActive(false);
		SelectedTarget.View.SetActive(false);

		SelectedAttacker = null;
		SelectedTarget   = null;
	}
}
}