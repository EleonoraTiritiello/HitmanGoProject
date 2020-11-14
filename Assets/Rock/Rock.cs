using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private bool rockHere;
    [SerializeField]
    private GameObject throwPosition;
    [SerializeField]
    private GameObject rockAoE;
    [SerializeField]
    private Camera cam;
    [HideInInspector]
    public Transform _selection;

    private void Start()
    {
        rockHere = false;
    }
    private void Update()
    {
        if (rockHere)
        {
            throwPosition.SetActive(true);
            RockThrowIfPossible();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            rockHere = true;
        }
    }

    private void RockThrowIfPossible()
    {
        int layermask = 1 << 8;
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
        {
            var selection = hit.transform;
            if (Input.GetMouseButtonDown(0) && rockHere && selection.CompareTag("N"))
            {
                rockAoE.transform.position = selection.position;
                rockAoE.SetActive(true);
                //ricerca nemici
                rockHere = false;
                Debug.Log("click");
            }
            if (Input.GetMouseButtonDown(0) && rockHere && selection.CompareTag("S"))
            {
                rockAoE.transform.position = selection.position;
                rockAoE.SetActive(true);
                //ricerca nemici
                rockHere = false;

            }
            if (Input.GetMouseButtonDown(0) && rockHere && selection.CompareTag("E"))
            {
                rockAoE.transform.position = selection.position;
                rockAoE.SetActive(true);
                //ricerca nemici
                rockHere = false;

            }
            if (Input.GetMouseButtonDown(0) && rockHere && selection.CompareTag("W"))
            {
                rockAoE.transform.position = selection.position;
                rockAoE.SetActive(true);
                //ricerca nemici
                rockHere = false;

            }

        }
    }
}
