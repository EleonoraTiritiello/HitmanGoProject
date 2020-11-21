using UnityEngine;

/*public class Rock2 : MonoBehaviour
{
    private void Update()
    {
        if (rockHere)
        {
            RockThrowSelection();
        }
    }

    private void RockThrowSelection()
    {
        int layermask = 1 << 8;
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
        {
            var selection = hit.transform;
            if (Input.GetMouseButtonDown(0) && rockHere && selection.CompareTag("N"))
            {
                rockThrowedNorth = true;
                rockAoE.transform.position = selection.position;
                normalStance.SetActive(true);
                rockStance.SetActive(false);
                throwPosition.SetActive(false);
                Instantiate(throwableRock2).transform.position = rockInHand.transform.position;
                Invoke("RockHit", 1f);
            }
            if (Input.GetMouseButtonDown(0) && rockHere && selection.CompareTag("S"))
            {
                rockThrowedSouth = true;
                rockAoE.transform.position = selection.position;
                normalStance.SetActive(true);
                rockStance.SetActive(false);
                throwPosition.SetActive(false);
                Instantiate(throwableRock2).transform.position = rockInHand.transform.position;
                Invoke("RockHit", 1f);
            }
            if (Input.GetMouseButtonDown(0) && rockHere && selection.CompareTag("W"))
            {
                rockThrowedWest = true;
                rockAoE.transform.position = selection.position;
                normalStance.SetActive(true);
                rockStance.SetActive(false);
                throwPosition.SetActive(false);
                Instantiate(throwableRock2).transform.position = rockInHand.transform.position;
                Invoke("RockHit", 1f);
            }
            if (Input.GetMouseButtonDown(0) && rockHere && selection.CompareTag("E"))
            {
                rockThrowedEast = true;
                rockAoE.transform.position = selection.position;
                normalStance.SetActive(true);
                rockStance.SetActive(false);
                throwPosition.SetActive(false);
                Instantiate(throwableRock2).transform.position = rockInHand.transform.position;
                Invoke("RockHit", 1f);
            }

        }
    }

    private void ExitRockAoE()
    {
        rockAoEResizing = false;
        rockAoE.SetActive(false);
        playerCanMove = true;
    }

    private void RockHit()
    {
        rockAoE.SetActive(true);
        rockAoEResizing = true;
        //ricerca nemici
        rockHere = false;
        rockThrowedNorth = false;
        rockThrowedSouth = false;
        rockThrowedWest = false;
        rockThrowedEast = false;
        Invoke("ExitRockAoE", 3f);
    }
}
*/