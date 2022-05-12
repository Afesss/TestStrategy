using System;
using UniRx;
using UnityEngine;

namespace App.Factory
{
    public class ConsumerWarehouse : Warehouse
    {
        private bool _canTriggered;

        private void Start()
        {
            _canTriggered = true;
        }

        private void OnTriggerStay(Collider other)
        {
            if (!_canTriggered) return;
            _canTriggered = false;
            Observable.Timer(TimeSpan.FromSeconds(0.1f)).Subscribe(t => { _canTriggered = true; });

            for (var i = 0; i < ProductTypes.Length; i++)
            {
                player.GetProduct(Inventory, ProductTypes[i]);
            }
        }
    }
}