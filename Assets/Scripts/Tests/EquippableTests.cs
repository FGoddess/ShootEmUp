using NUnit.Framework;
using Inventory;
using Items;
using Inventory.Comps;
using Hero;
using System.Collections.Generic;
using UnityEngine;

namespace Tests
{
[TestFixture]
public class EquippableTests
{
	private InventoryList _inventory;

	private InventoryItemConfig _helmetConfig;
	private InventoryItemConfig _chestPlateConfig;
	private InventoryItemConfig _legsConfig;
	private InventoryItemConfig _glovesConfig;

	[SetUp]
	public void Setup()
	{
		_inventory = new InventoryList
		{
			Items        = new List<InventoryItem>(),
			EquipmentMap = new Dictionary<EEquipSlot, InventoryItem>()
		};

		_helmetConfig     = CreateItemConfig(1, "Тестовый шлем", EEquipSlot.Head);
		_chestPlateConfig = CreateItemConfig(2, "Тестовый нагрудник", EEquipSlot.Chest);
		_legsConfig       = CreateItemConfig(3, "Тестовые поножи", EEquipSlot.Legs);
		_glovesConfig     = CreateItemConfig(4, "Тестовые перчатки", EEquipSlot.Hands);

		_inventory.AddItem(_helmetConfig);
		_inventory.AddItem(_chestPlateConfig);
		_inventory.AddItem(_legsConfig);
		_inventory.AddItem(_glovesConfig);
	}

	private InventoryItemConfig CreateItemConfig(int id, string title, EEquipSlot slot)
	{
		var config = ScriptableObject.CreateInstance<InventoryItemConfig>();

		config.Item = new InventoryItem
		{
			Id    = id,
			Flags = InventoryItemFlags.Equippable,
			Metadata = new InventoryItemMetadata
			{
				Title       = title,
				Description = $"Тестовый предмет для слота {slot}"
			},
			Components = new IInventoryItemComp[]
			{
				new EquipmentComp { Slot = slot }
			},
			Amount = 1
		};

		return config;
	}

	[Test]
	public void EquipItem_ShouldMoveItemToEquipmentSlot()
	{
		// Act
		_inventory.EquipItem(_helmetConfig);

		// Assert
		Assert.IsTrue(_inventory.EquipmentMap.ContainsKey(EEquipSlot.Head));
		Assert.IsFalse(_inventory.HasItem(_helmetConfig.Item.Id));
	}

	[Test]
	public void UnEquipItem_ShouldMoveItemToInventory()
	{
		// Arrange
		_inventory.EquipItem(_helmetConfig);

		// Act
		_inventory.UnEquipItem(_helmetConfig);

		// Assert
		Assert.IsTrue(_inventory.HasItem(_helmetConfig.Item.Id));
		Assert.IsFalse(_inventory.EquipmentMap.ContainsKey(EEquipSlot.Head));
	}

	[Test]
	public void EquipItem_ShouldFailWhenSlotAlreadyOccupied()
	{
		// Arrange
		_inventory.EquipItem(_helmetConfig);

		var secondHelmetConfig = CreateItemConfig(5, "Второй шлем", EEquipSlot.Head);
		_inventory.AddItem(secondHelmetConfig);

		// Act
		_inventory.EquipItem(secondHelmetConfig);

		// Assert
		Assert.IsTrue(_inventory.HasItem(secondHelmetConfig.Item.Id));
		Assert.AreEqual(_helmetConfig.Item.Id, _inventory.EquipmentMap[EEquipSlot.Head].Id);
	}

	[Test]
	public void EquipMultipleItems_ShouldStoreItemsInCorrectSlots()
	{
		// Act
		_inventory.EquipItem(_helmetConfig);
		_inventory.EquipItem(_chestPlateConfig);
		_inventory.EquipItem(_legsConfig);
		_inventory.EquipItem(_glovesConfig);

		// Assert
		Assert.IsFalse(_inventory.HasItem(_helmetConfig.Item.Id));
		Assert.IsFalse(_inventory.HasItem(_chestPlateConfig.Item.Id));
		Assert.IsFalse(_inventory.HasItem(_legsConfig.Item.Id));
		Assert.IsFalse(_inventory.HasItem(_glovesConfig.Item.Id));
		
		Assert.AreEqual(0, _inventory.Items.Count);
		Assert.AreEqual(4, _inventory.EquipmentMap.Count);

		Assert.IsTrue(_inventory.EquipmentMap.ContainsKey(EEquipSlot.Head));
		Assert.IsTrue(_inventory.EquipmentMap.ContainsKey(EEquipSlot.Chest));
		Assert.IsTrue(_inventory.EquipmentMap.ContainsKey(EEquipSlot.Legs));
		Assert.IsTrue(_inventory.EquipmentMap.ContainsKey(EEquipSlot.Hands));
	}

	[Test]
	public void EquipNonEquippableItem_ShouldFail()
	{
		// Arrange
		var nonEquippableConfig = ScriptableObject.CreateInstance<InventoryItemConfig>();
		nonEquippableConfig.Item = new InventoryItem
		{
			Id    = 10,
			Flags = InventoryItemFlags.Consumable,
			Metadata = new InventoryItemMetadata
			{
				Title = "Не экипируемый предмет"
			},
			Components = new IInventoryItemComp[] { },
			Amount     = 1
		};

		_inventory.AddItem(nonEquippableConfig);

		// Act
		_inventory.EquipItem(nonEquippableConfig);

		// Assert
		Assert.IsTrue(_inventory.HasItem(nonEquippableConfig.Item.Id));
	}
}
}