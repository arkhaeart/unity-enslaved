using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Items
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Items/EquipmentSlots")]
    public class EqSlotObject : ScriptableObject
    {
        public List<EquipmentSlot> possibleSlots = new List<EquipmentSlot>();
        public Dictionary<string, Item> slotDict = new Dictionary<string, Item>();
        public void Init()
        {
            foreach(var slot in possibleSlots)
            {
                if(!slotDict.ContainsKey(slot.part))
                    slotDict.Add(slot.part, null);
            }
        }
    }
    [System.Serializable]
    public class EquipmentSlot
    {
        public string part;
        public Item item;
    }
}