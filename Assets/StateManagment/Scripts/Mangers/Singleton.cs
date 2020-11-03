using UnityEngine;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> Singleton </c> ensures that the derived class is created only once.
    /// </summary>
    /// <typeparam name="T"> The derived class type </typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        #region Singleton
        /// <summary>
        /// A generic type instance
        /// </summary>
        private static T Instance;

        /// <summary>
        /// Returns the <c> Instance </c> variable
        /// </summary>
        public static T GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = FindObjectOfType(typeof(T)) as T;

                    if(Instance != null)
                    {
                        Instance.Init();
                    }
                }

                return Instance;

            }
        }
        #endregion


        #region Unity Callbacks

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;

                Instance.Init();
            }
        }

        private void OnApplicationQuit() => Instance = null;

        #endregion


        #region Public Methods
        /// <summary>
        /// A method used to understand if the <c> Instance </c> has been instanced correctly
        /// </summary>
        /// <returns> returns <c> true </c> if the <c> Instance </c> exists returns <c> false </c> if the <c> Instance </c> does not exist </returns>
        public static bool Exists() => Instance != null;
            
        /// <summary>
        /// A callback that is called when the <c> Instance </c> is created
        /// </summary>
        public virtual void Init()
            {
               
            }

        #endregion


    }

}
