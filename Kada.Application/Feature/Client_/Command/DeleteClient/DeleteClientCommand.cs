using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Client_.Command.DeleteClient
{
    public class DeleteClientCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
