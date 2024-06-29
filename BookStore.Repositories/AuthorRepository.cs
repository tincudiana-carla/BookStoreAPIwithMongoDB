using BookStore.Data.Abstractions;
using BookStore.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IMongoCollection<Authors> authors;

        public AuthorRepository(IDatabase database)
        {
            authors = database.GetCollection<IMongoCollection<Authors>, Authors>("Authors");
        }
        public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var filter = Builders<Authors>.Filter.Eq(book => book.Id, id);
            var deleteResult = await this.authors.DeleteOneAsync(filter, cancellationToken);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

           
        public async Task<List<Authors>> GetAllAsync(CancellationToken cancellationToken)
        {
            var allAuthors = await authors.Find(_ => true).Limit(20).ToListAsync(cancellationToken);
            return allAuthors;
        }

        public async Task<Authors> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var filter = Builders<Authors>.Filter.Eq(book => book.Id, id);
            var author = await this.authors.Find(filter).FirstAsync(cancellationToken);
            return author;
        }

        public async Task<string> InsertAsync(Authors author, CancellationToken cancellationToken)
        {
            await this.authors.InsertOneAsync(author, cancellationToken);
            return author.Id;
        }

        public async Task<bool> UpdateAsync(Authors author, CancellationToken cancellationToken)
        {
            var filter = Builders<Authors>.Filter.Eq(b => b.Id, author.Id);
            var updateResult = await this.authors.ReplaceOneAsync(filter, author, new ReplaceOptions(), cancellationToken);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;

        }
    }
}
