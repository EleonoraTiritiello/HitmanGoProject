using UnityEngine;
using UnityEngine.UI;

namespace HitmanGO
{
    public class PathCreatorLV4 : MonoBehaviour
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
        private Image node9;
        [SerializeField]
        private Image node10;
        [SerializeField]
        private Image node11;
        [SerializeField]
        private Image node12;
        [SerializeField]
        private Image node13;
        [SerializeField]
        private Image node14;
        [SerializeField]
        private Image node15;
        [SerializeField]
        private Image node16;
        [SerializeField]
        private Image node17;
        [SerializeField]
        private Image node18;

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
        [SerializeField]
        private Image segment10;
        [SerializeField]
        private Image segment11;
        [SerializeField]
        private Image segment12;
        [SerializeField]
        private Image segment13;
        [SerializeField]
        private Image segment14;
        [SerializeField]
        private Image segment15;
        [SerializeField]
        private Image segment16;
        [SerializeField]
        private Image segment17;
        [SerializeField]
        private Image segment18;
        [SerializeField]
        private Image segment19;
        [SerializeField]
        private Image segment20;
        [SerializeField]
        private Image segment21;
        [SerializeField]
        private Image segment22;
        [SerializeField]
        private Image segment23;

        private int phaseNumber = 99;

        public void Start()
        {
            node1.fillAmount = 0;
            node2.fillAmount = 0;
            node3.fillAmount = 0;
            node4.fillAmount = 0;
            node5.fillAmount = 0;
            node6.fillAmount = 0;
            node7.fillAmount = 0;
            node8.fillAmount = 0;
            node9.fillAmount = 0;
            node10.fillAmount = 0;
            node11.fillAmount = 0;
            node12.fillAmount = 0;
            node13.fillAmount = 0;
            node14.fillAmount = 0;
            node15.fillAmount = 0;
            node16.fillAmount = 0;
            node17.fillAmount = 0;
            node18.fillAmount = 0;

            segment1.fillAmount = 0;
            segment2.fillAmount = 0;
            segment3.fillAmount = 0;
            segment4.fillAmount = 0;
            segment5.fillAmount = 0;
            segment6.fillAmount = 0;
            segment7.fillAmount = 0;
            segment8.fillAmount = 0;
            segment9.fillAmount = 0;
            segment10.fillAmount = 0;
            segment11.fillAmount = 0;
            segment12.fillAmount = 0;
            segment13.fillAmount = 0;
            segment14.fillAmount = 0;
            segment15.fillAmount = 0;
            segment16.fillAmount = 0;
            segment17.fillAmount = 0;
            segment18.fillAmount = 0;
            segment19.fillAmount = 0;
            segment20.fillAmount = 0;
            segment21.fillAmount = 0;
            segment22.fillAmount = 0;
            segment23.fillAmount = 0;
            Invoke("StartDelay", 3f);

        }
        private void StartDelay()
        {
            phaseNumber = 0;
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
                Segment13fill();
            }
            if (phaseNumber == 3)
            {
                Node2fill();
                Node5fill();
            }
            if (phaseNumber == 5)
            {
                Segment2fill();
                Segment4fill();
                Segment14fill();
                Segment16fill();
            }
            if (phaseNumber == 9)
            {
                Node3fill();
                Node6fill();
                Node10fill();
            }
            if (phaseNumber == 12)
            {
                Segment3fill();
                Segment5fill();
                Segment17fill();
                Segment7fill();
                Segment15fill();
            }
            if (phaseNumber == 17)
            {
                Node4fill();
                Node7fill();
                Node11fill();
                Node15fill();
            }
            if (phaseNumber == 21)
            {
                Segment8fill();
                Segment10fill();
                Segment18fill();
                Segment19fill();
                Segment20fill();
            }
            if (phaseNumber == 26)
            {
                Node12fill();
                Node16fill();
                Node8fill();
            }
            if (phaseNumber == 29)
            {
                Segment6fill();
                Segment9fill();
                Segment11fill();
            }
            if (phaseNumber == 32)
            {
                Node9fill();
                Node13fill();
                Node17fill();
            }
            if (phaseNumber == 35)
            {
                Segment12fill();
                Segment21fill();
                Segment22fill();
                Segment23fill();
            }
            if (phaseNumber == 39)
            {
                Node14fill();
                Node18fill();
            }
            if (phaseNumber == 41)
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
        private void Node9fill()
        {
            node9.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node9.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node10fill()
        {
            node10.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node10.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node11fill()
        {
            node11.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node11.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node12fill()
        {
            node12.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node12.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node13fill()
        {
            node13.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node13.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node14fill()
        {
            node14.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node14.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node15fill()
        {
            node15.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node15.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node16fill()
        {
            node16.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node16.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node17fill()
        {
            node17.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node17.fillAmount == 1)
            {
                phaseNumber++;


            }
        }
        private void Node18fill()
        {
            node18.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
            if (node18.fillAmount == 1)
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
        private void Segment10fill()
        {
            segment10.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment10.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment11fill()
        {
            segment11.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment11.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment12fill()
        {
            segment12.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment12.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment13fill()
        {
            segment13.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment13.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment14fill()
        {
            segment14.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment14.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment15fill()
        {
            segment15.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment15.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment16fill()
        {
            segment16.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment16.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment17fill()
        {
            segment17.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment17.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment18fill()
        {
            segment18.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment18.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment19fill()
        {
            segment19.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment19.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment20fill()
        {
            segment20.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment20.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment21fill()
        {
            segment21.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment21.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment22fill()
        {
            segment22.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment22.fillAmount == 1)
            {
                phaseNumber++;

            }
        }
        private void Segment23fill()
        {
            segment23.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
            if (segment23.fillAmount == 1)
            {
                phaseNumber++;

            }
        }

    }
}
