using UnityEngine;

namespace HitmanGO
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        #region Singleton

        private static T Instance;

        public static T GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = FindObjectOfType(typeof(T)) as T;

                    if (Instance != null) Instance.Init();
                }
                
                return Instance;
            }
        }

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this as T;
                Instance.Init();
            }
        }

        #endregion

        #region Public Methods

        public static bool Exists() => Instance != null;

        public virtual void Init() { }

        #endregion

        #region Private Methods

        private void OnApplicationQuit() => Instance = null;

        #endregion
    }
}
