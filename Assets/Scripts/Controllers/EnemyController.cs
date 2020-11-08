using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> EnemyController contains the methods for player movement and its animations, inherits from CharacterController </c>
    /// </summary>

    public class EnemyController : CharacterController
    {

        #region Variables

        #region Public Variables

        #endregion

        #region Private Variables 

        /// <summary>
        /// Movement to the death position
        /// </summary>
        [SerializeField]
        private Transform _dieMovement;

        /// <summary>
        /// Variable to determine the animation speed when the player is dying
        /// </summary>
        [SerializeField]
        private Vector3 _dieAnimationVector = Vector3.zero;
        /// <summary>
        /// Variable to determine the animation speed when the player is dying
        /// </summary>
        [SerializeField]
        private float _dieAnimationSpeed = 1f;

        #endregion

        #endregion

        #region Unity Callbacks

        /// <summary>
        /// Collision detenction from gameObject
        /// </summary>
        /// <param name ="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
                PlayDieAnimation();
        }

        #endregion

        /// <summary>
        /// gameObject movement out of camera view with animation
        /// </summary>
        private void PlayDieAnimation()
        {
            transform.DOMove(transform.up * 50, _dieAnimationSpeed);
            StartCoroutine("GoDiePosition");
            transform.DOPunchRotation(_dieAnimationVector, _dieAnimationSpeed);
        }

        /// <summary>
        /// Movement of gameObject to the death position
        /// </summary>
        private IEnumerator GoDiePosition()
        {
            yield return new WaitForSeconds(_dieAnimationSpeed + 0.5f);
            transform.DOMove(_dieAnimationVector, _dieAnimationSpeed);
        }
    }
}
