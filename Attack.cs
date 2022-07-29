using System.Collections.Generic;

namespace Colisium_2
{
    class Attack
    {
        private List<float> _damages;
        public IReadOnlyList<float> Damages => _damages;

        public bool IsStunSuccess { get; private set; }

        public Attack(List<float> damages, bool isStun = false)
        {
            IsStunSuccess = isStun;
            _damages = damages;
        }
    }
}
