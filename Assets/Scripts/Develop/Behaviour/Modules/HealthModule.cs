using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Develop.Behaviour.Modules
{
    public class HealthModule :IBehaviourModule
    {
        private int maxHP;
        private int currentHP;
        public HealthModule(int maxHP)
        {
            this.maxHP = maxHP;
            currentHP = maxHP;
        }
        public bool WithdrawHealth(int damage)
        {
            currentHP -= damage;
            return currentHP > 0;
        }
        public int GetHP => currentHP;
    }
    public class InventoryModule : IBehaviourModule
    {

    }
    public class EquipmantModule:IBehaviourModule
    {

    }
}