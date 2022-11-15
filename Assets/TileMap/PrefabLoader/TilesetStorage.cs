using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Tileset.Storage
{
    public class TilesetStorage : ScriptableObject
    {
        Dictionary<string, TilesetStorageItem> storageItemSet=new Dictionary<string, TilesetStorageItem>();
        public TilesetStorageItem this[string index]
        {
            get { return storageItemSet[index]; }
        }
    }
    [System.Serializable]
    public class TilesetStorageItem
    {
        public string name;
        public List<GameObject> prefabs=new List<GameObject>();

    }
}