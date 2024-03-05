using System;
using Code.Services.PauseService;
using Code.Services.ScoreService;
using Code.Services.ShootService;
using Code.Services.TimerService;
using UnityEngine;
using Zenject;

namespace Code.UI.Gameplay
{
    public class GameplayOverlay : Overlay
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private TimerView _timerView;
        [SerializeField] private PauseButton _pauseButton;
        [SerializeField] private BulletsView _bulletsView;
        [SerializeField] private ReloadView _reloadView;
        
        private IScoreService _scoreService;
        private IPauseService _pauseService;
        private ITimer _timer;
        private IShootService _shootService;

        [Inject]
        private void Construct(IScoreService scoreService, 
            IPauseService pauseService, 
            IShootService shootService, 
            ITimer timer)
        {
            _shootService = shootService;
            _timer = timer;
            _pauseService = pauseService;
            _scoreService = scoreService;
        }

        private void OnEnable()
        {
            _scoreService.ScoreChanged += _scoreView.OnScoreChanged;
            _timer.Ticked += _timerView.Render;
            _shootService.Reloaded += _bulletsView.Reset;
            _shootService.Shooted += _bulletsView.OnShot;
            _shootService.BulletsEnded += _reloadView.Show;
            _shootService.Reloaded += _reloadView.Hide;
            _pauseButton.Subscribe(OnPauseButtonClicked);
        }

        private void OnDisable()
        {
            _scoreService.ScoreChanged -= _scoreView.OnScoreChanged;
            _timer.Ticked -= _timerView.Render;
            _shootService.Reloaded -= _bulletsView.Reset;
            _shootService.Shooted -= _bulletsView.OnShot;
            _shootService.BulletsEnded -= _reloadView.Show;
            _shootService.Reloaded -= _reloadView.Hide;
            _pauseButton.Unsubscribe(OnPauseButtonClicked);
        }

        private void OnPauseButtonClicked(bool value)
        {
            if(value)
                _pauseService.Resume();
            else
                _pauseService.Pause();    
        }
    }
}