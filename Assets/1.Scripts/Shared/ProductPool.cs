using System.Collections.Generic;
using UnityEngine;

namespace App.Factory
{
    public class ProductPool : MonoBehaviour
    {
        [SerializeField] private Product prefab;
        [SerializeField] private Material[] _materials;
        private float poolSpawnCount = 500;
        private List<Product> _pool;

        private void Awake()
        {
            _pool = new List<Product>();
            for (var i = 0; i < poolSpawnCount; i++)
            {
                InstantiateProduct();
            }
        }

        public void GetProduct(ref Product product, ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Tree:
                    product = GetFreeProduct(ProductType.Tree);
                    product.Material = _materials[0];
                    break;
                case ProductType.Glass:
                    product = GetFreeProduct(ProductType.Glass);
                    product.Material = _materials[1];
                    break;
                case ProductType.House:
                    product = GetFreeProduct(ProductType.House);
                    product.Material = _materials[2];
                    break;
            }
        }

        private Product GetFreeProduct(ProductType productType)
        {
            for (var i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].IsActive)
                {
                    _pool[i].Type = productType;
                    _pool[i].IsActive = true;
                    return _pool[i];
                }
            }

            var product = InstantiateProduct();
            product.Type = productType;
            product.IsActive = true;
            return product;
        }

        private Product InstantiateProduct()
        {
            var obj = Instantiate(prefab.gameObject, transform);
            obj.SetActive(false);

            var product = obj.GetComponent<Product>();
            _pool.Add(product);
            return product;
        }
    }
}