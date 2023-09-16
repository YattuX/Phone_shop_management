using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.TypeArticle.Command.DeleteTypeArticle
{
    public class DeleteTypeArticleCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
