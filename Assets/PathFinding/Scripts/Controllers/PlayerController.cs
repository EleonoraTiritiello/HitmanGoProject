using System.Collections;
using UnityEngine;

namespace SB.HitmanGO
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

        private Vector3 _targetPosition;
        private bool _isMoving;

        #endregion

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if(_pfc == null) _pfc = GetComponent<PathFindingComponent>();

            _targetPosition = transform.position;
            _isMoving = false;
        }

        private void Update()
        {
            CheckInputs();
            Debug.Log(_targetPosition);
        }

        #endregion

        #region Private Methods

        private void CheckInputs()
        {
            if (Input.GetKeyDown(MoveUpKey) && !_isMoving)
            {
                TargetTopNode();
                StopAllCoroutines();
                StartCoroutine("MoveTowardsTargetPosition");
            }
            else if (Input.GetKeyDown(MoveDownKey) && !_isMoving)
            {
                TargetBottomNode();
                StopAllCoroutines();
                StartCoroutine("MoveTowardsTargetPosition");
            }
            else if (Input.GetKeyDown(MoveLeftKey) && !_isMoving)
            {
                TargetLeftNode();
                StopAllCoroutines();
                StartCoroutine("MoveTowardsTargetPosition");
            }
            else if (Input.GetKeyDown(MoveRightKey) && !_isMoving)
            {
                TargetRightNode();
                StopAllCoroutines();
                StartCoroutine("MoveTowardsTargetPosition");
            }
        }

        private IEnumerator MoveTowardsTargetPosition()
        {
            _isMoving = true;

            while (Mathf.Abs(Vector3.Distance(transform.position, _targetPosition)) >= 1.5f) {
                transform.Translate((_targetPosition - transform.position) * MovementSpeed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

            transform.position = _targetPosition;
            _isMoving = false;
        }

        #region Target Node

        private void TargetTopNode()
        {
            _targetPosition = _pfc.GetNearestNodePosition(transform.localPosition, Vector3.forward);
            Debug.LogWarning("Top Node");
        }

        private void TargetBottomNode()
        {
            _targetPosition = _pfc.GetNearestNodePosition(transform.localPosition, Vector3.back);
            Debug.LogWarning("Bottom Node");
        }

        private void TargetLeftNode()
        {
            _targetPosition = _pfc.GetNearestNodePosition(transform.localPosition, Vector3.left);
            Debug.LogWarning("Left Node");
        }

        private void TargetRightNode()
        {
            _targetPosition = _pfc.GetNearestNodePosition(transform.localPosition, Vector3.right);
            Debug.LogWarning("Right Node");
        }

        #endregion

        #endregion
    }
}
