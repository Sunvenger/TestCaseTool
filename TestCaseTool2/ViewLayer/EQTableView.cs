using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseTool2.DataLayer;

namespace TestCaseTool2.ViewLayer
{
    public class EQTableView
    {
        private readonly EquivalenceClass equivalenceClass;
        private readonly string[] columnNames;
        private readonly string[,] tableData;

        public EQTableView(EquivalenceClass equivalenceClass, List<PointGroup> pointGroupList)
        {
            this.equivalenceClass = equivalenceClass;

            // Vytvoríme stĺpce pre tabuľku
            List<EquivalenceClassColumn> columns = new List<EquivalenceClassColumn>();
            int maxValidCount = 0;
            int maxInvalidCount = 0;

            foreach (Interface intf in equivalenceClass.Interfaces)
            {
                EquivalenceClassColumn column = new EquivalenceClassColumn(intf, pointGroupList);
                columns.Add(column);
                maxValidCount = Math.Max(maxValidCount, column.ValidValues.Count);
                maxInvalidCount = Math.Max(maxInvalidCount, column.InvalidValues.Count);
            }





            // Vytvoríme názvy stĺpcov
            List<string> columnNamesList = new List<string>();

            for (int i = 1; i <= maxValidCount; i++)
            {
                columnNamesList.Add($"V{i}");
            }
            for (int i = 1; i <= maxInvalidCount; i++)
            {
                columnNamesList.Add($"I{i}");
            }
            columnNamesList.Add("Name");
            columnNames = columnNamesList.ToArray();

            // Vytvoríme dáta pre tabuľku
            tableData = new string[columns.Count, columnNames.Length];

            for (int i = 0; i < columns.Count; i++)
            {
                tableData[i, maxInvalidCount+maxValidCount] = columns[i].Interface.Name;

                for (int j = 0; j < columns[i].ValidValues.Count; j++)
                {
                    tableData[i, j] = columns[i].ValidValues[j];
                }

                for (int j = 0; j < columns[i].InvalidValues.Count; j++)
                {
                    tableData[i, maxValidCount + j] = columns[i].InvalidValues[j];
                }
            }
        }

        public string[] ColumnNames
        {
            get { return columnNames; }
        }

        public string[,] TableData
        {
            get { return tableData; }
        }
    }
}
