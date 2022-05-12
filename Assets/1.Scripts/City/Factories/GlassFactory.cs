using System.Collections;
using UnityEngine;

namespace App.Factory
{
    public class GlassFactory : FactoryWithConsumer
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
                    FactoryMessage.SetMessage(NotInStock + ConsumerWarehouse.ProductTypes[0]);
                    continue;
                }

                if (FactoryMessage.IsActive)
                    FactoryMessage.IsActive = false;
            
                Product product = null;
                if (ConsumerWarehouse.Inventory.TryGetProduct(ref product, ConsumerWarehouse.ProductTypes[0]))
                {
                    product.IsActive = false;
                }
            
                ProductionWarehouse.Production();
            }
        }
    }
}

