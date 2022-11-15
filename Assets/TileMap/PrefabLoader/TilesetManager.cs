using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tileset.Storage;

namespace Tileset
{
    [CreateAssetMenu(menuName ="Tileset/TilesetManager")]
    [System.Serializable]
    public class TilesetManager:ScriptableObject
    {
        public TilesetLoader loader;
        TilesetStorage storage;
        public TilesetStorage Storage {
            get { if (storage == null)
                    storage = InitStorage();
                    return storage; } }

        TilesetStorage InitStorage()
        {
            return null;
        }
    }
}