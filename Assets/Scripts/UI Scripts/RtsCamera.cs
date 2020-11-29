using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace HitmanGO
{
    public class RtsCamera : MonoBehaviour
    {
        #region Variables

        #region Public Variables

        [SerializeField] private Camera _cam;
        [SerializeField] private Transform _target;
        public GameObject InitialPosition, TopViewPosition;
        Quaternion initialRotation, topViewRotation;
        Vector3 initialPosition, topViewPosition;
        bool stopCamera, stopCameraTopView, touchCheck, dio;
        #endregion

        #region Private Variables

        private Vector3 _previousPosition;
        #endregion
        #endregion

        #region Unity Callbacks

        private void Start()
        {
            initialPosition = InitialPosition.transform.position;
            initialRotation = InitialPosition.transform.rotation;
            topViewPosition = TopViewPosition.transform.position;
            topViewRotation = TopViewPosition.transform.rotation;

        }

        private void Update()
        {
            CalculateCameraMovement();
            ZoomIn();
            ZoomOut();
        }
        #endregion

        #region Calcualte Camera Movement

        private void CalculateCameraMovement()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _previousPosition = _cam.ScreenToViewportPoint(Input.mousePosition);
                dio = false;
            }


            if (Input.GetMouseButton(0) && dio == false && stopCameraTopView == false && Input.touchCount < 2)
            {
                Vector3 direction = _previousPosition - _cam.ScreenToViewportPoint(Input.mousePosition);

                _cam.transform.position = _target.position;
                _cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 25);
                _cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 30, Space.World);
                _cam.transform.Translate(new Vector3(0, 0, -10));

                _previousPosition = _cam.ScreenToViewportPoint(Input.mousePosition);

            }
            else if (Input.GetMouseButtonUp(0) && stopCameraTopView == false)
                stopCamera = true;

            if (stopCamera == true)
            {
                transform.DOMove(initialPosition, 0.5f);
                transform.DORotateQuaternion(initialRotation, 0.5f);
                stopCamera = false;
            }
        }
        #endregion

        #region Zoom In/Out

        private void ZoomIn()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.touchCount == 2 && touchCheck == false)
                StartCoroutine(Zoomin());
        }

        private void ZoomOut()
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.touchCount == 2 && touchCheck == true)
                StartCoroutine(Zoomout());
        }

        private IEnumerator Zoomin()
        {
            stopCameraTopView = true;
            transform.DOMove(topViewPosition, 1);
            transform.DORotateQuaternion(topViewRotation, 1);
            yield return new WaitForSeconds(1.1f);
            touchCheck = true;
        }

        private IEnumerator Zoomout()
        {
            stopCameraTopView = false;
            transform.DOMove(initialPosition, 1);
            transform.DORotateQuaternion(initialRotation, 1);
            yield return new WaitForSeconds(1.1f);
            touchCheck = false;

        }

        #endregion
    }
}