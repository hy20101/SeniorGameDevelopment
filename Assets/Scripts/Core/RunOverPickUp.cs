using GameDevTV.Inventories;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryExample.Control
{
    [RequireComponent(typeof(Pickup))]

    public class RunOverPickUp : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (other.gameObject == player)
            {
                GetComponent<Pickup>().PickupItem();
            }
        }
    }
}
