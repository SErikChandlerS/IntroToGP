using System.Collections.Generic;

namespace Assigment4
{
    public class SwordElementalEnchant : ISwordData
    {
        private readonly ISwordData _swordData;

        public SwordElementalEnchant(ISwordData swordData)
        {
            _swordData = swordData;
        }

        public virtual int GetTotalDamage()
        {
           return _swordData.GetTotalDamage();
        }
        public virtual Dictionary<Elements, int> GetElementsDamage()
        {
            return _swordData.GetElementsDamage();
        }
        public virtual string GetTextDamage()
        {
            return _swordData.GetTextDamage();
        }
    }
}