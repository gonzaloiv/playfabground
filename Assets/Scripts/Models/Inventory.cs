using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class Inventory {

    #region Fields / Properties

    public bool HasPrizes { get { return items.Any(item => item.type == ItemType.Prize); } }
    public List<Item> Prizes { get { return items.Where(item => item.type == ItemType.Prize).ToList(); } }
    public List<Item> items = new List<Item>();

    #endregion

    #region Public Behaviour

    public void SetItems (List<Item> items) {
        this.items = items;
    }

    #endregion

}