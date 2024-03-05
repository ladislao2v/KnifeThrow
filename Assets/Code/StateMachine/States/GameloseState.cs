using Code.UI.Gamelose;

namespace Code.StateMachine.States
{
    public class GameloseState : IState
    {
        private readonly GameloseOverlay _gameloseOverlay;

        public GameloseState(GameloseOverlay gameloseOverlay)
        {
            _gameloseOverlay = gameloseOverlay;
        }
        public void Enter()
        {
            _gameloseOverlay.Show();
        }

        public void Exit()
        {
            _gameloseOverlay.Hide();
        }
    }
}