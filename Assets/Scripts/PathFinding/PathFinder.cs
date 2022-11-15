using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using GameSystems;
namespace Pathfinding
{
    public class PathFinder : Singleton<PathFinder>
    {
        Queue<IPathCallback> pathResults=new Queue<IPathCallback>();
        private void Start()
        {
            StartCoroutine(CheckReadiedPaths());
        }
        IEnumerator CheckReadiedPaths()
        {
            while (true)
            {
                if(pathResults.Count>0)
                {
                    ProcessPathResult();
                }
                yield return null;
            }
        }
        public void OnPathRequested(PathRequest request)
        {
            ThreadStart newThread = delegate { ProcessPathRequest(request); };
            newThread.Invoke();
        }
        void PathFound(IPathCallback result)
        {
            lock(pathResults)
            {
                pathResults.Enqueue(result);
            }
        }
        void ProcessPathResult()
        {
            lock(pathResults)
            {
                IPathCallback result = pathResults.Dequeue();
                result.Call();
            }
        }
        void ProcessPathRequest(PathRequest request)
        {
            bool success = false;
            Vector3[] waypoints = new Vector3[0];
            Node starting = GridManager.Instance.GetNodeFromPos(request.start);
            Node ending = GridManager.Instance.GetNodeFromPos(request.end);
            if (starting != null && ending != null)
            {
                starting.parent = starting;
                HeapQueue<Node> open = new HeapQueue<Node>(GridManager.Instance.NodeCount);
                HashSet<Node> closed = new HashSet<Node>();
                open.Enqueue(starting);
                int i = 0;
                while (open.Count > 0)
                {

                    i++;
                    if (i >= 100000)
                        break;
                    Node current = open.Dequeue();
                    closed.Add(current);
                    if (current == ending)
                    {
                        success = true;
                        break;
                    }
                    var neighbours = GridManager.Instance.GetNeighbours(current);
                    foreach (var neighbour in neighbours)
                    {

                        if (!neighbour.walkable|| closed.Contains(neighbour))
                            continue;
                        float newGCost = current.gCost + GetDistance(current, neighbour);
                        if (newGCost < neighbour.gCost || !open.Contains(neighbour))
                        {
                            neighbour.gCost = newGCost;
                            neighbour.hCost = GetDistance(neighbour, ending);
                            neighbour.parent = current;
                            if (!open.Contains(neighbour))
                                open.Enqueue(neighbour);
                            else
                                open.Update(neighbour);
                        }
                    }
                }
            }
            if (success)
            {
                PathSuccessCallback result = new PathSuccessCallback(request.success, ReconstructPath(starting, ending));
                PathFound(result);
            }
            else
            {
                Debug.Log("pathfinding unsuccessful!");
                request.fail.Call();
            }
            return;
        }
        
        int GetDistance(Vector3 from, Vector3 to)
        {
            int X = Mathf.RoundToInt((to.x - from.x) / 0.16f);
            int Y = Mathf.RoundToInt((to.y - from.y) / 0.16f);

            return Mathf.Abs(X) + Mathf.Abs(Y);
        }
        Vector3[] ReconstructPath(Node from,Node to)
        {
            List<Vector3> path = new List<Vector3>();
            Node current = to;
            while(current!=from)
            {
                path.Add(current.position);
                current = current.parent;
            }
            path.Reverse();
            Debug.Log(path.Count);
            return path.ToArray();

        }
        float GetDistance(Node from, Node to)
        {
            float distance = Mathf.RoundToInt(Vector3.Distance(from.position, to.position)/0.16f);
            int X = Mathf.Abs(from.X - to.X);
            int Y = Mathf.Abs(from.Y - to.Y);
            if (X >= Y)
            {
                distance = Y * 0.4f + X;
            }
            else
                distance = X * 0.4f + Y;
            return distance;
        }

        public interface IPathCallback
        {
            void Call();
        }
        public class PathSuccessCallback : IPathCallback
        {
            public PathSuccessCallback(Action<Vector3[]>callback,Vector3[]waypoints)
            {
                this.callback = callback;
                path = waypoints;
            }
            public void Call()
            {
                callback(path);
            }
            Vector3[] path;
            Action<Vector3[]> callback;
        }
        public class PathFailedCallback : IPathCallback
        {
            Action callback;
            public PathFailedCallback(Action callback)
            {
                this.callback = callback;
            }
            public void Call()
            {
                callback();
            }
        }

        public struct PathRequest
        {
            public Vector3 start;
            public Vector3 end;
            public Action<Vector3[]> success;
            public IPathCallback fail;

            public PathRequest(Vector3 _start, Vector3 _end, Action<Vector3[]> success, IPathCallback fail)
            {
                start = _start;
                end = _end;
                this.success = success;
                this.fail = fail;
            }
        }
    }
}