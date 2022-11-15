using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tileset
{
    [ExecuteInEditMode]
    public abstract class PrefabGenerator
    {
        protected const string prefabPath = "Assets/Prefabs/Generated/";
        protected Sprite[] sprites;
        public PrefabGenerator(Sprite[] _sprites)
        {
            sprites = _sprites;

        }
        public abstract void GeneratePrefabs();

    }
    public class FloorPrefabGenerator : PrefabGenerator
    {
        public FloorPrefabGenerator(Sprite[] _sprites) : base(_sprites)
        {
            
        }

        public override void GeneratePrefabs()
        {
            throw new System.NotImplementedException();
        }
    }
    public class WallPrefabGenerator : PrefabGenerator
    {
        public WallPrefabGenerator(Sprite[] _sprites) : base(_sprites)
        {
        }

        public override void GeneratePrefabs()
        {
            throw new System.NotImplementedException();
        }
    }
}