using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseTool2.DataLayer;

namespace TestCaseTool2.ViewLayer
{
    public class InterfaceTreeViewItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Interface Interface { get; set; }
        public List<BreakingPointTreeViewItem> BreakingPoints { get; set; }

        public InterfaceTreeViewItem(string name, EInterfaceType type, Interface interfaceObj, List<BreakingPointTreeViewItem> breakingPoints)
        {
            Name = name;
            Interface = interfaceObj;
            switch (type)
            {
                case EInterfaceType.INPUT:
                    Type = "Input";
                    break;
                case EInterfaceType.OUTPUT:
                    Type = "Output";
                    break;

            }

            BreakingPoints = breakingPoints;
        }
    }
}
