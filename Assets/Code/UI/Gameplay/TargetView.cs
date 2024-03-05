using System;
using Code.Services.PauseService;
using Code.Services.ScoreService;
using Code.Services.ShootService;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Code.UI.Gameplay
{
    public class TargetView : MonoBehaviour, IPointerClickHandler, IPausable
    {
        [SerializeField] private int _scorePoints;
        [SerializeField] private float _lifeTime;

        private IShootService _shootService;
        private IScoreService _scoreService;
        private bool _isHit;
        private Sequence _sequence;

        public event Action Hit;

        [Inject]
        private void Construct(IShootService shootService, IScoreService scoreService)
        {
            _shootService = shootService;
            _scoreService = scoreService;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide() 
        {
            gameObject.SetActive(false);
        }

        public void Move()
        {
            _sequence = DOTween.Sequence();

            _sequence
                .Append(transform.DOMove(transform.position + (Vector3.down * 2 * Screen.height), _lifeTime))
                .AppendCallback(() => Hide());
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(_isHit)
                return;

            _shootService.Shoot();
            _scoreService.Add(_scorePoints);
            _isHit = true;
            Hit?.Invoke();
        }

        public void OnPause()
        {
            DOTween.PauseAll();
        }

        public void OnResume()
        {
            DOTween.RestartAll();
        }
    }
}
