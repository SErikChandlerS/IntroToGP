using System.Collections.Generic;

namespace Assigment4.DecoratorClasses
{
    public class SwordHolyEnchantment : SwordElementalEnchant
    {
        public SwordHolyEnchantment(ISwordData swordData) : base(swordData)
        { }

        public override int GetTotalDamage()
        {
            return base.GetTotalDamage() + 10;
        }

        public override Dictionary<Elements, int> GetElementsDamage()
        {
            var dictionary = base.GetElementsDamage();
            if(!dictionary.ContainsKey(Elements.Holy))
                dictionary.Add(Elements.Holy, 0);
            dictionary[Elements.Holy] += 10;
            return dictionary;
        }

        public override string GetTextDamage()
        {
            return base.GetTextDamage()+ "\n <b><color=#FFFF8A>Holy</color> damage = <color=#FFFF8A>10</color></b>";
        }
    }
}