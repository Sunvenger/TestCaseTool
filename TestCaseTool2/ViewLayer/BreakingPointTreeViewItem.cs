using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseTool2.DataLayer;
namespace TestCaseTool2.ViewLayer
{
    public class BreakingPointTreeViewItem
    {
        public string Name { get; set; }
        public string Validity { get; set; }

        public BreakingPointTreeViewItem(string name, EValidity validity)
        {
            Name = name;

            switch (validity)
            {
                case EValidity.V:
                    Validity = "Valid";
                    break;
                case EValidity.I:
                    Validity = "Invalid";
                    break;
                default:
                    break;
            }

        }
    }
}
