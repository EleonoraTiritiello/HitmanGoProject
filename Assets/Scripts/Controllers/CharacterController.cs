using UnityEngine;
using System;
using DG.Tweening;
using System.Collections;

namespace HitmanGO
{
    public abstract class CharacterController : MonoBehaviour
    {
        public Action Die;

        private void Awake()
        {
            if (Die == null)
                Die = OnDie;
        }

        public virtual void MoveToPosition(Vector3 targetPosition, float movementSpeed, bool snapping = false)
        {

            Debug.Log("Mi sto muovendo verso: " + targetPosition);
            transform.DOMove(targetPosition, movementSpeed, snapping);
        }

        public virtual void OnDie()
        {
            Destroy(gameObject);
        }

    }
}
