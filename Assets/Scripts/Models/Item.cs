using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item {

    #region Fields / Properties

    public string id;
    public string instanceID;
    public string name;
    public ItemType type;
    public int amount;

    #endregion

    #region Public Behaviour

    public Item (string id, string instanceID, string name, ItemType type, int amount) {
        this.id = id;
        this.instanceID = instanceID;
        this.name = name;
        this.type = type;
        this.amount = amount;
    }

    #endregion

}