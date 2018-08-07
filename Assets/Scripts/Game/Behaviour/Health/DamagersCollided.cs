using System.Collections.Generic;
using Game.Behaviour.Damage;

namespace Game.Behaviour.Health
{
    public struct DamagersCollided
    {
        public List<Damager> List { get { return list; } }

        public DamagersCollided(List<Damager> pList)
        {
            var newList = new List<Damager>();
            this.list = newList;
            newList.AddRange(pList);
        }

        private List<Damager> list;

        public override string ToString()
        {
            return "DamagersCollided { List count : " + List.Count + "}";
        }
    }
}
