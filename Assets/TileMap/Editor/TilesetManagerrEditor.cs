using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Tileset {
    [CustomEditor(typeof(TilesetLoader))]
    public class TilesetLoaderEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if(GUILayout.Button("Apply"))
            { 
                
            }
        }
    }
}