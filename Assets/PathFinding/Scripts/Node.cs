using UnityEngine;

namespace SB.HitmanGO
{
    public class Node : MonoBehaviour
    {
        #region Public Variables

        public Vector3 Position;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if (!PathFindingManager.GetInstance.CheckNode(this))
                PathFindingManager.GetInstance.AddNode(this);
        }

        #endregion
    }
}
