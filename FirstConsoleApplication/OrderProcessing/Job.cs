namespace OrderProcessing
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public bool Status { get; set; }
    }
}
