using UnityEngine;

namespace HitmanGO
{
    /// <summary>
    /// It ensures that the class is created one and only one instance, and provides a global access point.
    /// </summary>
    /// <typeparam name="T"> generic </typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        #region Singleton
        /// <summary>
        /// Instantiate the private variable of type T (generic)
        /// </summary>
        private static T Instance;

        /// <summary>
        /// Define Instance through public variable GetInstance
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

        #endregion

        #region Methods

            #region Public Methods
            /// <summary>
            /// A bool used to understand if the instance has been instanced correctly
            /// </summary>
            /// <returns> if it is not null I have a return </returns>
            public static bool Exist() => Instance != null;
            
            /// <summary>
            /// 
            /// </summary>
            public virtual void Init()
            {
               
            }

            #endregion

            #region Private Methods

            /// <summary>
            /// Stop all instances
            /// </summary>
            private void OnApplicationQuit() => Instance = null;

            #endregion

        #endregion

    }

}
