using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.UI
{
    public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Image _image;
        [SerializeField] private Canvas _rootCanvas;
        [SerializeField, Range(0, 20)] private float stickMoveSpeed = 20;
        [SerializeField, Range(0, 200)] private float stickThresholdMagnitude = 140f;
        [SerializeField, Range(0, 1)] private float _timeToOriginPos = 0.2f;

        public event Action<Vector2> Dragged;

        private Vector2 _originPos, _clickPos;

        private void Start()
        {
            _originPos = transform.position;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _clickPos = eventData.position;
            transform.position = _clickPos;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var direction = eventData.position - _clickPos;
            Dragged?.Invoke(direction.normalized);

            var newPos = direction.magnitude < stickThresholdMagnitude / _rootCanvas.scaleFactor
                ? eventData.position
                : _clickPos + direction.normalized * stickThresholdMagnitude / _rootCanvas.scaleFactor;
            MoveStick(newPos);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Dragged?.Invoke(Vector2.zero);
            transform.DOMove(_originPos, _timeToOriginPos);
        }

        private void MoveStick(Vector3 newPos)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, stickMoveSpeed * Time.deltaTime);
        }
    }
}