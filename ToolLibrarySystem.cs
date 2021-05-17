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
        public void add(Tool tool, int quantity)
        {
            toolArray = toolCollection.toArray();
            add(tool);
            int index = Array.FindIndex(toolArray, toolInArray => toolInArray == tool);
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
        public void delete(Tool tool, int quantity)
        {
            toolArray = toolCollection.toArray();
            add(tool);
            int index = Array.FindIndex(toolArray, toolInArray => toolInArray == tool);
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
                        Console.WriteLine(tool.Category.ToString() + " " + tool.Type);
                    }
                }
            }
        }

        // display all the tools of a tool type selected by a member
        // MODIFIED METHOD TO PASS TOOL ARRAY
        public void displayTools(string toolType, Tool[] displaytoolArray)
        {
            Console.WriteLine("Displaying all " + toolType + " tools");
            Console.WriteLine("====================================");
            foreach (Tool toolInArray in displaytoolArray)
            {
                Console.WriteLine(toolInArray.Name);
            }
            Console.WriteLine("====================================");
        }

        public void borrowTool(Member member, Tool tool)
        {
            count = memberLoanHT.Count;
            memberLoanHT.Add(count, member);
            toolLoanHT.Add(count, tool);
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
        public void displayTopThree()
        {
            throw new NotImplementedException();
        }
    }
}
