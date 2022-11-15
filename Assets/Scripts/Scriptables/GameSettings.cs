using Containment;
using GameSystems;
using Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Settings/GameSettings")]
public class GameSettings : ScriptableObject
{
    public ItemDatabase itemDatabase;
    public CrimeCodex.Settings crimeCodex;
    public EqSlotObject eqSlots;
    public EqSlotObject workShopSlots;
    public InventoryInfoPresetHolder presetHolder;
}
