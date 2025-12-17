namespace Axia.Domain.Error
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string resource, string message)
            : base(message)
        {
            Resource = resource;
        }

        public string Resource { get; }
    }
}
