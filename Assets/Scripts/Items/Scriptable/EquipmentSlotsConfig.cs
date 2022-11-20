using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Items
{
    [System.Serializable]
    [CreateAssetMenu(menuName = "Configs/EquipmentSlots")]
    public class EquipmentSlotsConfig : ScriptableObject,IDropDownFiller
    {
        public string[] possibleSlots;

        public string[] GetEntries()
        {
            return possibleSlots;
        }
    }
}