using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Llave Object", menuName = "Inventory System / Items / Llave")]
public class Llave : ItemObject
{
    private void Awake()
    {
        type = ItemType.Llave;
    }
}
