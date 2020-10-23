using System;
using System.Collections.Generic;
using System.Text;

namespace TechPaper.Domain.Models.Texts
{
    public class PopularTechnologyText : IMattermostText
    {
        private readonly IPopularTechnologyTextCommand _command;

        public PopularTechnologyText(IPopularTechnologyTextCommand command)
        {
            _command = command;
        }

        string IMattermostText.Build()
        {
            return $@"本日話題になっているテクノロジーはこちら！
##### {_command.Title}
{_command.Url}";
        }
    }
}
