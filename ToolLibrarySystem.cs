using BSTreeInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLibrary
{
    public class ToolLibrarySystem : iToolLibrarySystem, IComparable<Member>
    {
        Hashtable memberLoanHT = new Hashtable();
        Hashtable toolLoanHT = new Hashtable();
        public Tool[] toolArray = new Tool[] { };
        ToolCollection toolCollection = new ToolCollection();
        Tool tool = new Tool();
        IBSTree BSTree = new BSTree();
        int count;

        public ToolLibrarySystem()
        {

        }

        public Hashtable ToMemberLoanHT()
        {
            return memberLoanHT;
        }

        public Hashtable ToToolLoanHT()
        {
            return toolLoanHT;
        }
       
        public int CompareTo(Member member)
        {
            Member another = (Member)member;
            if (member.LastName.CompareTo(another.LastName) < 0)
                return -1;
            else
                if (member.LastName.CompareTo(another.LastName) == 0)
                return member.FirstName.CompareTo(another.FirstName);
            else
                return 1;
        }

        // add a new tool to the system
        public void add(Tool tool)
        {
            toolArray = toolCollection.toArray();
            Array.Resize<Tool>(ref toolArray, toolArray.Length + 1);
            toolArray[toolArray.Length - 1] = tool;
        }

        //add new pieces of an existing tool to the system
        public void add(Tool tool, int quantity, Tool[] toolArray)
        {
            int index = 0;

            foreach (Tool indexedTool in toolArray)
            {
                if(indexedTool.Category == tool.Category && 
                    indexedTool.Type == tool.Type &&
                    indexedTool.Name == tool.Name)
                {
                    break;
                } else
                {
                    index++;
                }
            }
            //int index = Array.FindIndex(toolArray, toolInArray => toolInArray == tool);
            toolArray[index].Quantity += quantity;
        }

        //delte a given tool from the system
        public void delete(Tool tool)
        {
            int index = 0;
            toolCollection.search(tool);
            for (int i = index; i < toolArray.Length - 1; i++)
            {
                toolArray[i] = toolArray[i + 1];
            }
            Array.Resize<Tool>(ref toolArray, toolArray.Length - 1);
        }

        //remove some pieces of a tool from the system
        public void delete(Tool tool, int quantity, Tool[] toolArray)
        {
            int index = 0;

            foreach (Tool indexedTool in toolArray)
            {
                if (indexedTool.Category == tool.Category &&
                    indexedTool.Type == tool.Type &&
                    indexedTool.Name == tool.Name)
                {
                    break;
                }
                else
                {
                    index++;
                }
            }
            //int index = Array.FindIndex(toolArray, toolInArray => toolInArray == tool);
            toolArray[index].Quantity -= quantity;
        }

        //add a new memeber to the system
        public void add(Member member)
        {
            if (!BSTree.Search(member))
            {
                BSTree.Insert(member);
            }
            else
            {
                Console.WriteLine("The member is already registered");
            }
        }

        //delete a member from the system
        public void delete(Member member)
        {
            //if(Tools.Length == 0)
            //{
            BSTree.Delete(member);
            //}

        }

        public void displayBorrowingTools(Member member)
        {
            List<int> indexOfRentedToolsList = new List<int>();
            List<Tool> rentedToolsList = new List<Tool>();
            DictionaryEntry[] toolsLoanedArray = new DictionaryEntry[toolLoanHT.Count];
            toolLoanHT.CopyTo(toolsLoanedArray, 0);
            string displayBorrowingToolsString = "";
            int index = toolsLoanedArray.Count() - 1;

            // For each member that is currently loaning a tool, if the first name and last name match
            // add the index of the loan to the list
            foreach (Member indexedMember in memberLoanHT.Values)
            {
                if (indexedMember.FirstName == member.FirstName || indexedMember.LastName == member.LastName)
                {
                    indexOfRentedToolsList.Add(index);
                }
                index--;
            }
            // For each entry in the Array of loaned tools, match the index of rented tools
            // to the index of the ones being rented by the user and then print to Console
            Console.Clear();

            displayBorrowingToolsString += "\t===========================================================================\r\n";
            displayBorrowingToolsString += "\t------------------------Member Menu - Displaying Borrowed Tools------------\r\n";
            displayBorrowingToolsString += "\t|Category            |Type           |Name                |No. Available  |\r\n";

            //Console.WriteLine("\t=============================================================");
            //Console.WriteLine("\t=======================Member Menu===========================");
            //Console.WriteLine("\tCategory \t\t Type \t\t Name");
            foreach (DictionaryEntry element in toolsLoanedArray)
            {
                foreach (int indexedTool in indexOfRentedToolsList)
                {
                    if (element.Key.ToString() == indexedTool.ToString())
                    {
                        Tool tool = (Tool)element.Value;
                        displayBorrowingToolsString += String.Format("\t|{0, -20}|{1, -15}|{2, -20}|{3, -15}|\r\n",
                            tool.Category.ToString(),
                            tool.Type,
                            tool.Name,
                            tool.AvailableQuantity);
                        //Console.WriteLine("\t" + tool.Category.ToString() + "\t\t" + 
                        //    tool.Type + "\t\t" +
                        //    tool.Name + "\t\t" +
                        //    tool.timesBorrowed + "\t\t" +
                        //    tool.AvailableQuantity);
                    }
                }
            }
            displayBorrowingToolsString += "\t===========================================================================\r\n";
            Console.WriteLine(displayBorrowingToolsString);

        }

        // display all the tools of a tool type selected by a member
        // MODIFIED METHOD TO PASS TOOL ARRAY
        public void displayTools(string toolType, Tool[] displaytoolArray)
        {
            Console.WriteLine("\t\t\t Tool Type List of Tools");
            Console.WriteLine("\t================================================================================");
            Console.WriteLine("\t\t Tool Name \t\t\t\t Available \t Total");
            int index = 1;

            foreach (Tool toolInArray in displaytoolArray)
            {
                if(toolInArray.Type.ToString() == toolType)
                {
                    Console.WriteLine(index + ".\t\t" + toolInArray.Name + "\t\t\t\t" + toolInArray.AvailableQuantity + "\t" + toolInArray.Quantity);
                    index++;
                }
            }
            Console.WriteLine("\t================================================================================");
        }

        public void borrowTool(Member member, Tool tool)
        {
            if (member.toolsBorrowed < 3)
            {
                count = memberLoanHT.Count;
                tool.AvailableQuantity--;
                tool.timesBorrowed++;
                memberLoanHT.Add(count, member);
                toolLoanHT.Add(count, tool);
                member.toolsBorrowed++;
            } else
            {
                Console.WriteLine("You cannot borrow more than 3 tools");
                Console.WriteLine("Press any key to continue");
            }

        }

        public void returnTool(Member currentmember, Tool returnedTool)
        {
            int memberIndex = memberLoanHT.Count - 1;
            int toolIndex = toolLoanHT.Count - 1;

            foreach (Member indexedMember in memberLoanHT.Values)
            {
                if (indexedMember.FirstName == currentmember.FirstName && indexedMember.LastName == currentmember.LastName)
                {
                    toolIndex = toolLoanHT.Count - 1;
                    memberIndex = memberLoanHT.Count - 1;
                    foreach (Tool indexedTool in toolLoanHT.Values)
                    {
                        if (indexedTool.Category != returnedTool.Category || indexedTool.Type != returnedTool.Type)
                        {
                            toolIndex--;
                            memberIndex--;
                        }
                    }
                }
            }
            tool.AvailableQuantity++;
            memberLoanHT.Remove(memberIndex);
            toolLoanHT.Remove(toolIndex);

        }

        //get a list of tools that are currently held by a given member
        public string[] listTools(Member member)
        {
            string[] listOfTools = new string[0];

            List<int> indexOfRentedToolsList = new List<int>();
            List<Tool> rentedToolsList = new List<Tool>();
            DictionaryEntry[] toolsLoanedArray = new DictionaryEntry[toolLoanHT.Count];
            toolLoanHT.CopyTo(toolsLoanedArray, 0);
            int index = toolsLoanedArray.Count() - 1;

            // For each member that is currently loaning a tool, if the first name and last name match
            // add the index of the loan to the list
            foreach (Member indexedMember in memberLoanHT.Values)
            {
                if (indexedMember.FirstName == member.FirstName || indexedMember.LastName == member.LastName)
                {
                    indexOfRentedToolsList.Add(index);
                }
                index--;
            }
            // For each entry in the Array of loaned tools, match the index of rented tools
            // to the index of the ones being rented by the user and then print to Console
            foreach (DictionaryEntry element in toolsLoanedArray)
            {
                foreach (int indexedTool in indexOfRentedToolsList)
                {
                    if (element.Key.ToString() == indexedTool.ToString())
                    {
                        Tool tool = (Tool)element.Value;
                        rentedToolsList.Add(tool);
                    }
                }
            }
            rentedToolsList.ToArray();

            foreach (Tool indexedTool in rentedToolsList)
            {
                Array.Resize<String>(ref listOfTools, listOfTools.Length + 1);
                listOfTools[listOfTools.Length - 1] = indexedTool.Name;
            }

            return listOfTools;
        }

        //Display top three most frequently borrowed tools by the members in the descending order by the number of times each tool has been borrowed.
        public void displayTopThree(Tool[] toolArray)
        {
            //toolArray = toolCollection.toArray();
            string displayTopThreeString;
            heapSort(toolArray, toolArray.Length);


            displayTopThreeString = "\t=========================================================================================\r\n";
            displayTopThreeString += "\t|Category    |Type                |Name                     |Quantity  |Times Borrowed  |\r\n";
            displayTopThreeString += "\t=========================================================================================\r\n";
            for(int i = 0; i < 3; i++)
            {
                displayTopThreeString += String.Format("\t|{0, -12}|{1, -20}|{2, -25}|{3, -10}|{4, -16}|\r\n",
                    toolArray[i].Category,
                    toolArray[i].Type,
                    toolArray[i].Name,
                    toolArray[i].Quantity,
                    toolArray[i].timesBorrowed);
            }
            Console.WriteLine(displayTopThreeString);
        }

        // Heap sort method
        private static void heapSort(Tool[] toolArray, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(toolArray, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                Tool temp = toolArray[0];
                toolArray[0] = toolArray[i];
                toolArray[i] = temp;
                heapify(toolArray, i, 0);
            }
        }

        //Heapify method
        private static void heapify(Tool[] toolArray, int n, int i)
        {
            int smallest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && toolArray[left].timesBorrowed < toolArray[smallest].timesBorrowed)
                smallest = left;
            if (right < n && toolArray[right].timesBorrowed < toolArray[smallest].timesBorrowed)
                smallest = right;
            if (smallest != i)
            {
                Tool swap = toolArray[i];
                toolArray[i] = toolArray[smallest];
                toolArray[smallest] = swap;
                heapify(toolArray, n, smallest);
                //Console.WriteLine(toolArray[i].Name + "\t" + toolArray[i].timesBorrowed + "END OF ARRAY");
            }
        }

        //Example heap sort
        public void exampleHeapSort(Tool[] toolArray)
        {
            int n = toolArray.Length, i;
            Console.WriteLine("Heap Sort");
            Console.WriteLine("Initial array is: ");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine(toolArray[i].Name + "\t\t" + toolArray[i].timesBorrowed);
            }
            heapSort(toolArray, toolArray.Length);
            Console.WriteLine("\nSorted Array is: ");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine(toolArray[i].Name + "\t\t" + toolArray[i].timesBorrowed);
            }
            heapSort(toolArray, toolArray.Length);
        }
    }
}
