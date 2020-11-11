﻿using UnityEngine;
using System;
using DG.Tweening;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> CharacterController </c>
    /// </summary>
    public abstract class CharacterController : MonoBehaviour
    {
        #region Variables

        public Action Die;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if (Die == null)
                Die = OnDie;
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
