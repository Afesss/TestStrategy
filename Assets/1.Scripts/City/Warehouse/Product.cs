using DG.Tweening;
using UnityEngine;

namespace App.Factory
{
    public class Product : MonoBehaviour
    {
        [SerializeField] private ProductType type;
        [SerializeField] private MeshRenderer _meshRenderer;

        private Tween _moveTween;

        public ProductType Type
        {
            get => type;
            set => type = value;
        }

        public bool IsActive
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public Material Material
        {
            get => _meshRenderer.material;
            set => _meshRenderer.material = value;
        }

        public Transform Parent
        {
            get => transform.parent;
            set => transform.parent = value;
        }

        public void DoLocalMove(Vector3 localPos, float duration)
        {
            _moveTween?.Kill();
            _moveTween = transform.DOLocalMove(localPos, duration);
        }

        public void DoLocalMove(Vector3 localPos)
        {
            _moveTween?.Kill();
            transform.localPosition = localPos;
        }
    }
}