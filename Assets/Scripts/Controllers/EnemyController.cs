using System.Collections;
using UnityEngine;
using System;
using DG.Tweening;

namespace HitmanGO
{
    public class EnemyController : CharacterController
    {
        [SerializeField]
        private Transform _diePosition;
        [SerializeField]
        private Vector3 _dieAnimationVector;
        [SerializeField]
        private float _dieAnimationSpeed;

        private void PlayDieAnimation()
        {
            transform.DOMove(transform.up * 50, _dieAnimationSpeed);
            StartCoroutine("GoDiePosition");
            transform.DOPunchRotation(_dieAnimationVector, _dieAnimationSpeed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
                PlayDieAnimation();
        }

        private IEnumerator GoDiePosition()
        {
            yield return new WaitForSeconds(_dieAnimationSpeed + 0.5f);
            transform.DOMove(_dieAnimationVector, _dieAnimationSpeed);
        }
    }
}
