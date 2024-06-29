
using BookStore.Data.Abstractions;
using MediatR;


namespace BookStore.Application.Authors.Application.GetAuthorById
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdRequest, GetAuthorByIdResponse>
    {
        private readonly IAuthorRepository authorRepository;

        public GetAuthorByIdHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public async Task<GetAuthorByIdResponse> Handle(GetAuthorByIdRequest request, CancellationToken cancellationToken)
        {
            string id = request.Id;
            var author = await authorRepository.GetByIdAsync(id, cancellationToken);
            return new GetAuthorByIdResponse {Author = author};
        }
    }
}
