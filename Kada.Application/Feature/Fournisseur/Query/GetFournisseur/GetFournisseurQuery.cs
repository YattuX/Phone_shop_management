using Kada.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Fournisseur.Query.GetFournisseur
{
    public class GetFournisseurQuery : IRequest<IReadOnlyList<FournisseurDto>>
    {
    }
}
