using BookStore.Data.Abstractions;
using BookStore.Domain;
using MongoDB.Driver;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> books;

        public BookRepository(IDatabase database)
        {
            books = database.GetCollection<IMongoCollection<Book>, Book>("Books");
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
            var deleteResult = await this.books.DeleteOneAsync(filter, cancellationToken);
            
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<List<Book>> GetAllAsync(CancellationToken cancellationToken)
        {
            var allBooks = await books.Find(_ => true).Limit(20).ToListAsync(cancellationToken); //am decis sa afisez doar 20 de carti pt ca in total sunt 10000 si ia laptopul razna cand rulez:))
           
            return allBooks;
        }

        public async Task<Book> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
            var book = await this.books.Find(filter).FirstAsync(cancellationToken);

            return book;
        }

        public async Task<string> InsertAsync(Book book, CancellationToken cancellationToken)
        {
            await this.books.InsertOneAsync(book, cancellationToken);

            return book.Id;
        }

        public async Task<bool> UpdateAsync(Book book, CancellationToken cancellationToken)
        {
            var filter = Builders<Book>.Filter.Eq(b => b.Id, book.Id);
            var updateResult = await this.books.ReplaceOneAsync(filter, book, new ReplaceOptions(), cancellationToken);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
