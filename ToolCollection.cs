using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLibrary {
    public class ToolCollection : iToolCollection {
        private Tool[] toolArray = new Tool[] { };
        Hashtable HT = new Hashtable();
        private Tool tool = new Tool();

        public ToolCollection() {

        }

        public Tool[] getToolArray()
        {
            return toolArray;
        }

        public void displayToolsOfToolType(string category)
        {
            HT = tool.getHT();

            Console.WriteLine("Displaying all " + category + " tools");
            Console.WriteLine("====================================");
            foreach (DictionaryEntry element in HT)
            {
                if (element.Value.ToString() == category)
                {
                    Console.WriteLine(element.Key);
                }
            }
            Console.WriteLine("====================================");
        }

        public void listAllTools(Tool[] toolArray)
        {
            foreach (Tool tool in toolArray)
            {
                Console.WriteLine(tool.Name + " " + tool.Category + " " + tool.Type + " " + tool.Quantity);
            }
        }

        int iToolCollection.Number { get; }

        //add a given tool to this tool collection
        public void add(Tool tool)
        {
            Array.Resize<Tool>(ref toolArray, toolArray.Length + 1);
            toolArray[toolArray.Length - 1] = tool;
        }

        //delete a given tool from this tool collection
        public void delete(Tool tool)
        {
            int index = 0;
            search(tool);
            for(int i = index; i < toolArray.Length - 1; i++)
            {
                toolArray[i] = toolArray[i + 1];
            }
            Array.Resize<Tool>(ref toolArray, toolArray.Length - 1);
        }

        //search a given tool in this tool collection. Return true if this tool is in the tool collection; return false otherwise
        public bool search(Tool tool)
        {
            int index = 0;
            foreach (Tool toolIndex in toolArray)
            {
                if (tool.Category == toolIndex.Category &&
                    tool.Type == toolIndex.Type &&
                    tool.Name == toolIndex.Name)
                {
                    return true;
                }
                index++;
            }
            return false;
        }

        // output the tools in this tool collection to an array of Tool
        public Tool[] toArray()
        {
            return toolArray;
        }
}
}
