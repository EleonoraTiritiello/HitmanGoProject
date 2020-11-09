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
        /// The duration of the rotation
        /// </summary>
        public readonly float RotationDuration = 0.5f;

        /// <summary>
        /// A callback that is called when the character dies
        /// </summary>
        public Action Die;

        #endregion

        /// <summary>
        /// Virtual method for generic movement
        /// </summary>
        /// <param name="targetPosition"> The target position </param>
        /// <param name="movementDuration"> The duration of the movement </param>
        public virtual void MoveToPosition(Vector3 targetPosition)
        {
            transform.DOMove(targetPosition, MovementDuration);
        }

        /// <summary>
        /// Virtual method for generic rotation
        /// </summary>
        /// <param name="targetRotation"> The target rotation </param>
        /// <param name="rotationDuration"> The duration of the movement </param>
        public virtual void RotateTowards(Vector3 targetRotation)
        {
            transform.DORotate(targetRotation, RotationDuration);
        }

        /// <summary>
        /// Virtual method for generic death
        /// </summary>
        public virtual void OnDie()
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
