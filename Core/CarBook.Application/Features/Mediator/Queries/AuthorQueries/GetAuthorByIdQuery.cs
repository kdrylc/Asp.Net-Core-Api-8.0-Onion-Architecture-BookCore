using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery:IRequest<List<GetAuthorByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetAuthorByIdQuery(int ıd)
        {
            Id = ıd;
        }

    }
}
