using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.State.MediaPlayer
{
    public interface IPlayerState
    {
        void PressButton(MPlayer player);
    }
}
