using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHandler : MonoBehaviour
{
    private GameObject house;
    
    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> _items;

    private int current_id = 0;

    private static DataHandler instance;

    public static DataHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
                
            }

            return instance;
        }
    }

    private void Start()
    {
        LoadItems();
        CreateButton();
    }

    void LoadItems()
    {
        var items_obj = Resources.LoadAll("Items", typeof(Item));
        foreach (var item in items_obj)
        {
            _items.Add(item as Item);
        }
    }


    void CreateButton()
    {
        foreach (var item in _items)
        {
            ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);
            b.ItemId = current_id;
            b.ButtonTexture = item.itemImage;
            current_id++;
        }
    }

    public void SetHouse(int id)
    {
        house = _items[id].itemPrefab;
    }

    public GameObject GetHouse()
    {
        return house;
    }
}
