using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLibrary {
    public class ToolCollection : iToolCollection {
        public Tool[] toolArray = new Tool[] { };
        Hashtable HT = new Hashtable();
        Tool tool = new Tool();

        public ToolCollection() {

        }

        public void addNewTool(Tool newTool)
        {
            Array.Resize<Tool>(ref toolArray, toolArray.Length + 1);
            toolArray[toolArray.Length - 1] = newTool;

            //Deprecated List Method
            //List<Tool> ToolList = new List<Tool>(toolArray);
            //ToolList.Add(newTool);
            //toolArray = ToolList.ToArray();
        }

        public void increaseQuantity(Tool[] toolArray, Tool selectedTool, int quantity)
        {
            int index = Array.FindIndex(toolArray, tool => tool == selectedTool);
            toolArray[index].Quantity += quantity;

            //Deprecated List Method
            //List<Tool> ToolList = new List<Tool>(toolArray);
            //int index = ToolList.BinarySearch(selectedTool);
            //selectedTool.Quantity += quantity;
            //ToolList[0] = new Tool(selectedTool.Category, selectedTool.Type, selectedTool.Name, selectedTool.Quantity);
            //toolArray = ToolList.ToArray();
        }

        public void decreaseQuantity(Tool[] toolArray, Tool selectedTool, int quantity)
        {
            int index = Array.FindIndex(toolArray, tool => tool == selectedTool);
            toolArray[index].Quantity -= quantity;

            //Deprecated list method
            //List<Tool> ToolList = new List<Tool>(toolArray);
            //int index = ToolList.BinarySearch(selectedTool);
            //selectedTool.Quantity -= quantity;
            //ToolList[0] = new Tool(selectedTool.Category, selectedTool.Type, selectedTool.Name, selectedTool.Quantity);
            //toolArray = ToolList.ToArray();
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

        int iToolCollection.Number => throw new NotImplementedException();


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
