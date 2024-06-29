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
        private readonly IMongoCollection<Book> _books;

        public BookService(IDatabase database)
        {
            _authors = database.GetCollection<IMongoCollection<Authors>, Authors>("Authors");
            _books = database.GetCollection<IMongoCollection<Book>, Book>("Books");
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



        public async Task<Book> GetFirstBookOf2022Async()
        {
            var pipeline = new BsonDocument[]
            {
            new BsonDocument("$match", new BsonDocument
            {
                { "YearOfPublication", new BsonDocument
                    {
                        { "$gte", new BsonDateTime(new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc)) },
                        { "$lt", new BsonDateTime(new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)) }
                    }
                }
            }),
            new BsonDocument("$sort", new BsonDocument("YearOfPublication", 1)),
            new BsonDocument("$limit", 1),
            new BsonDocument("$lookup", new BsonDocument
            {
                { "from", "Authors" },
                { "localField", "AuthorId" },
                { "foreignField", "_id" },
                { "as", "authors" }
            }),
            new BsonDocument("$project", new BsonDocument
            {
                { "_id", 0 },
                { "Title", 1 },
                { "YearOfPublication", 1 },
                { "Author", new BsonDocument("$arrayElemAt", new BsonArray { "$authors", 0 }) }
            })
            };

            var cursor = await _books.AggregateAsync<Book>(pipeline);
            var result = await cursor.FirstOrDefaultAsync();

            return result;
        }
    }
}

