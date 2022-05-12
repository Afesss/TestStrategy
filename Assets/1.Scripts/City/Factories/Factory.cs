using System.Collections;
using UnityEngine;

namespace App.Factory
{
    public abstract class Factory : MonoBehaviour
    {
        protected float ProductionTime => _productionTime;
        [SerializeField] private float _productionTime = 1;
        protected ProductionWarehouse ProductionWarehouse => _productionWarehouse;
        [SerializeField] private ProductionWarehouse _productionWarehouse;
        protected FactoryMessage FactoryMessage => _factoryMessage;
        [SerializeField] private FactoryMessage _factoryMessage;

        protected readonly string IsFull = "Is Full";
        protected readonly string NotInStock = "Not in stock: ";

        protected virtual IEnumerator Production()
        {
            yield break;
        }
    }
}