using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HitmanGO
{
    public sealed class InputManager : Singleton<InputManager>
    {
        #region Public Variables

        #region Move

        /// <summary>
        /// Keycode for forward movement
        /// </summary>
        public KeyCode MoveUpKey = KeyCode.W;

        /// <summary>
        /// <c> Keycode </c> for backward movement
        /// </summary>
        public KeyCode MoveDownKey = KeyCode.S;

        /// <summary>
        /// <c> Keycode </c> for left movement
        /// </summary>
        public KeyCode MoveLeftKey = KeyCode.A;

        /// <summary>
        /// <c> Keycode </c> for right movement
        /// </summary>
        public KeyCode MoveRightKey = KeyCode.D;

        #endregion

        /// <summary>
        /// <c> Keycode </c> for selection 
        /// </summary>
        [Space(5)]
        public KeyCode SelectPlayerKey = KeyCode.Space;

        /// <summary>
        /// <c> Keycode </c> for die
        /// </summary>
        public KeyCode DieKey = KeyCode.G;

        #endregion
    }
}
