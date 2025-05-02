namespace DesignPatterns.Behavioral.State.MediaPlayer
{
    public class MPlayer
    {
        private IPlayerState _state;

        public MPlayer(IPlayerState initialState)
        {
            _state = initialState;
        }

        public void SetState(IPlayerState newState)
        {
            _state = newState;
        }

        public void PressButton()
        {
            _state.PressButton(this);
        }
    }
}