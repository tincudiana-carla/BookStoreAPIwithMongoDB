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

    public Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<List<Book>> GetAllAsync(CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<Book> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
      var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
      var book = await this.books.Find(filter).FirstAsync(cancellationToken);
      return book;
    }

    public async Task<string> InsertAsync(Book item, CancellationToken cancellationToken)
    {
      await this.books.InsertOneAsync(item, cancellationToken);

      return item.Id;
    }

    public Task<bool> UpdateAsync(Book item, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
