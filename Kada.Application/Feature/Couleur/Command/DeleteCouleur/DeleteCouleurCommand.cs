using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Couleur.Command.DeleteCouleur
{
    public class DeleteCouleurCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
