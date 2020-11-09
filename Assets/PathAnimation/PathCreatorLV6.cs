using UnityEngine;
using UnityEngine.UI;

public class PathCreatorLV6 : MonoBehaviour
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

    private int phaseNumber;

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
    }

    public void Update()
    {
        if (phaseNumber == 0)
        {
            Node13fill();
        }
        if (phaseNumber == 1)
        {
            Segment7fill();
            Segment11fill();
        }
        if (phaseNumber == 3)
        {
            Node9fill();
            Node12fill();
        }
        if (phaseNumber == 5)
        {
            Segment5fill();
            Segment6fill();
        }
        if (phaseNumber == 7)
        {
            Node8fill();
            Node11fill();
        }
        if (phaseNumber == 9)
        {
            Segment4fill();
            Segment9fill();
        }
        if (phaseNumber == 11)
        {
            Node7fill();
        }
        if (phaseNumber == 12)
        {
            Segment8fill();
        }
        if (phaseNumber == 13)
        {
            Node3fill();
        }
        if (phaseNumber == 14)
        {
            Segment1fill();
        }
        if (phaseNumber == 15)
        {
            Node4fill();
        }
        if (phaseNumber == 16)
        {
            Segment2fill();
            Segment10fill();
        }
        if (phaseNumber == 18)
        {
            Node1fill();
            Node5fill();
        }
        if (phaseNumber == 20)
        {
            Segment3fill();
        }
        if (phaseNumber == 21)
        {
            Node6fill();
        }
        if (phaseNumber == 22)
        {
            Segment12fill();
            Segment13fill();
        }
        if (phaseNumber == 24)
        {
            Node2fill();
            Node10fill();
        }
        if (phaseNumber == 26)
        {
            Segment14fill();
        }
        if (phaseNumber == 27)
        {
            Node14fill();
        }
        if (phaseNumber == 28)
        {
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
}
