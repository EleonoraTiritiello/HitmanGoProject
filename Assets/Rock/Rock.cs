using UnityEngine;

namespace HitmanGO
{
    [RequireComponent(typeof(PathFindingComponent))]
    public class Rock : MonoBehaviour
    {
        public PathFindingComponent PFC { get; private set; }

        [SerializeField]
        private bool rockHere;
        [SerializeField]
        private bool rockAoEResizing;
        [SerializeField]
        private GameObject throwPosition;
        [SerializeField]
        private GameObject rockAoE;
        [SerializeField]
        private GameObject rockModel;
        [SerializeField]
        private GameObject normalStance;
        [SerializeField]
        private GameObject rockStance;
        [SerializeField]
        private GameObject rock1Stuff;
        [SerializeField]
        private Camera cam;
        [HideInInspector]
        public Transform _selection;

        [SerializeField]
        private GameObject throwableRock;
        [SerializeField]
        private GameObject rockInHand;
        //[HideInInspector]
        public bool rockThrowedNorth;
        //[HideInInspector]
        public bool rockThrowedSouth;
        //[HideInInspector]
        public bool rockThrowedEast;
        //[HideInInspector]
        public bool rockThrowedWest;

        [SerializeField]
        private GameObject agent47;
        private bool playerCanMove = true;

        private void Awake()
        {
            if (PFC == null)
                PFC = GetComponent<PathFindingComponent>();
        }

        private void Start()
        {
            rockHere = false;
            rockAoEResizing = false;

            if(!LevelManger.GetInstance.IsRockInList(this))
                LevelManger.GetInstance.AddRockToList(this);
        }
        private void Update()
        {
            if (rockAoEResizing == true)
            {
                var finalScale = new Vector3(9f, 0.01f, 9f);
                rockAoE.transform.localScale = Vector3.Lerp(rockAoE.transform.localScale, finalScale, 2f * Time.deltaTime);
            }
            if (rockHere)
            {
                RockThrowSelection();
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                throwPosition.SetActive(true);
                rockHere = true;
                rockModel.SetActive(false);
                normalStance.SetActive(false);
                rockStance.SetActive(true);
                playerCanMove = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                Destroy(rock1Stuff);
            }
        }

        private void OnDestroy()
        {
            if (LevelManger.GetInstance.IsRockInList(this))
                LevelManger.GetInstance.RemoveRockFromList(this);
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
                    Instantiate(throwableRock).transform.position = rockInHand.transform.position;
                    Invoke("RockHit", 1f);
                }
                if (Input.GetMouseButtonDown(0) && rockHere && selection.CompareTag("S"))
                {
                    rockThrowedSouth = true;
                    rockAoE.transform.position = selection.position;
                    normalStance.SetActive(true);
                    rockStance.SetActive(false);
                    throwPosition.SetActive(false);
                    Instantiate(throwableRock).transform.position = rockInHand.transform.position;
                    Invoke("RockHit", 1f);
                }
                if (Input.GetMouseButtonDown(0) && rockHere && selection.CompareTag("W"))
                {
                    rockThrowedWest = true;
                    rockAoE.transform.position = selection.position;
                    normalStance.SetActive(true);
                    rockStance.SetActive(false);
                    throwPosition.SetActive(false);
                    Instantiate(throwableRock).transform.position = rockInHand.transform.position;
                    Invoke("RockHit", 1f);
                }
                if (Input.GetMouseButtonDown(0) && rockHere && selection.CompareTag("E"))
                {
                    rockThrowedEast = true;
                    rockAoE.transform.position = selection.position;
                    normalStance.SetActive(true);
                    rockStance.SetActive(false);
                    throwPosition.SetActive(false);
                    Instantiate(throwableRock).transform.position = rockInHand.transform.position;
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
}
