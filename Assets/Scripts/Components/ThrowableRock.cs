﻿using UnityEngine;
using System.Collections;

namespace HitmanGO
{
    public class ThrowableRock : MonoBehaviour
    {
        #region Private Variables

        [SerializeField]
        [Min(0.1f)]
        private float _movementDuration = 2f;

        private Vector3 _startingPosition;
        private Vector3 _startingPositionBackup;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if (gameObject.activeSelf)
                gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _startingPosition = transform.localPosition;
            _startingPositionBackup = _startingPosition;
        }

        private void OnDisable()
        {
            transform.localPosition = _startingPositionBackup;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void AddForce(RockChecker rockChecker)
        {
            StartCoroutine(AddForceCoroutine(rockChecker));
        }

        #endregion

        #region Private Methods

        private IEnumerator AddForceCoroutine(RockChecker rockChecker)
        {
            float time = 0f;

            Vector3 targetPosition = rockChecker.transform.position;

            Vector2 speed = new Vector2((targetPosition.x - _startingPosition.x) / _movementDuration, 9.81f * _movementDuration / 2 - _startingPosition.y);

            bool upDown = false;

            if (targetPosition.x < transform.position.x)
                speed.x = -speed.x;
            else if (targetPosition.z > transform.position.z)
            {
                speed.x = (targetPosition.z - _startingPosition.z) / _movementDuration;
                upDown = true;
            }
            else if (targetPosition.z < transform.position.z)
            {
                speed.x = -((targetPosition.z - _startingPosition.z) / _movementDuration);
                upDown = true;
            }

            Vector3 position = _startingPosition;

            while(time < _movementDuration + 1f)
            {
                if(upDown)
                    position.x = _startingPosition.z + speed.x * time;
                else
                    position.x = _startingPosition.x + speed.x * time;

                position.y = _startingPosition.y + speed.y * time - 0.5f * 9.81f * Mathf.Pow(time, 2f);

                transform.localPosition = position;

                time += Time.deltaTime;

                yield return null;
            }

            rockChecker.gameObject.SetActive(true);

            gameObject.SetActive(false);
        }

        #endregion

        #endregion
    }
}
