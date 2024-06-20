using UnityEngine;

namespace GameManager
{
public sealed class GameEndSystem : MonoBehaviour
{
	public void FinishGame()
	{
		Debug.Log("Game over!");
		Time.timeScale = 0;
	}
}
}