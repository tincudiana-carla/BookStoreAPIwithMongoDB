using BookStore.Data.Abstractions;
using BookStore.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.MongoDB
{
    public class BookService
    {
        private readonly IMongoCollection<Authors> _authors;

        public BookService(IDatabase database)
        {
            _authors = database.GetCollection<IMongoCollection<Authors>, Authors>("Authors");
        }

        public async Task<int> GetNumberOfBooksBySerbianAuthorsAsync()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$lookup", new BsonDocument
                {
                    { "from", "Books" },
                    { "localField", "_id" },
                    { "foreignField", "AuthorId" },
                    { "as", "Books" }
                }),
                new BsonDocument("$match", new BsonDocument
                {
                    { "Nationality", "Serbia" }
                }),
                new BsonDocument("$unwind", new BsonDocument
                {
                    { "path", "$Books" }
                }),
                new BsonDocument("$count", "Numarul de carti ai caror autori sunt din Serbia")
            };

            var result = await _authors.Aggregate<BsonDocument>(pipeline).FirstOrDefaultAsync();
            return result != null ? result["Numarul de carti ai caror autori sunt din Serbia"].AsInt32 : 0;
        }
    }
}

