using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.State.MediaPlayer
{
    internal class StoppedState : IPlayerState
    {
        public void PressButton(MPlayer player)
        {
            Console.WriteLine("Воспроизведение начато");
            player.SetState(new PlayingState());
        }
    }
}
