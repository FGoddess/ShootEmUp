using Money;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Helpers
{
public class MoneyStorageHelper : MonoBehaviour
{
	private MoneyService _moneyService;

	[Inject]
	public void Construct(MoneyService moneyService)
	{
		_moneyService = moneyService;
	}

	[Button]
	public void AddMoney(int amountToAdd)
	{
		_moneyService.AddMoney(amountToAdd);
		Debug.Log($"Money = {_moneyService.Money}");
	}

	[Button]
	public void SpendMoney(int amountToRemove)
	{
		_moneyService.SpendMoney(amountToRemove);
		Debug.Log($"Money = {_moneyService.Money}");
	}
}
}