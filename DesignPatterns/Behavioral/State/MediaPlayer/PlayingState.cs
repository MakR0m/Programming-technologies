namespace DesignPatterns.Behavioral.State.MediaPlayer
{
    internal class PlayingState : IPlayerState
    {
        public void PressButton(MPlayer player)
        {
            Console.WriteLine("Проигрывание приостановлено");
            player.SetState(new PausedState());
        }
    }
}