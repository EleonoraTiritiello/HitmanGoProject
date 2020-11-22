using UnityEngine;
using UnityEngine.UI;

namespace HitmanGO
{
    public class PathCreatorLV1 : MonoBehaviour
    {
        [SerializeField]
        private float nodeFillTimeCoefficient;
        [SerializeField]
        private float segmentFillTimeCoefficient;
        [SerializeField]
        private Image node1;
        [SerializeField]
        private Image node2;
        [SerializeField]
        private Image node3;
        [SerializeField]
        private Image segment1;
        [SerializeField]
        private Image segment2;

        private int phaseNumber = 99;

        public void Start()
        {
            node1.fillAmount = 0;
            node2.fillAmount = 0;
            node3.fillAmount = 0;
            segment1.fillAmount = 0;
            segment2.fillAmount = 0;
            Invoke("StartDelay", 5f);
        }

        public void Update()
        {
            if (phaseNumber == 0)
            {
                Node1fill();
            }

            if (phaseNumber == 1)
            {
                Segment1fill();
            }

            if (phaseNumber == 2)
            {
                Node2fill();
            }

            if (phaseNumber == 3)
            {
                Segment2fill();
            }

            if (phaseNumber == 4)
            {
                Node3fill();
            }
            if (phaseNumber == 5)
            {
                LevelManger.GetInstance.ChangeState(LevelManger.States.WaitingForInput);
            }
        }
        private void StartDelay()
        {
            phaseNumber = 0;
        }
        private void Node1fill()
        {
            node1.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node1.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Node2fill()
        {
            node2.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node2.fillAmount == 1)
            {
                phaseNumber++;


            }
        }

        private void Node3fill()
        {
            node3.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node3.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Segment1fill()
        {
            segment1.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime; ;
            if (segment1.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Segment2fill()
        {
            segment2.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment2.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
    }
}
