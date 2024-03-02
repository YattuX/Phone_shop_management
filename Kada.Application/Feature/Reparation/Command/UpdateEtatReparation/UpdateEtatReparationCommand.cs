using Kada.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Reparation.Command.UpdateEtatReparation
{
    public class UpdateEtatReparationCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public EtatReparation? EtatReparation { get; set; }
    }
}
