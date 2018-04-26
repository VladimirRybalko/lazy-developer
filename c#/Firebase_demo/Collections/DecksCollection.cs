namespace DataStorage
{
    public interface IDecksCollection : ICollection<Deck>
    {

    }

    internal sealed class DecksCollection : BaseCollection<Deck>, IDecksCollection
    {
        public DecksCollection(IDataClient client) 
            : base(client)
        {
        }
    }
}
