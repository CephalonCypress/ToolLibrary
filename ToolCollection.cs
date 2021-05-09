using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLibrary {
    class ToolCollection : iToolCollection {
        public int Number => throw new NotImplementedException();
        public void add(iTool aTool) => throw new NotImplementedException();
        public void delete(iTool aTool) => throw new NotImplementedException();
        public bool search(iTool aTool) => throw new NotImplementedException();
        public iTool[] toArray() => throw new NotImplementedException();

        public Tool[] toolArray;
        Tool tool = new Tool();


        public ToolCollection() {

        }

        public void listAllTools(Tool[] toolArray) {
            //List<Tool> toolList = new List<Tool>(toolArray);
            //toolList.ForEach(delegate(Tool ToolEntry)
            //{
            //    ToolEntry.Tool
            //}

            //toolArray = tool.getToolArray();
            foreach (Tool tool in toolArray)
            {
                Console.WriteLine(tool.Name + " " + tool.Category + " " + tool.Type + " " + tool.Quantity);
            }
        }
    }
}
