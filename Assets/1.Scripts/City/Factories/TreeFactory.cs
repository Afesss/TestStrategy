using System.Collections;
using UnityEngine;

namespace App.Factory
{
    public class TreeFactory : Factory
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
                    {
                        FactoryMessage.IsActive = true;
                        FactoryMessage.SetMessage(IsFull);
                    }

                    continue;
                }

                if (FactoryMessage.IsActive)
                    FactoryMessage.IsActive = false;
                ProductionWarehouse.Production();
            }
        }
    }
}