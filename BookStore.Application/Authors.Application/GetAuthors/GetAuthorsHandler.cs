using BookStore.Application.Books.Application.GetBooks;
using BookStore.Data.Abstractions;
using MediatR;


namespace BookStore.Application.Authors.Application.GetAuthors
{
    public class GetAuthorsHandler : IRequestHandler<GetAuthorsRequest, GetAuthorsResponse>
    {
        private readonly IAuthorRepository authorRepository;

        public GetAuthorsHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public async Task<GetAuthorsResponse> Handle(GetAuthorsRequest request, CancellationToken cancellationToken)
        {
            var authors = await authorRepository.GetAllAsync(cancellationToken);
            return new GetAuthorsResponse { Authors = authors };
        }
    }
}
