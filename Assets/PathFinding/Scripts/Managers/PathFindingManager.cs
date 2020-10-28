using System.Collections.Generic;

namespace HitmanGO
{
    public class PathFindingManager : Singleton<PathFindingManager>
    {
        #region Private Variables

        private readonly List<PathFindingComponent> _pfcList = new List<PathFindingComponent>();

        #endregion

        #region Public Methods

        public List<PathFindingComponent> GetPFCList() => _pfcList;

        public bool Contains(PathFindingComponent pfc) => _pfcList.Contains(pfc);

        public void AddPFC(PathFindingComponent pfc) => _pfcList.Add(pfc);

        #endregion
    }
}
