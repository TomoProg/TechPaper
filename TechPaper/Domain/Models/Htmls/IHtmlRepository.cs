using System;

namespace TechPaper.Domain.Models.Htmls
{
    public interface IHtmlRepository
    {
        Html FindByUri(Uri uri);
    }
}