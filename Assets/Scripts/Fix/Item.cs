﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	public string item_name = "New Item";
	public Sprite icon = null;
	public bool isDefault = false;



}
