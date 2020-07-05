namespace CentralDeErro.Core.Entities.DTOs
{
    public class SourceReadDTO
    {
        public SourceReadDTO(int id, string address, string environment)
        {
            Id = id;
            Address = address;
            Environment = environment;
        }

        public int Id { get; private set; }
        public string Address { get; private set; }
        public string Environment { get; private set; }
    }
}
