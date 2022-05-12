using UnityEngine;

namespace App.Player
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _camOffset;
        [SerializeField] private float _chaseSpeed;

        private void FixedUpdate()
        {
            var pos = _target.position + _camOffset;
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * _chaseSpeed);
            transform.LookAt(_target);
        }
    }
}