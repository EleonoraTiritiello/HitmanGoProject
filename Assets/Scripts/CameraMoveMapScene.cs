using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace HitmanGO
{
    public class CameraMoveMapScene : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Camera _cam;
        Vector3 touchStart;
        public float zoomOutMin = 30, zoomOutMax = 50, zoomSpeedPc = 10, zoomSpeedMobile = 1;
        #endregion

        #region Unity CallBacks

        private void Update()
        {
            CheckExecuteInput();
        }
        #endregion

        #region CheckExecuteInput

        void CheckExecuteInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchStart = _cam.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                Zoom(difference * 0.01f);
            }
            else
                if (Input.GetMouseButton(0))
            {
                Vector3 direction = touchStart - _cam.ScreenToWorldPoint(Input.mousePosition);
                _cam.transform.position += direction;
                _cam.transform.position = new Vector3(Mathf.Clamp(_cam.transform.position.x, -45, 45), Mathf.Clamp(_cam.transform.position.y, -32, 50), transform.position.z);

            }

            Zoom(Input.GetAxis("Mouse ScrollWheel"));

        }
        #endregion

        #region Zoom

        void Zoom(float increment)
        {
            _cam.orthographicSize = Mathf.Clamp(_cam.orthographicSize - increment * (zoomSpeedPc * zoomSpeedMobile), zoomOutMin, zoomOutMax);
        }
        #endregion
    }
}
