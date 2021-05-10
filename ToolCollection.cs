using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLibrary {
    public class ToolCollection : iToolCollection {
        public Tool[] toolArray;
        Tool tool = new Tool();

        public ToolCollection() {

        }

        int iToolCollection.Number => throw new NotImplementedException();

        public void listAllTools(Tool[] toolArray) {
            foreach (Tool tool in toolArray)
            {
                Console.WriteLine(tool.Name + " " + tool.Category + " " + tool.Type + " " + tool.Quantity);
            }
        }

        void iToolCollection.add(iTool aTool) {
            throw new NotImplementedException();
        }

        void iToolCollection.delete(iTool aTool) {
            throw new NotImplementedException();
        }

        bool iToolCollection.search(iTool aTool) {
            throw new NotImplementedException();
        }

        iTool[] iToolCollection.toArray() {
            throw new NotImplementedException();
        }
    }
}
