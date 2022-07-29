using System.Collections.Generic;

namespace Colisium_2
{
    class Attack
    {
        public bool IsStunSuccess { get; private set; }
        private List<float> _damages;

        public Attack(List<float> damages, bool isStun = false)
        {
            IsStunSuccess = isStun;
            _damages = damages;
        }

        public List<float> GetDamage()
        {
            List<float> damages = new List<float>();

            foreach(float damage in _damages)
            {
                damages.Add(damage);
            }

            return damages;
        }
    }
}
