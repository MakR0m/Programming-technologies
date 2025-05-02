namespace DesignPatterns.Behavioral.State.MediaPlayer
{
    internal class PausedState : IPlayerState
    {
        public void PressButton(MPlayer player)
        {
            Console.WriteLine("Возобновление воспроизведения");
            player.SetState(new PlayingState());
        }
    }
}