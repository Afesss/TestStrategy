using System.Collections;
using UnityEngine;

namespace App.Factory
{
    public class HouseFactory : FactoryWithConsumer
    {
        protected void Start()
        {
            StartCoroutine(Production());
        }

        protected override IEnumerator Production()
        {
            while (true)
            {
                yield return new WaitForSeconds(ProductionTime);

                if (ProductionWarehouse.Inventory.IsFull)
                {
                    if (!FactoryMessage.IsActive)
                        FactoryMessage.IsActive = true;
                    FactoryMessage.SetMessage(IsFull);
                    continue;
                }

                if (!ConsumerWarehouse.Inventory.Contains(ConsumerWarehouse.ProductTypes[0]))
                {
                    if (!FactoryMessage.IsActive)
                        FactoryMessage.IsActive = true;

                    if (!ConsumerWarehouse.Inventory.Contains(ConsumerWarehouse.ProductTypes[1]))
                    {
                        FactoryMessage.SetMessage(NotInStock + ConsumerWarehouse.ProductTypes[0] +
                                                  " & " + ConsumerWarehouse.ProductTypes[1]);
                        continue;
                    }

                    FactoryMessage.SetMessage(NotInStock + ConsumerWarehouse.ProductTypes[0]);
                    continue;
                }

                if (!ConsumerWarehouse.Inventory.Contains(ConsumerWarehouse.ProductTypes[1]))
                {
                    if (!FactoryMessage.IsActive)
                        FactoryMessage.IsActive = true;
                    FactoryMessage.SetMessage(NotInStock + ConsumerWarehouse.ProductTypes[1]);
                    Debug.Log(NotInStock + ConsumerWarehouse.ProductTypes[1]);
                    continue;
                }

                if (FactoryMessage.IsActive)
                    FactoryMessage.IsActive = false;

                Product product = null;
                ConsumerWarehouse.Inventory.TryGetProduct(ref product, ConsumerWarehouse.ProductTypes[0]);
                product.IsActive = false;
                ConsumerWarehouse.Inventory.TryGetProduct(ref product, ConsumerWarehouse.ProductTypes[1]);
                product.IsActive = false;
                ProductionWarehouse.Production();
            }
        }
    }
}