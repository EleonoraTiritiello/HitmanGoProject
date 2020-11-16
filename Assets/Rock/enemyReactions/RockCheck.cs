using UnityEngine;
namespace HitmanGO
{
    public class RockCheck : MonoBehaviour
    {
        [SerializeField]
        private GameObject alertedIcon;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("checker"))
            {
                alertedIcon.SetActive(true);
                Debug.Log("ALLARMATO");
            }
        }
    }
}
