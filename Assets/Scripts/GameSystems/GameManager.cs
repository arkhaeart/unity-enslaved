using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystems
{
    public class GameManager : Singleton<GameManager>
    {
        public List<string> interactableTags = new List<string>();


        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnLevelChanged;
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            SceneManager.sceneLoaded -= OnLevelChanged;
        }
        void OnLevelChanged(Scene scene, LoadSceneMode mode)
        {

        }
        public void ChangeLevel(LevelExit exit)
        {

            SceneManager.LoadScene(exit.levelTo, LoadSceneMode.Single);
        }
    }
}