﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item> ();
	private bool showInventory;
	private ItemDatabase database; 

	// Use this for initialization
//	void Start () {
//		for (int i= 0; i<(slotsX*slotsY); i++)
//		{
//			slots.Add(new Item());
//			inventory.Add(new Item());
//		}
//		database = GameObject.FindGameObjectsWithTag("Item Database").GetComponent<ItemDatabase>();
//		 
//	}

	void Update()
	{
		if (Input.GetButtonUp ("i")) {
			showInventory = !showInventory;
	
		}
	}

	void OnGUI()
	{
		GUI.skin = skin;
		if (showInventory)
		{
			DrawInventory();
		}

		for(int i = 0; i < inventory.Count; i++) 
		{
			GUI.Label(new Rect(10, 10, 200, 50), inventory[i].itemName);
		}
	}

	void DrawInventory()
	{
		for (int x = 0; x <slotsX; x++)
		{
			for (int y=0; y <slotsY; y++)
			{
				Rect slotRect = new Rect(x*60, y*60, 50, 50);
				GUI.Box(slotRect, "", skin.GetStyle("Slot"));
			}
		}
	}

}
