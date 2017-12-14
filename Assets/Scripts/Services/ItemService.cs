using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using RSG;

public class ItemService : BaseService {

    #region Public Behaviour

    public static Promise<Inventory> GetInventory () {
        var promise = new Promise<Inventory>();
        var request = new GetUserInventoryRequest();
        PlayFabClientAPI.GetUserInventory(request, (result) => {
            try {
                Inventory inventory = InventoryFromItemInstanceList(result.Inventory);
                SuccessCallback(result);
                promise.Resolve(inventory);
            } catch (Exception ex) {
                promise.Reject(ex);
            }
        }, ErrorCallback);
        return promise;
    }

    public static Promise ConsumeItem (Item item, int count) {
        var promise = new Promise();
        var request = new ConsumeItemRequest { ItemInstanceId = item.instanceID, ConsumeCount = count };
        PlayFabClientAPI.ConsumeItem(request, (result) => {
            promise.Resolve();
            SuccessCallback(result);
        }, ErrorCallback);
        return promise;
    }

    public static Inventory InventoryFromItemInstanceList (List<ItemInstance> itemInstances) {
        if (itemInstances == null || itemInstances.Count == 0)
            return null;
        Inventory inventory = new Inventory();
        foreach (ItemInstance itemInstance in itemInstances) {
            ItemType type = ItemType.None;
            try { type = (ItemType) Enum.Parse(typeof(ItemType), itemInstance.ItemClass); } catch { Debug.Log(type); }
            inventory.items.Add(new Item(itemInstance.ItemId, itemInstance.ItemInstanceId, itemInstance.DisplayName, type, itemInstance.RemainingUses.Value));
        }
        return inventory;
    }

    #endregion

}