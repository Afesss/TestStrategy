using UnityEngine;

namespace App.Factory
{
    public class FactoryWithConsumer : Factory
    {
        public ConsumerWarehouse ConsumerWarehouse => _consumerWarehouse;
        [SerializeField] private ConsumerWarehouse _consumerWarehouse;
    }
}