using Code.UI.Gameplay;
using DG.Tweening;
using UnityEngine;

namespace Code.Animations
{
    public class TargetDieAnimation : MonoBehaviour
    {
        [SerializeField] private TargetView _targetView;
        
        [Header("Scale")]
        [SerializeField] private float _maxScaleValue;
        [SerializeField] private float _minScaleValue;
        
        [Header("Duration")]
        [SerializeField] private float _durationToMaxScale;
        [SerializeField] private float _durationToMinScale;

        [Header("Jumping")] 
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _jumpForce;
        [SerializeField] private int _jumpCount;
        [SerializeField] private float _jumpDuration;

        private void OnEnable()
        {
            _targetView.Hit += OnHit;
        }

        private void OnDisable()
        {
            _targetView.Hit -= OnHit;
        }

        private void OnHit()
        {
            Sequence sequence = DOTween.Sequence();
            
            sequence
                .Append(_targetView.transform.DOJump(
                    _targetView.transform.position + (Vector3.up * _jumpHeight), 
                    _jumpForce, 
                    _jumpCount, 
                    _jumpDuration))
                .Insert(0,_targetView.transform.DOScale(_maxScaleValue, _durationToMaxScale))
                .Append(_targetView.transform.DOScale(_minScaleValue, _durationToMinScale))
                .AppendCallback(() => _targetView.Hide());
        }
    }
}
