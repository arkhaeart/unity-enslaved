using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Units
{
    public class ModifiableParameter
    {
        public float raw;
        public float Get { get => modificators.Count > 0 ? modificators[modificators.Count - 1].result : raw; }
        public float GetSqr { get => (raw * raw); }
        public ModifiableParameter(float _raw)
        {
            raw = _raw;
        }
        protected List<Modificator> modificators = new List<Modificator>();
        protected void Recalculate()
        {

        }
        public virtual void AddModificator(Modificator modificator)
        {
            modificators.Last().nextMod = modificator;
            modificators.Add(modificator);
            Recalculate();
        }
    }
    public class Modificator
    {
        [HideInInspector] public Modificator nextMod;
        public float result;
    }
}