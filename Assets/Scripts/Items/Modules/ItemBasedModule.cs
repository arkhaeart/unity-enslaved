using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
namespace Units.Modules
{
    public abstract class ItemBasedModule : BehaviourModule
    {
        public class GridItem
        {
            public GridCell cell;
            public Item item;
            public GridItem(GridCell cell, Item item)
            {
                this.cell = cell;
                this.item = item;
            }
        }
        public class GridCell
        {
            public int current = -1;
            public InventoryModule module;
            public Vector2Int pos;
            public GridCell(Vector2Int pos, InventoryModule module)
            {
                current = -1;
                this.pos = pos;
                this.module = module;
            }
            public void Placed(int index)
            {
                current = index;
                module.CellsClear += Clear;
            }
            void Clear(int index)
            {
                if (current == index)
                {
                    current = -1;
                    module.CellsClear -= Clear;
                }
            }
        }
        public event System.Action DrawCall;
        public Dictionary<int, GridItem> itemsToDraw = new Dictionary<int, GridItem>();
        public ItemBasedModule(Unit _mono) : base(_mono)
        {
        }
        public abstract void AddItem(Item item, object index);
        public abstract void MoveItem(ItemBasedModule from, object index, Vector2Int pos);
        public abstract Item RemoveItem(object index);
        public abstract Item GetItem(object index);
        public void Draw()
        {
            DrawCall?.Invoke();
        }
    }
}