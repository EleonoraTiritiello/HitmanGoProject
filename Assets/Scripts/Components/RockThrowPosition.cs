using UnityEngine;

namespace HitmanGO
{
    [RequireComponent(typeof(Collider))]
    public class RockThrowPosition : MonoBehaviour
    {
        #region Private Variables

        private RockChecker _rockChecker;

        private RaycastHit _hit;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if (_rockChecker == null)
                _rockChecker = transform.GetChild(0).GetComponent<RockChecker>();

            if (_rockChecker.gameObject.activeSelf)
                _rockChecker.gameObject.SetActive(false);
        }

        private void FixedUpdate()
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit, Mathf.Infinity, 1 << 8))
            {
                if (_hit.transform == transform)
                {
                    if (Input.GetMouseButtonDown(InputManager.GetInstance.MouseLeftClick))
                    {
                        GameManager.GetInstance.Player.ThrowRockEvent.Invoke();
                        GameManager.GetInstance.Player.ThrowRock(_rockChecker);
                    }
                }
            }
        }

        #endregion
    }
}
