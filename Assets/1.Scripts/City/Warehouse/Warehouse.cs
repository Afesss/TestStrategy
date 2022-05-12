using UnityEngine;
using Zenject;
using App.Player;
namespace App.Factory
{
    public abstract class Warehouse : MonoBehaviour
    {
        public Inventory Inventory => _inventory;
        [SerializeField] private Inventory _inventory;
        public ProductType[] ProductTypes => _productTypes;
        [SerializeField] private ProductType[] _productTypes;

        protected ProductPool ProductPool { get; private set; }
        protected Player.Player player { get; private set; }

        [Inject]
        private void Construct(ProductPool productPool, Player.Player player)
        {
            ProductPool = productPool;
            this.player = player;
        }
    }
}