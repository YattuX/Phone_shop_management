using Kada.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Client_.Query.GetClientDetails
{
    public class GetClientDetailsQuery : IRequest<ClientDto>
    {
        public Guid Id { get; set; }
    }
}
