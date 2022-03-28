using System.Collections.Generic;

namespace Assigment4.DecoratorClasses
{
    public class SwordFireEnchantment : SwordElementalEnchant
    {
        public SwordFireEnchantment(ISwordData swordData) : base(swordData)
        {
        }
        
        public override int GetTotalDamage()
        {
            return base.GetTotalDamage() + 10;
        }

        public override Dictionary<Elements, int> GetElementsDamage()
        {
            var dictionary = base.GetElementsDamage();
            if(!dictionary.ContainsKey(Elements.Fire))
                dictionary.Add(Elements.Fire, 0);
            dictionary[Elements.Fire] += 10;
            return dictionary;
        }

        public override string GetTextDamage()
        {
            return base.GetTextDamage()+ "\n <b><color=#E25822>Fire</color> damage = <color=#E25822>10</color></b>";
        }
    }
}