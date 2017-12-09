using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;


public class ItemService : BaseService {

    #region Public Behaviour

    public static void GetInventory (Action<Inventory> OnGetInventorySuccess) {
        var request = new GetUserInventoryRequest();
        PlayFabClientAPI.GetUserInventory(request, (result) => {
            Inventory inventory = InventoryFromItemInstanceList(result.Inventory);
            if (OnGetInventorySuccess != null && inventory != null) OnGetInventorySuccess(inventory);
            SuccessCallback(result);
        }, ErrorCallback);
    }

    public static void ConsumeItem (Item item, int count, Action OnPurchaseItemSuccess = null) {
        var request = new ConsumeItemRequest { ItemInstanceId = item.instanceID , ConsumeCount = count};
        PlayFabClientAPI.ConsumeItem(request, (result) => {
            if (OnPurchaseItemSuccess != null) OnPurchaseItemSuccess();
            SuccessCallback(result);
        }, ErrorCallback);
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