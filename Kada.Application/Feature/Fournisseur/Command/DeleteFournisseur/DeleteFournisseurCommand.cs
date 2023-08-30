using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Fournisseur.Command.DeleteFournisseur
{
    public class DeleteFournisseurCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
