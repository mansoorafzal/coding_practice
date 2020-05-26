namespace coding_challenges
{
    public class Vertex
    {
        public Vertex(string name)
        {
            Name = name;
            Edges = new LinkedList<Edge>();
        }

        public string Name { get; set; }

        public LinkedList<Edge> Edges { get; set; }

        public void AddEdge(Vertex destination, int weight)
        {
            Edge edge = new Edge(destination, weight);
            Edges.InsertLast(edge);
        }
    }
}
