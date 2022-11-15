using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;
using Items;
using GameSystems;
namespace Units.Modules
{
    public class EquipmentModule : ItemBasedModule
    {
        
        public enum Type
        {
            CHARACTER,
            WORKSHOP
        }
        public Type type;
        public Dictionary<string, Item> slots;
        public EquipmentModule(Unit _mono,Type type) : base(_mono)
        {
            this.type = type;
            InitSlots();
        }
        void InitSlots()
        {
            if(type== Type.CHARACTER)
            {
                slots = new Dictionary<string,Item>(SettingsManager.Instance.eqSlots.slotDict);
            }
            else
                slots = new Dictionary<string, Item>(SettingsManager.Instance.workShopSlots.slotDict);
        }
        public override void AddItem(Item item, object index)
        {

                if (index is string i)
                {
                    slots[i] = item;
                    Draw();
                }
            
        }
        public override Item GetItem(object index)
        {
            if (index is string i)
                return (Item)slots[i];
            else return null;
        }
        public override void MoveItem(ItemBasedModule from, object index, MyTuple pos)
        {
            Item item = from.GetItem(index);
            string slot="";
            if(type== Type.CHARACTER)
            {
                if(item is IEquipable equip)
                {
                    slot = equip.Slot;
                }
            }
            else
            {
                slot = $"reagent_{pos.Item1}";
            }
            Item removed = RemoveItem(slot);
            AddItem(item, slot);
            if (removed != null)
                from.AddItem(removed,null);
        }
        public override Item RemoveItem(object index)
        {
            if(index is string i)
            {
                Item item= (Item)slots[i];
                slots[i] = null;
                Draw();
                return item;
            }
            throw new System.NotImplementedException();
        }
    }
}