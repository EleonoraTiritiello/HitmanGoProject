using System.Collections;
using UnityEngine;

namespace HitmanGO
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables

        #region Public Variables

        [Header("Inputs")]
        public KeyCode MoveUpKey;
        public KeyCode MoveDownKey;
        public KeyCode MoveLeftKey;
        public KeyCode MoveRightKey;

        [Header("Stats")]
        public float MovementSpeed = 1f;

        #endregion

        #region Private Variables

        private PathFindingComponent _pfc;

        private bool _isMoving;

        #endregion

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if(_pfc == null) _pfc = GetComponent<PathFindingComponent>();

            _isMoving = false;

            if (_pfc.AdjustPosition == null) _pfc.AdjustPosition = StartMovementCoroutine;
        }

        private void Update()
        {
            CheckInputs();
        }

        #endregion

        #region Private Methods

        private void CheckInputs()
        {
            if (Input.GetKeyDown(MoveUpKey) && !_isMoving)
                MoveUp();
            else if (Input.GetKeyDown(MoveDownKey) && !_isMoving)
                MoveDown();
            else if (Input.GetKeyDown(MoveLeftKey) && !_isMoving)
                MoveLeft();
            else if (Input.GetKeyDown(MoveRightKey) && !_isMoving)
                MoveRight();
        }

        #region Movement

        private void MoveUp()
        {
            if (_pfc.UpNode != null)
            {
                _pfc.SetTargetNode.Invoke(_pfc.UpNode);
                StartMovementCoroutine(_pfc.GetTargetPosition());
                _pfc.SetCurrentNode.Invoke(_pfc.GetTargetNode());
            }
        }

        private void MoveDown()
        {
            if (_pfc.DownNode != null)
            {
                _pfc.SetTargetNode.Invoke(_pfc.DownNode);
                StartMovementCoroutine(_pfc.GetTargetPosition());
                _pfc.SetCurrentNode.Invoke(_pfc.GetTargetNode());
            }
        }

        private void MoveLeft()
        {
            if (_pfc.LeftNode != null)
            {
                _pfc.SetTargetNode.Invoke(_pfc.LeftNode);
                StartMovementCoroutine(_pfc.GetTargetPosition());
                _pfc.SetCurrentNode.Invoke(_pfc.GetTargetNode());
            }
        }

        private void MoveRight()
        {
            if (_pfc.RightNode != null)
            {
                _pfc.SetTargetNode.Invoke(_pfc.RightNode);
                StartMovementCoroutine(_pfc.GetTargetPosition());
                _pfc.SetCurrentNode.Invoke(_pfc.GetTargetNode());
            }
        }

        #region Coroutine

        private void StartMovementCoroutine(Vector3 targetPosition)
        {
            StopAllCoroutines();
            StartCoroutine(MoveTowards(targetPosition));
        }

        private IEnumerator MoveTowards(Vector3 targetPosition)
        {
            targetPosition.y += 0.5f;

            _isMoving = true;

            while (Mathf.Abs(Vector3.Distance(transform.position, targetPosition)) >= 1.5f) {
                transform.Translate((targetPosition - transform.position) * MovementSpeed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            transform.position = targetPosition;
            _isMoving = false;
        }

        #endregion

        #endregion

        #endregion
    }
}
