using System;
using System.Collections.Generic;
using System.Text;

namespace TechPaper.Domain.Models.Htmls
{
    public class Html
    {
        private readonly string _html;

        public Html(string html)
        {
            _html = html;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;
            return ((Html)obj)._html == _html;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return _html;
        }
    }
}
