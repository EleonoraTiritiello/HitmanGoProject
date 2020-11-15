using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(enemy);
        }
    }
}
