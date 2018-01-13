using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PrizeTableSystem {

    #region Public Behaviour

    public static bool CanApply (Player player) {
        return player.inventory != null && player.inventory.HasPrizes;
    }

    public static void Apply (Player player, Action<Item> OnApply = null) {
        Item prize = player.inventory.Prizes[0];
        ItemService.ConsumeItem(prize, 1)
           .Then(() => {
               ItemService.GetInventory().Then(inventory => player.SetInventory(inventory));
               CurrencyService.GetCurrency(CurrencyCode.RP).Then(currency => player.SetCurrency(currency));
           })
           .Done(() => {
               if (OnApply != null)
                   OnApply(prize);
           });
    }

    #endregion

}
