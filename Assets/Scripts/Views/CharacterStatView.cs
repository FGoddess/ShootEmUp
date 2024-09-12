using TMPro;
using UnityEngine;

namespace Views
{
public class CharacterStatView : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _statName;
	[SerializeField]
	private TMP_Text _statValue;


	public void SetName(string statName)
	{
		_statName.text = $"{statName}: ";
	}
	
	public void SetValue(int statValue)
	{
		_statName.text = $"{statValue}: ";
	}
}
}