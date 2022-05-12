using System.Collections.Generic;
using App.Factory;
using UnityEngine;

namespace App
{
    public class Inventory : MonoBehaviour
    {
        public float Capacity => _capacity;
        [SerializeField] private float _capacity;
        [SerializeField] private Vector3 _columCount;
        [SerializeField] private Vector3 _spawnOffset;

        public bool IsFull => _savedProducts.Count >= _capacity;
        public bool IsEmpty => _savedProducts.Count == 0;
        public int CurrentCapacity => _savedProducts.Count;
        private readonly float moveTime = 0.3f;

        private List<Product> _savedProducts;

        private Vector3 _offset, _colum;

        private void Awake()
        {
            _savedProducts = new List<Product>();
        }

        public bool Contains(ProductType productType)
        {
            for (var i = 0; i < _savedProducts.Count; i++)
            {
                if (_savedProducts[i].Type == productType)
                    return true;
            }

            return false;
        }

        public bool TryGetProduct(ref Product product, ProductType productType)
        {
            for (var i = 0; i < _savedProducts.Count; i++)
            {
                if (_savedProducts[i].Type == productType)
                {
                    product = _savedProducts[i];
                    _savedProducts.RemoveAt(i);
                    SortProducts();
                    return true;
                }
            }

            return false;
        }

        public Product GetProduct()
        {
            var product = _savedProducts[0];
            _savedProducts.RemoveAt(0);
            SortProducts();
            return product;
        }

        public void SetProduct(Product product, bool useInterpolation)
        {
            product.Parent = transform;
            _savedProducts.Add(product);
            SortProduct(product, useInterpolation);
        }

        private void SortProducts()
        {
            _offset = Vector3.zero;
            _colum = Vector3.zero;

            for (var i = 0; i < _savedProducts.Count; i++)
            {
                SortProduct(_savedProducts[i], true);
            }
        }

        private void SortProduct(Product product, bool useInterpolation)
        {
            if (useInterpolation)
            {
                product.DoLocalMove(_offset, moveTime);
            }
            else
                product.DoLocalMove(_offset);

            product.transform.localRotation = Quaternion.Euler(Vector3.zero);
            IncrementOffset();
        }

        private void IncrementOffset()
        {
            _offset.x += _spawnOffset.x;
            _colum.x++;
            if (_colum.x >= _columCount.x)
            {
                _colum.z++;
                _offset.z += _spawnOffset.z;
                _colum.x = 0;
                _offset.x = 0;
            }

            if (_colum.z >= _columCount.z)
            {
                _offset.y += _spawnOffset.y;
                _colum.z = 0;
                _offset.z = 0;
            }
        }
    }
}