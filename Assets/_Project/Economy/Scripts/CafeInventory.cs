using System.Collections.Generic;
using UnityEngine;

public class CafeInventory : MonoBehaviour
{
    List<CafeItem> ItemsInStock;

    public List<CafeItem> GetItemsInStock()
    {
        return ItemsInStock;
    }

    public void AddItemToStock(CafeItem item)
    {
        ItemsInStock.Add(item);
    }

    public void RemoveItemFromStock(CafeItem item)
    {
        ItemsInStock.Remove(item);
    }
}
