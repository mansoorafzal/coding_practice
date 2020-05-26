using coding_practice.helper;
using System;
using System.Collections.Generic;

namespace coding_practice.data_structure
{
    public class Graph
    {
        private Vertex _root;
        private int?[,] _matrix;
        private Constant.GraphType _graphType;

        public Graph(Constant.GraphType graphType = Constant.GraphType.Directed)
        {
            _root = null;
            _graphType = graphType;
            Vertices = new LinkedList<Vertex>();
        }

        public LinkedList<Vertex> Vertices { get; set; }

        public string Traversal { get; private set; }

        public Vertex AddVertex(string name)
        {
            Vertex vertex = Vertices.FindFirst(new Vertex(name));

            if (vertex != null)
            {
                return vertex;
            }

            vertex = new Vertex(name);
            Vertices.InsertLast(vertex);

            if (_root == null)
            {
                _root = vertex;
            }

            return vertex;
        }
        
        public void AddEdge(string source, string destination, int weight = 1)
        {
            Vertex sv = AddVertex(source);
            Vertex dv = AddVertex(destination);

            sv.AddEdge(dv, weight);

            if (_graphType == Constant.GraphType.Undirected)
            {
                dv.AddEdge(sv, weight);
            }
        }

        public void PrintAdjacencyMatrix(int defaultLength = 4, string defaultCharacter = "")
        {
            GenerateAdjacencyMatrix();

            string s = string.Empty;

            s += "     ";

            for (int i = 0; i < defaultLength; i++)
            {
                s += " ";
            }

            for (int i = 0; i < Vertices.Count; i++)
            {
                s += string.Format("{0, " + defaultLength.ToString() + "}", Vertices[i].Name);
            }

            s += "\r\n";

            for (int i = 0; i < Vertices.Count; i++)
            {
                s += string.Format("{0, " + defaultLength.ToString() + "} | [ ", Vertices[i].Name);

                for (int j = 0; j < Vertices.Count; j++)
                {
                    if (i == j)
                    {
                        s += string.Format("{0, " + defaultLength.ToString() + "}", defaultCharacter);
                    }
                    else if (_matrix[i, j] == null)
                    {
                        s += string.Format("{0, " + defaultLength.ToString() + "}", string.Empty);
                    }
                    else
                    {
                        s += string.Format("{0, " + defaultLength.ToString() + "}", _matrix[i, j]);
                    }

                }

                s += " ]\r\n";
            }

            Console.WriteLine(s);
        }

        private void GenerateAdjacencyMatrix()
        {
            int?[,] adjacency = new int?[Vertices.Count, Vertices.Count];

            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertex v1 = Vertices[i];

                for (int j = 0; j < Vertices.Count; j++)
                {
                    Vertex v2 = Vertices[j];

                    Edge edge = v1.Edges.FindFirst(new Edge(v2));

                    if (edge != null)
                    {
                        adjacency[i, j] = edge.Weight;
                    }
                }
            }

            _matrix = adjacency;
        }

        public void GenerateAndPrintTraversal(Constant.TraversalType traversalType)
        {
            if (traversalType == Constant.TraversalType.BreadthFirst)
            {
                BreadthFirst();
            }
            else if (traversalType == Constant.TraversalType.DepthFirst)
            {
                DepthFirst();
            }

            Console.WriteLine(traversalType + ": " + Traversal);
        }

        private void BreadthFirst()
        {
            Traversal = string.Empty;

            if (Vertices.Count == 0)
            {
                return;
            }

            Queue<Vertex> queue = new Queue<Vertex>();
            HashSet<string> hashset = new HashSet<string>();

            Vertex vertex = Vertices[0];
            queue.Enqueue(vertex);
            hashset.Add(vertex.Name);

            while (queue.Count > 0)
            {
                vertex = queue.Dequeue();

                Traversal += vertex.Name + " - ";

                for (int i = 0; i < vertex.Edges.Count; i++)
                {
                    if (!hashset.Contains(vertex.Edges[i].Destination.Name))
                    {
                        queue.Enqueue(vertex.Edges[i].Destination);
                        hashset.Add(vertex.Edges[i].Destination.Name);
                    }
                }
            }
        }

        private void DepthFirst()
        {
            Traversal = string.Empty;

            if (Vertices.Count == 0)
            {
                return;
            }

            Stack<Vertex> stack = new Stack<Vertex>();
            HashSet<string> hashset = new HashSet<string>();

            Vertex vertex = Vertices[0];
            stack.Push(vertex);
            hashset.Add(vertex.Name);

            while (stack.Count > 0)
            {
                vertex = stack.Pop();

                Traversal += vertex.Name + " - ";

                for (int i = vertex.Edges.Count - 1; i >= 0; i--)
                {
                    if (!hashset.Contains(vertex.Edges[i].Destination.Name))
                    {
                        stack.Push(vertex.Edges[i].Destination);
                        hashset.Add(vertex.Edges[i].Destination.Name);
                    }
                }
            }
        }

        public void FindAndPrintPaths(string source, string destination)
        {
            List<string[]> paths = FindPaths(Vertices.FindFirst(new Vertex(source)), Vertices.FindFirst(new Vertex(destination)));

            string s = string.Empty;

            for (int i = 0; i < paths.Count; i++)
            {
                for (int j = 0; j < paths[i].Length; j++)
                {
                    s += paths[i][j] + " - ";
                }

                s += "\r\n";
            }

            Console.WriteLine("All Paths (" + source + " --> " + destination + "): ");
            Console.WriteLine(s);
        }

        private List<string[]> FindPaths(Vertex source, Vertex destination)
        {
            List<string[]> paths = new List<string[]>();

            if (Vertices.Count == 0)
            {
                return paths;
            }

            HashSet<string> hashset = new HashSet<string>();

            List<string> local = new List<string>();
            local.Add(source.Name);

            FindPaths(source, destination, hashset, local, paths);

            return paths;
        }

        private void FindPaths(Vertex source, Vertex destination, HashSet<string> hashset, List<string> current, List<string[]> final)
        {
            hashset.Add(source.Name);

            if(source.Name.Equals(destination.Name))
            {   
                final.Add(current.ToArray());
                hashset.Remove(source.Name);

                return;
            }

            for (int i = 0; i < source.Edges.Count; i++)
            {
                if (!hashset.Contains(source.Edges[i].Destination.Name))
                {
                    current.Add(source.Edges[i].Destination.Name);
                    FindPaths(source.Edges[i].Destination, destination, hashset, current, final);
                    current.Remove(source.Edges[i].Destination.Name);
                }
            }

            hashset.Remove(source.Name);
        }
    }
}
