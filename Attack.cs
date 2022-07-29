using System.Collections.Generic;

namespace Colisium_2
{
    class Attack
    {
        public IReadOnlyList<float> Damages;

        public bool IsStunSuccess { get; private set; }

        public Attack(List<float> damages, bool isStunSuccess = false)
        {
            IsStunSuccess = isStunSuccess;
            Damages = damages;
        }
    }
}
