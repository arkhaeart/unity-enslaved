using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;
namespace GameSystems
{
    public class UIManager : Singleton<UIManager>
    {
        public Transform HUD;
        public InventoryGridHolder playerInventory,otherInventory,chestInventory,barterInventory;
        public DnDPlatform platform;
        
        private void Start()
        {

            InputManager.Instance.DragResponse += platform.Init;
            InputManager.Instance.DropResponse += platform.Drop;
            InputManager.Instance.DropStopResponse += platform.Stop;
            InventoryDrawer.InventoryHolderToggle += OtherInventoryResponse;
        }

    
        void ToggleWindowActive(GameObject window)
        {
            window.SetActive(!window.activeSelf);
        }
        void OtherInventoryResponse(InventoryGridHolder holder)
        {
            ToggleWindowActive(holder.gameObject);
        }


    }
}