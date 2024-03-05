using Code.Services.Spawners;
using Code.Services.TimerService;
using Code.UI.Gameplay;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Code.StateMachine.States
{
    public class GameloopState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly GameplayOverlay _gameplayOverlay;
        private readonly ISpawnerService _spawnerService;
        private readonly ITimer _timer;

        public GameloopState(IStateMachine stateMachine, 
            GameplayOverlay gameplayOverlay, 
            ISpawnerService spawnerService,
            ITimer timer)
        {
            _stateMachine = stateMachine;
            _gameplayOverlay = gameplayOverlay;
            _spawnerService = spawnerService;
            _timer = timer;
        }

        public void Enter()
        {
            _gameplayOverlay.Show();
            _spawnerService.Start();
            _timer.TimeOut += OnTimeOut;
            _timer.Start();
        }

        public void Exit()
        {
            _spawnerService.Stop();
            _gameplayOverlay.Hide();
        }

        private void OnTimeOut()
        {
            _stateMachine.Enter<GameloseState>();
        }
    }
}
