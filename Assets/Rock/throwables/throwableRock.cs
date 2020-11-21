using UnityEngine;

namespace HitmanGO
{
    public class throwableRock : MonoBehaviour
    {
        [SerializeField]
        private GameObject rock;
        [SerializeField]
        private Rigidbody rb;
        [SerializeField]
        private float strenght = 10f;
        private Rock rockScript;

        void Start()
        {
            rockScript = FindObjectOfType<Rock>();
            if (rockScript.rockThrowedNorth == true)
            {
                Vector3 _throw = new Vector3(0.125f, 1.5f, 1.5f);

                rb.AddForce(_throw * strenght);
                rb.useGravity = true;
            }
            if (rockScript.rockThrowedSouth == true)
            {
                Vector3 _throw = new Vector3(0.125f, 1.5f, -1.5f);

                rb.AddForce(_throw * strenght);
                rb.useGravity = true;
            }
            if (rockScript.rockThrowedEast == true)
            {
                Vector3 _throw = new Vector3(1.65f, 1.5f, 0f);

                rb.AddForce(_throw * strenght);
                rb.useGravity = true;
            }
            if (rockScript.rockThrowedWest == true)
            {
                Vector3 _throw = new Vector3(-1.4f, 1.5f, 0f);

                rb.AddForce(_throw * strenght);
                rb.useGravity = true;
            }


        }
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(rock);
        }
    }
}
