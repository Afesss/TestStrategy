using TMPro;
using UnityEngine;

namespace App.Factory
{
    public class FactoryMessage : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;
        [SerializeField] private Transform _camTransform;

        public bool IsActive
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public void SetMessage(string message)
        {
            _tmpText.text = message;
        }

        private void Update()
        {
            transform.LookAt(_camTransform);
        }
    }
}