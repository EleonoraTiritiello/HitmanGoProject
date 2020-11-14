using UnityEngine;

public class RockCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("checker"))
        {
            Debug.Log("ALLARMATO");
            this.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
    }
}
