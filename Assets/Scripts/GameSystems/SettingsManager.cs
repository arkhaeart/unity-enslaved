using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containment;
using Items;
using System.Linq;
namespace GameSystems
{/*
    public class SettingsManager : Singleton<SettingsManager>,IInitable
    {
        const string infoPath = "Info/";
        const string eqSlotsName = "EqSlotsList";
        const string workShopSlotsName = "WorkShopSlots";
        public ItemDatabase itemDatabase;
        public CrimeCodex crimeCodex;
        public EqSlotObject eqSlots;
        public EqSlotObject workShopSlots;
        public InventoryInfoPresetHolder presetHolder;
        protected override void Awake()
        {
            base.Awake();
            LoadSettings();
            InitSettings();
        }
        public  void Init()
        {
            base.Awake();
            LoadSettings();
            InitSettings();
        }
        
        void LoadSettings()
        {
            var infos = Resources.LoadAll(infoPath);
            itemDatabase = infos.First((n) => n is ItemDatabase) as ItemDatabase;
            //crimeCodex = infos.First((n) => n is CrimeCodex) as CrimeCodex;
            eqSlots = infos.First(n => n.name==eqSlotsName ) as EqSlotObject;
            workShopSlots=infos.First(n => n.name == workShopSlotsName) as EqSlotObject;
            presetHolder = infos.First((n) => n is InventoryInfoPresetHolder) as InventoryInfoPresetHolder;
        }
        void InitSettings()
        {
            crimeCodex.Init();
            eqSlots.Init();
            itemDatabase.Init();
        }
    }*/
}