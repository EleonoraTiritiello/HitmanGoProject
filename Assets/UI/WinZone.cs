using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField]
    private GameObject completed1;
    [SerializeField]
    private GameObject completed2;
    [SerializeField]
    private GameObject completed3;
    [SerializeField]
    private GameObject completed4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            completed1.SetActive(true);
            completed2.SetActive(true);
            completed3.SetActive(true);
            completed4.SetActive(true);
        }
    }
}
