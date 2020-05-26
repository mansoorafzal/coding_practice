namespace coding_practice.data_structure
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
