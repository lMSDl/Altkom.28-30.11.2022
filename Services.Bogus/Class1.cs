using Models.Fakers;

namespace Services.Bogus
{
    public class Service<T> where T : class
    {

        private ICollection<T> _collection;

        public Service(BaseFaker<T> faker)
        {
            _collection = faker.Generate(15);
        }

        public IEnumerable<T>
    }
}