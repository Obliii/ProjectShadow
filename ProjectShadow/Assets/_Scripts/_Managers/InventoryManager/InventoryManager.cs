using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryUI;

    [SerializeField] private GameObject[] _inventorySlots;
    [SerializeField] private GameObject[] _inventorySelectors;

    public List<InventoryItem> inventoryItems;



}
