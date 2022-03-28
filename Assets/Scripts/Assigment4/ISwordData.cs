using System.Collections.Generic;

namespace Assigment4
{
    public interface ISwordData
    {
        int GetTotalDamage();
        
        //The reason to insert it - to showcase that it can be actually used in game
        Dictionary<Elements, int> GetElementsDamage();
        string GetTextDamage();
        
    }
}