using UnityEngine;
using System;
using DG.Tweening;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> CharacterController </c>
    /// </summary>
    [RequireComponent(typeof(PathFindingComponent))]
    public abstract class CharacterController : MonoBehaviour
    {
        #region Public Variables

        /// <summary>
        /// The reference to the <c> PathFindingComponent </c>
        /// </summary>
        public PathFindingComponent PFC { get; protected set; }

        /// <summary>
        /// The duration of the movement
        /// </summary>
        public readonly float MovementDuration = 0.5f;

        /// <summary>
        /// A callback that is called when the character dies
        /// </summary>
        public Action Die;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if (PFC == null) PFC = GetComponent<PathFindingComponent>();

            if (Die == null) Die = OnDie;      
        }

        #endregion

        /// <summary>
        /// Virtual method for generic movement
        /// </summary>
        /// <param name="targetPosition"></param>
        /// <param name="movementDuration"></param>
        /// <param name="snapping"></param>
        public virtual void MoveToPosition(Vector3 targetPosition, float movementDuration)
        {
            transform.DOMove(targetPosition, movementDuration);
        }

        /// <summary>
        /// Virtual method for generic death
        /// </summary>
        public virtual void OnDie()
        {
            Destroy(gameObject);
        }
    }
}
