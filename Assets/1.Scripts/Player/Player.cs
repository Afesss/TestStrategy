using App.Factory;
using UnityEngine;

namespace App.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;

        public void GetProduct(Inventory warehouse, ProductType productType)
        {
            Product product = null;
            if (_inventory.TryGetProduct(ref product, productType))
            {
                warehouse.SetProduct(product, true);
            }
        }

        public void SetProduct(Inventory warehouse)
        {
            Product product;
            if (_inventory.CurrentCapacity < _inventory.Capacity)
            {
                product = warehouse.GetProduct();
                _inventory.SetProduct(product, true);
            }
        }
    }
}