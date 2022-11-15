using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameSystems
{
    public class PoolManager : Singleton<PoolManager>
    {
        public void Store(MonoBehaviour obj)
        {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(transform);
        }
    }
}