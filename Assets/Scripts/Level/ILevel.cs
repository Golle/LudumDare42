using System.Collections.Generic;
using Assets.Scripts.Items;

namespace Assets.Scripts.Level
{
    internal interface ILevel
    {
        int Rounds  { get; }
        float TimeBetweenRounds { get; }
        IEnumerable<IItem> GetRandomItems(int extraItems);
    }
}