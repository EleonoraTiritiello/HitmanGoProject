using System.Collections.Generic;
using UnityEngine;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> PathFindingManager </c> takes care of the management of all <c> PathFindingComponent </c> in the scene
    /// </summary>
    public class PathFindingManager : Singleton<PathFindingManager>
    {
        #region Variables

        #region Public Variables

        /// <summary>
        /// The list that contains all the <c> PathFindingComponents </c> in the scene
        /// </summary>
        public readonly List<PathFindingComponent> PFCList = new List<PathFindingComponent>();

        #endregion

        #region Private Variables

        private Node _lastNode;

        private const byte _moveStraightCost = 10;
        private const byte _moveDiagonalCost = 14;

        #endregion

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            foreach (PathFindingComponent pfc in PFCList)
            {
                if(pfc.GetComponent<EnemyController>() != null)
                    pfc.SetTargetNode += ArrangePFCComponents;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public PathFindingNode[] CalculatePath(Node startingNode, Node targetNode)
        {
            //Setup liste e variabili
            //Nodo di partenza
            PathFindingNode startingPathFindingNode = new PathFindingNode(startingNode.GridPosition);
            //Nodo di arrivo
            PathFindingNode targetPathFindingNode = new PathFindingNode(targetNode.GridPosition);

            //Lista di nodi virtuali
            List<PathFindingNode> pathFindingNodes = new List<PathFindingNode>();

            //Lista di nodi da verificare
            List<PathFindingNode> openList = new List<PathFindingNode>() { startingPathFindingNode };
            //Lista di nodi già verificati
            List<PathFindingNode> closedList = new List<PathFindingNode>();

            PathFindingNode currentPathFindingNode;

            //Inizializza i nodi virtuali dove sono i nodi reali
            foreach(Node node in GridManager.GetInstance.Nodes)
            {
                currentPathFindingNode = new PathFindingNode(node.GridPosition)
                {
                    GCost = int.MaxValue,
                    HCost = 0,
                    PreviousNode = null
                };
                pathFindingNodes.Add(currentPathFindingNode);
            }

            //Calcola la distanza più breve da inizio a fine
            startingPathFindingNode.GCost = 0;
            startingPathFindingNode.HCost = CalculateDistanceCost(startingPathFindingNode, targetPathFindingNode);

            //Fino a quando ci sono nodi da controllare
            while(openList.Count > 0)
            {
                //Salva il nodo con il costo combinato minore
                currentPathFindingNode = GetLowestFCostNode(openList.ToArray());

                Debug.LogWarning($"Veryfing node in position: {currentPathFindingNode.GridPosition}");

                PathFindingNode tmpNode = currentPathFindingNode;
                while(tmpNode.PreviousNode != null)
                {
                    Debug.Log($"With previous node in position: {tmpNode.PreviousNode.GridPosition}");
                    tmpNode = tmpNode.PreviousNode;
                }

                //Se il nodo trovato è il nodo di arrivo
                if (currentPathFindingNode.GridPosition == targetNode.GridPosition)
                {
                    targetPathFindingNode = currentPathFindingNode;
                    //Calcola il percorso fino a quel nodo
                    return CalculatePath(targetPathFindingNode);
                }

                //Altrimenti togli il nodo verificato dalla lista di nodi da verificare
                openList.Remove(currentPathFindingNode);
                //E aggiungilo alla lista di nodi controllati
                closedList.Add(currentPathFindingNode);

                Node currentNode = GridManager.GetInstance.GetNode(currentPathFindingNode.GridPosition);
                PathFindingNode connectedPathFindingNode = null;
                int tentativeGCost;

                //Per ogni nodo connesso al nodo trovato
                foreach(Connection connection in currentNode.Connections)
                {
                    //Verifica il nodo virtuale corrispondente al nodo "fisico"
                    foreach(PathFindingNode pathFindingNode in pathFindingNodes)
                    {
                        if(pathFindingNode.GridPosition == connection.To.GridPosition)
                        {
                            //Quando trovi il nodo virtuale giusto salvalo
                            connectedPathFindingNode = pathFindingNode;
                            break;
                        }
                    }

                    //Se non è stato trovato il nodo virtuale corrispondente al nodo corrente dai un errore
                    if (connectedPathFindingNode == null)
                        Debug.LogError($"Non è stato trovato il nodo virtuale corrispondente al nodo {currentNode.name}");

                    //Se il nodo virtuale corrente è già stato verificato passa al prossimo nodo
                    if (closedList.Contains(connectedPathFindingNode)) continue;

                    //Calcola il costo partendo dal nodo trovato
                    tentativeGCost = currentPathFindingNode.GCost + CalculateDistanceCost(currentPathFindingNode, connectedPathFindingNode);

                    //Se partendo dal nodo trovato costa meno arrivare alla fine
                    //rispetto a partire dal nodo verificato nella precedente iterazione
                    if(tentativeGCost < connectedPathFindingNode.GCost)
                    {

                        if (connectedPathFindingNode.PreviousNode != null)
                            Debug.LogError($"Sovrascrivendo il nodo precedente al nodo in posizione: {connectedPathFindingNode.GridPosition}");
                        else
                            Debug.Log($"Impostando il nodo precedente al nodo in posizione: {connectedPathFindingNode.GridPosition}");

                        //Setta i valori del nodo trovato
                        connectedPathFindingNode.PreviousNode = currentPathFindingNode;
                        connectedPathFindingNode.GCost = tentativeGCost;
                        connectedPathFindingNode.HCost = CalculateDistanceCost(connectedPathFindingNode, targetPathFindingNode);

                        //Se il nodo non è presente nella lista di nodi da verificare aggiungilo
                        if (!openList.Contains(connectedPathFindingNode))
                            openList.Add(connectedPathFindingNode);
                    }
                }
            }

            //Se non è stato trovato un percorso ritorna "null"
            return null;
        }

        public void ArrangePFCComponents(Node node)
        {
            if (_lastNode != node)
                ArrangePFCComponents(_lastNode);

            if (node == null)
            {
                _lastNode = node;
                return;
            }

            PathFindingComponent[] nodePopulation = GetNodePopulation(node);

            if (nodePopulation.Length == 1)
            {
                RequestPositionAdjustment(nodePopulation[0], nodePopulation[0].GetCurrentNode().transform.position);

                _lastNode = node;
                return;
            }

            int i;   
            float angle;
            Vector3 targetPosition = Vector3.zero;

            for (i = 0; i < nodePopulation.Length; i++)
            {
                angle = 360f / nodePopulation.Length * i;

                targetPosition.x = Mathf.Cos(angle * Mathf.Deg2Rad);
                targetPosition.z = Mathf.Sin(angle * Mathf.Deg2Rad);

                targetPosition += node.transform.position;

                RequestPositionAdjustment(nodePopulation[i], targetPosition);
            }

            _lastNode = node;
        }

        /// <summary>
        /// Get all the <c> PathFindingComponents </c> that target the given <c> Node </c>
        /// </summary>
        /// <param name="targetNode"> A given node </param>
        /// <returns> A <c> PathFindingComponent </c> array </returns>
        public PathFindingComponent[] GetNodePopulation(Node targetNode)
        {
            List<PathFindingComponent> population = new List<PathFindingComponent>();

            foreach (PathFindingComponent pfc in PFCList)
            {
                if (pfc.GetCurrentNode() == targetNode)
                    population.Add(pfc);
            }

            return population.ToArray();
        }

        #endregion

        #region Private Methods

        private PathFindingNode[] CalculatePath(PathFindingNode endNode)
        {
            //Inizializza una lista di nodi che parte dal nodo target
            List<PathFindingNode> path = new List<PathFindingNode>
            {
                endNode
            };

            //Salva il nodo corrente come il nodo target
            PathFindingNode currentNode = endNode;

            Debug.LogWarning($"Trovato il target in posizione: {currentNode.GridPosition}");

            //Fino a quando il nodo corrente deriva da un nodo
            while(currentNode.PreviousNode != null)
            {
                Debug.Log($"With previous node in position: {currentNode.PreviousNode.GridPosition}");
                //Aggiungi il nodo derivato alla lista dei nodi percorso
                path.Add(currentNode.PreviousNode);
                //Setta il nodo corrente al nodo derivato
                currentNode = currentNode.PreviousNode;
            }

            //Inverti la lista
            path.Reverse();

            //Ritorna la lista di nodi percorso
            return path.ToArray();
        }

        private PathFindingNode GetLowestFCostNode(PathFindingNode[] nodes)
        {
            //Salva il primo nodo della lista come il nodo con il costo minore
            PathFindingNode lowestFCostNode = nodes[0];

            //Per ogni nodo della lista
            foreach(PathFindingNode node in nodes)
            {
                //Se il nodo corrente ha un costo totale minore del nodo salvato
                if (node.FCost < lowestFCostNode.FCost)
                    //Aggiorna il nodo con il costo totale minore
                    lowestFCostNode = node;
            }

            //Ritorna il nodo con il costo totale minore
            return lowestFCostNode;
        }

        private int CalculateDistanceCost(PathFindingNode a, PathFindingNode b)
        {
            //Calcola il numero di nodi da fare in orizzontale per arrivare da "a" a "b"
            int xDistance = Mathf.Abs(b.GridPosition.x - a.GridPosition.x);
            //Calcola il numero di nodi da fare in verticale per arrivare da "a" a "b"
            int yDistance = Mathf.Abs(b.GridPosition.y - a.GridPosition.y);
            //Calcola i movimenti orizzontale che rimangono da fare dopo i movimenti diagonali
            /*int remaining = Mathf.Abs(xDistance - yDistance);
            //Ritorna il costo di tutto il movimento
            return _moveDiagonalCost * Mathf.Min(xDistance, yDistance) + _moveStraightCost * remaining;*/
            return (xDistance + yDistance) * _moveStraightCost;
        }

        private void RequestPositionAdjustment(PathFindingComponent pfc, Vector3 adjustedPosition)
        {
            if (pfc.AdjustPosition != null)
                pfc.AdjustPosition.Invoke(adjustedPosition);
        }

        #endregion

        #endregion
    }
}