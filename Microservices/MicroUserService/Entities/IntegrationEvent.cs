namespace MicroUserService.Entities
{
    public class IntegrationEvent
    {
        public int Id { get; set; }
        public string Event { get; set; }
        public string Data { get; set; }
    }
}