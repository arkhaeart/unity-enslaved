//using UnityEngine;
//namespace GameSystems
//{
//    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
//    {
//        private static T instance;
//        public static T Instance
//        { get
//            {
//                if (instance == null)
//                { instance = GameObject.FindObjectOfType<T>();
//                    if (instance is IInitable init)
//                        init.Init();
//                }
//                return instance;

//            } private set { instance = value; } }
//        protected virtual void Awake()
//        {
//            if (Instance == null)
//                Instance = this as T;
//            else if (Instance != this)
//                Destroy(gameObject);
//        }
        
//        protected virtual void OnDisable()
//        {
//            Instance = null;
//        }

//    }
//    public interface IInitable
//    {
//        void Init();
//    }
//}
