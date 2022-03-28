using Assigment4.DecoratorClasses;
using UnityEngine;

namespace Assigment4
{
    public class PlayerSwordHandler : MonoBehaviour
    {
        [SerializeField] private int baseDamage = 10;
        
        private ISwordData _baseSwordData;
        private ISwordData _currentSwordProvider;

        private void Awake()
        {
            _baseSwordData = new BaseSwordData(baseDamage);
            _currentSwordProvider = _baseSwordData;
            
            PrintCurrentDamage();
            
            AddFireEnchantment();
            AddDarknessEnchantment();
            PrintCurrentDamage();
            
            AddHolyEnchantment();
            PrintCurrentDamage();
            
            ResetProvider();
            PrintCurrentDamage();
        }

        //TO USE ADD NAUGHTY ATTRIBUTE OR OTHER PLUGIN[Button()]
        public void AddFireEnchantment()
        {
            _currentSwordProvider = new SwordFireEnchantment(_currentSwordProvider);
        }
        
        //TO USE ADD NAUGHTY ATTRIBUTE OR OTHER PLUGIN[Button()]
        public void AddHolyEnchantment()
        {
            _currentSwordProvider = new SwordHolyEnchantment(_currentSwordProvider);
        }
        
        //TO USE ADD NAUGHTY ATTRIBUTE OR OTHER PLUGIN[Button()]
        public void AddDarknessEnchantment()
        {
            _currentSwordProvider = new SwordDarknessEnchantment(_currentSwordProvider);
        }
        
        //TO USE ADD NAUGHTY ATTRIBUTE OR OTHER PLUGIN [Button()]
        public void PrintCurrentDamage()
        {
            Debug.Log(_currentSwordProvider.GetTextDamage());
        }
        
        //TO USE ADD NAUGHTY ATTRIBUTE OR OTHER PLUGIN[Button()]
        public void ResetProvider()
        {
            _currentSwordProvider = _baseSwordData;
        }
    }
}
