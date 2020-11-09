﻿using UnityEngine;
using UnityEngine.UI;

public class PathCreatorLV2 : MonoBehaviour
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
    private Image segment1;
    [SerializeField]
    private Image segment2;
    [SerializeField]
    private Image segment3;
    [SerializeField]
    private Image segment4;
    [SerializeField]
    private Image segment5;

    private int phaseNumber;

    public void Start()
    {
        node1.fillAmount = 0;
        node2.fillAmount = 0;
        node3.fillAmount = 0;
        node4.fillAmount = 0;
        node5.fillAmount = 0;
        node6.fillAmount = 0;
        segment1.fillAmount = 0;
        segment2.fillAmount = 0;
        segment3.fillAmount = 0;
        segment4.fillAmount = 0;
        segment5.fillAmount = 0;
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
            Segment3fill();
        }
        if (phaseNumber == 6)
        {
            Node4fill();
        }
        if (phaseNumber == 7)
        {
            Segment4fill();
        }
        if (phaseNumber == 8)
        {
            Node5fill();
        }
        if (phaseNumber == 9)
        {
            Segment5fill();
        }
        if (phaseNumber == 10)
        {
            Node6fill();
        }
        if (phaseNumber == 11)
        {

        }
    }

    private void Node1fill()
    {
        node1.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
        if (node1.fillAmount == 1)
        {
            phaseNumber++;
            Debug.Log("+1");
        }
    }
    private void Node2fill()
    {
        node2.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
        if (node2.fillAmount == 1)
        {
            phaseNumber++;
            Debug.Log("+1");

        }
    }

    private void Node3fill()
    {
        node3.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
        if (node3.fillAmount == 1)
        {
            phaseNumber++;
            Debug.Log("+1");

        }
    }
    private void Node4fill()
    {
        node4.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
        if (node4.fillAmount == 1)
        {
            phaseNumber++;
            Debug.Log("+1");

        }
    }
    private void Node5fill()
    {
        node5.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
        if (node5.fillAmount == 1)
        {
            phaseNumber++;
            Debug.Log("+1");

        }
    }
    private void Node6fill()
    {
        node6.fillAmount += 1.0f / nodeFillTimeCoefficient * Time.deltaTime;
        if (node6.fillAmount == 1)
        {
            phaseNumber++;
            Debug.Log("+1");

        }
    }

    private void Segment1fill()
    {
        segment1.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime; ;
        if (segment1.fillAmount == 1)
        {
            phaseNumber++;
            Debug.Log("+1");

        }
    }
    private void Segment2fill()
    {
        segment2.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
        if (segment2.fillAmount == 1)
        {
            phaseNumber++;
            Debug.Log("+1");
        }
    }
    private void Segment3fill()
    {
        segment3.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
        if (segment3.fillAmount == 1)
        {
            phaseNumber++;
            Debug.Log("+1");
        }
    }
    private void Segment4fill()
    {
        segment4.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
        if (segment4.fillAmount == 1)
        {
            phaseNumber++;
            Debug.Log("+1");
        }
    }
    private void Segment5fill()
    {
        segment5.fillAmount += 1.0f / segmentFillTimeCoefficient * Time.deltaTime;
        if (segment5.fillAmount == 1)
        {
            phaseNumber++;
            Debug.Log("+1");
        }
    }
}
