namespace coding_challenges
{
    public class Edge
    {
        public Edge(Vertex destination)
        {
            Destination = destination;
            Weight = null;
        }

        public Edge(Vertex destination, int weight)
        {  
            Destination = destination;
            Weight = weight;
        }

        public Vertex Destination { get; set; }

        public int? Weight { get; set; }
    }
}
