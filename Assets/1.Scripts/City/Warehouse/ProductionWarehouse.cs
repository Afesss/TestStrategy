using System;
using UniRx;
using UnityEngine;

namespace App.Factory
{
    public class ProductionWarehouse : Warehouse
    {
        private bool _canTriggered;

        private void Start()
        {
            _canTriggered = true;
        }

        public void Production()
        {
            Product product = null;
            ProductPool.GetProduct(ref product, ProductTypes[0]);
            Inventory.SetProduct(product, false);
        }

        private void OnTriggerStay(Collider other)
        {
            if(!_canTriggered) return;
            _canTriggered = false;
            Observable.Timer(TimeSpan.FromSeconds(0.1f)).Subscribe(t =>
            {
                _canTriggered = true;
            });
            if (!Inventory.IsEmpty)
            {
                player.SetProduct(Inventory);
            }
        }
    }
}
