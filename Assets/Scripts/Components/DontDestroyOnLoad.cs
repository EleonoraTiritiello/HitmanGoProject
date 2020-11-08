using UnityEngine;

/// <summary>
/// Class <c> DontDestroyOnLoad </c> prevents the destruction of the object when the scene changes
/// </summary>
public class DontDestroyOnLoad : MonoBehaviour
{
    #region Unity Callbacks

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    #endregion
}
