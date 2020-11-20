using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HitmanGO
{
    public class CameraMoveMapScene : MonoBehaviour
    {
        #region Variables

        #region Public Variables

        [SerializeField] private Camera _cam;
        public GameObject UpLeftLimit, DownRightLimit;
        public float speedY = 2f;
        public float speedX = 2f;
        #endregion

        #region Private Variables

        private float _newPositionX = 0f;
        private float _newPositionY = 0f;
        #endregion
        #endregion

        #region Unity Callbacks
        void Start()
        {
            transform.position = new Vector3(_newPositionY, _newPositionX, 0f);
        }

        void Update()
        {
            SwipeMap();
        }
        #endregion

        #region Methods

        #region SwipeMap
        private void SwipeMap()
        {
            if (Input.GetMouseButton(0))
            {
                _newPositionX += speedY * Input.GetAxis("Mouse Y");
                _newPositionY += speedX * Input.GetAxis("Mouse X");
                transform.position = new Vector3(_newPositionY, _newPositionX, 0f);
                _cam.transform.position = new Vector3(Mathf.Clamp(_cam.transform.position.x, UpLeftLimit.transform.position.x, UpLeftLimit.transform.position.y), Mathf.Clamp(_cam.transform.position.y, DownRightLimit.transform.position.y, DownRightLimit.transform.position.x));
            }
        }
        #endregion
        #endregion
    }
}
