using UnityEngine;
using UnityEngine.UI;

namespace HitmanGO
{
    public class PathCreatorLV3 : PathCreator
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
        private Image node4;
        [SerializeField]
        private Image node5;
        [SerializeField]
        private Image node6;
        [SerializeField]
        private Image node7;
        [SerializeField]
        private Image node8;

        [SerializeField]
        private Image segment1;
        [SerializeField]
        private Image segment2;
        [SerializeField]
        private Image segment3;
        [SerializeField]
        private Image segment4;
        [SerializeField]
        private Image segment5;
        [SerializeField]
        private Image segment6;
        [SerializeField]
        private Image segment7;
        [SerializeField]
        private Image segment8;
        [SerializeField]
        private Image segment9;


        public void Awake()
        {
            node1.fillAmount = 0;
            node2.fillAmount = 0;
            node3.fillAmount = 0;
            node4.fillAmount = 0;
            node5.fillAmount = 0;
            node6.fillAmount = 0;
            node7.fillAmount = 0;
            node8.fillAmount = 0;

            segment1.fillAmount = 0;
            segment2.fillAmount = 0;
            segment3.fillAmount = 0;
            segment4.fillAmount = 0;
            segment5.fillAmount = 0;
            segment6.fillAmount = 0;
            segment7.fillAmount = 0;
            segment8.fillAmount = 0;
            segment9.fillAmount = 0;

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
                Segment6fill();
            }
            if (phaseNumber == 5)
            {
                Node3fill();
                Node7fill();
            }
            if (phaseNumber == 7)
            {
                Segment3fill();
                Segment5fill();
                Segment8fill();
                Segment9fill();
            }
            if (phaseNumber == 11)
            {
                Segment3fill();
                Segment5fill();
                Segment8fill();
                Segment9fill();
            }
            if (phaseNumber == 15)
            {
                Node4fill();
                Node6fill();
                Node8fill();
            }
            if (phaseNumber == 18)
            {
                Segment4fill();
                Segment7fill();
            }
            if (phaseNumber == 20)
            {
                Node5fill();
            }
            if (phaseNumber == 21)
            {
                LevelManger.GetInstance.ChangeState(LevelManger.States.WaitingForInput);
            }


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
        private void Node4fill()
        {
            node4.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node4.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node5fill()
        {
            node5.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node5.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node6fill()
        {
            node6.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node6.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node7fill()
        {
            node7.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node7.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node8fill()
        {
            node8.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node8.fillAmount == 1)
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
        private void Segment3fill()
        {
            segment3.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment3.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment4fill()
        {
            segment4.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment4.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment5fill()
        {
            segment5.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment5.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment6fill()
        {
            segment6.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment6.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment7fill()
        {
            segment7.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment7.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment8fill()
        {
            segment8.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment8.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment9fill()
        {
            segment9.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment9.fillAmount == 1)
            {
                phaseNumber++;

            }
        }

    }
}
