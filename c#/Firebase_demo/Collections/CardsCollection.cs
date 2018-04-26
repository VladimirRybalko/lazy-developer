namespace DataStorage
{
    public interface ICardsCollection : ICollection<Card>
    {

    }

    internal sealed class CardsCollection : BaseCollection<Card>, ICardsCollection
    {
        public CardsCollection(IDataClient client)
            : base(client)
        {
        }
    }
}
