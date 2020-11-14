using UnityEngine;

public class alertSymbol : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    void Update()
    {
        transform.LookAt(target);
    }
}
