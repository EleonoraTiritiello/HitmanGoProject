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
            {
                _pfc.SetTargetNode(_pfc.UpNode);

                if (_pfc.GetTargetNode() != null)
                {
                    StartMovementCoroutine(_pfc.GetTargetPosition(true));
                    _pfc.SetCurrentNode(_pfc.GetTargetNode());
                }
            }
            else if (Input.GetKeyDown(MoveDownKey) && !_isMoving)
            {
                _pfc.SetTargetNode(_pfc.DownNode);

                if (_pfc.GetTargetNode() != null)
                {
                    StartMovementCoroutine(_pfc.GetTargetPosition(true));
                    _pfc.SetCurrentNode(_pfc.GetTargetNode());
                }
            }
            else if (Input.GetKeyDown(MoveLeftKey) && !_isMoving)
            {
                _pfc.SetTargetNode(_pfc.LeftNode);

                if (_pfc.GetTargetNode() != null)
                {
                    StartMovementCoroutine(_pfc.GetTargetPosition(true));
                    _pfc.SetCurrentNode(_pfc.GetTargetNode());
                }
            }
            else if (Input.GetKeyDown(MoveRightKey) && !_isMoving)
            {
                _pfc.SetTargetNode(_pfc.RightNode);

                if (_pfc.GetTargetNode() != null)
                {
                    StartMovementCoroutine(_pfc.GetTargetPosition(true));
                    _pfc.SetCurrentNode(_pfc.GetTargetNode());
                }
            }
        }

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
    }
}
