using System;
using Realms;

namespace TotalTech.Models
{
    public class State : RealmObject
    {
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
