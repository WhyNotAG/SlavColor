using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
   [SerializeField] private AssetItem _item;
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.GetComponent<PlayerMovement>() != null)
      {
         //FindObjectOfType<Inventory>().AddItem(this._item);
         Destroy(this.gameObject);
      }
   }
   
}
