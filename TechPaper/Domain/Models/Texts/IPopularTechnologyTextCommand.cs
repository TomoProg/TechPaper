using System;
using System.Collections.Generic;
using System.Text;

namespace TechPaper.Domain.Models.Texts
{
    public interface IPopularTechnologyTextCommand
    {
        string Title { get; }
        string Url { get; }
    }
}
