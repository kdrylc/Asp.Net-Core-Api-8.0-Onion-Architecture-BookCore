using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Results.BlogResults;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByAuthorIDQuery : IRequest<List<GetBlogByAuthorIDQueryResult>>
    {
        public int Id { get; set; }
        public GetBlogByAuthorIDQuery(int id)
        {
            Id = id;
        }
    }
}
