using System.Collections.Generic;

namespace Assigment4.DecoratorClasses
{
    public class SwordDarknessEnchantment : SwordElementalEnchant
    {
        public SwordDarknessEnchantment(ISwordData swordData) : base(swordData)
        { }

        public override int GetTotalDamage()
        {
            return base.GetTotalDamage() + 10;
        }

        public override Dictionary<Elements, int> GetElementsDamage()
        {
            var dictionary = base.GetElementsDamage();
            if(!dictionary.ContainsKey(Elements.Darkness))
                dictionary.Add(Elements.Darkness, 0);
            dictionary[Elements.Darkness] += 10;
            return dictionary;
        }

        public override string GetTextDamage()
        {
            return base.GetTextDamage()+ "\n <b><color=#4B0082>Darkness</color> damage = <color=#4B0082>10</color></b>";
        }
    }
}