using App.UI;
using UnityEngine;

namespace App.Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Joystick _joystick;
        [SerializeField, Range(0, 10)] private float _moveSpeed;

        private Vector3 _moveDirection, _nextPos;

        private void Start()
        {
            _joystick.Dragged += JoystickOnDragged;
        }

        private void OnDestroy()
        {
            _joystick.Dragged -= JoystickOnDragged;
        }

        private void JoystickOnDragged(Vector2 direction)
        {
            _moveDirection = direction;
        }

        private void FixedUpdate()
        {
            if (_moveDirection == Vector3.zero)
            {
                if (_rigidbody.velocity != Vector3.zero)
                    _rigidbody.velocity = Vector3.zero;
                return;
            }

            _nextPos = transform.position + new Vector3(_moveDirection.x, 0, _moveDirection.y)
                * _moveSpeed * Time.deltaTime;
            _rigidbody.MovePosition(_nextPos);
            transform.LookAt(_nextPos);
        }
    }
}