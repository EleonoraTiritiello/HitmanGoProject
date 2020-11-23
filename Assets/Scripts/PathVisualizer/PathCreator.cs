using System;
using UnityEngine;

namespace HitmanGO
{
    public abstract class PathCreator : MonoBehaviour
    {
        public Action CreatePath;
        public Action StartDelayEvent;
        protected int phaseNumber;

        public void Start()
        {
            StartDelayEvent.Invoke();
            Invoke("StartDelay", 5f);
        }
        public virtual void StartDelay()
        {
            phaseNumber = 0;
            CreatePath.Invoke();
        }
    }
}
