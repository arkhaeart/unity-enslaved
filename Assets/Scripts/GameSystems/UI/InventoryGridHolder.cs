using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
namespace UI
{
    public class InventoryGridHolder : MonoBehaviour
    {

        public event System.Action<InventoryGridHolder,int, MyTuple> ItemMoved;
        public string holderType;
        public RectTransform cellExample;
        public int height, width;
        public Dictionary<int,InventoryGridItem> currentlyDrawn = new Dictionary<int, InventoryGridItem>();
        public InventoryGridCell[] cells;
        public InventoryGridCell[,] cellGrid;

        private void Awake()
        {

            DrawManager.holderRegistry.Add(this);
            InitCells();
            
        }

        protected virtual void InitCells()
        {
            if (height * width != cells.Length)
                throw new System.Exception("Wrong inventory holder settings!");
            cellExample = cells[0].GetComponent<RectTransform>();
            cellGrid = new InventoryGridCell[width, height];
            for (int i = 0; i < cells.Length; i++)
            {
                int x = i % width;
                int y = i / width;
                cells[i].pos = new MyTuple(x, y);
                cells[i].holder = this;
                cellGrid[x, y] = cells[i];
            }
        }
        //int CellIndex(InventoryGridCell cell)
        //{
        //    int x = cell.pos.Item1;
        //    int y = cell.pos.Item2 * width;
        //    return x + y;
        //}

        private void OnEnable()
        {
            UpdateDrawnItems();
        }
        void UpdateDrawnItems()
        {

        }
        public void DrawItem(InventoryGridItem item, MyTuple pos,int index)
        {
            InventoryGridCell cell = cellGrid[pos.Item1, pos.Item2];
            item.transform.position = cell.transform.position;
            item.image.enabled = true;
            item.cell = cell;
            currentlyDrawn[index] = item;

        }
        public InventoryGridItem GiveItem(int index)
        {
            InventoryGridItem item = currentlyDrawn[index];
            currentlyDrawn.Remove(index);
            item.image.enabled = false;
            return item;
        }
        public void OnItemMoved(InventoryGridItem item, MyTuple pos)
        {

            ItemMoved?.Invoke(item.cell.holder, item.invIndex, pos);
        }
    }
}
