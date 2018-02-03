namespace Algorithms.Strings
{
    public class Prescription
    {
        public string Path { get; set; }
        public int Distance { get; set; }

        public Prescription(int distance, string path)
        {
            Distance = distance;
            Path = path;
        }
    }
}
