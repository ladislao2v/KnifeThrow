using Code.Services.GameDataService;
using Code.Services.PauseService;
using Code.Services.ScoreService;
using Code.Services.Spawners;
using Code.Services.TimerService;

namespace Code.StateMachine.States
{
    public class InitialState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IGameDataService _gameDataService;
        private readonly IPauseService _pauseService;
        private readonly IScoreService _scoreService;
        private readonly ISpawnerService _spawnerService;
        private readonly ITimer _timer;

        public InitialState(IStateMachine stateMachine,
            IGameDataService gameDataService, 
            IPauseService pauseService,
            IScoreService scoreService,
            ISpawnerService spawnerService,
            ITimer timer)
        {
            _stateMachine = stateMachine;
            _gameDataService = gameDataService;
            _pauseService = pauseService;
            _scoreService = scoreService;
            _spawnerService = spawnerService;
            _timer = timer;
        }

        public void Enter()
        {
            InitializeGameDataService();
            InitializePauseService();

            _stateMachine.Enter<LoadDataState>();
        }

        private void InitializeGameDataService()
        {
            _gameDataService.Add(_scoreService);
        }

        private void InitializePauseService()
        {
            _pauseService.Add(_timer);
            _pauseService.Add(_spawnerService);
        }


        public void Exit() { }
    }
}