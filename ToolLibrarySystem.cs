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
        int count;

        public ToolLibrarySystem()
        {

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
        public Hashtable getMemberHT()
        {
            return memberLoanHT;
        }

        public Hashtable getToolHT()
        {
            return toolLoanHT;
        }
 
        public void listRentedTools(Member member) // Lists the tools rented by the current user
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
                if(indexedMember.FirstName == member.FirstName || indexedMember.LastName == member.LastName)
                {
                    indexOfRentedToolsList.Add(index);
                }
                index--;
            }
            // For each entry in the Array of loaned tools, match the index of rented tools
            // to the index of the ones being rented by the user and then print to Console
            foreach (DictionaryEntry element in toolsLoanedArray)
            {
                foreach(int indexedTool in indexOfRentedToolsList)
                {
                    if (element.Key.ToString() == indexedTool.ToString())
                    {
                        Tool tool = (Tool)element.Value;
                        Console.WriteLine(tool.Category.ToString() + " " + tool.Type);
                    }
                }
            }
        }

        void iToolLibrarySystem.add(iTool aTool)
        {
            throw new NotImplementedException();
        }

        void iToolLibrarySystem.add(iTool aTool, int quantity)
        {
            throw new NotImplementedException();
        }

        void iToolLibrarySystem.add(iMember aMember)
        {
            throw new NotImplementedException();
        }

        void iToolLibrarySystem.borrowTool(iMember aMember, iTool aTool)
        {
            throw new NotImplementedException();
        }

        void iToolLibrarySystem.delete(iTool aTool)
        {
            throw new NotImplementedException();
        }

        void iToolLibrarySystem.delete(iTool aTool, int quantity)
        {
            throw new NotImplementedException();
        }

        void iToolLibrarySystem.delete(iMember aMember)
        {
            throw new NotImplementedException();
        }

        void iToolLibrarySystem.displayBorrowingTools(iMember aMember)
        {
            throw new NotImplementedException();
        }

        void iToolLibrarySystem.displayTools(string aToolType)
        {
            throw new NotImplementedException();
        }

        void iToolLibrarySystem.displayTopTHree()
        {
            throw new NotImplementedException();
        }

        string[] iToolLibrarySystem.listTools(iMember aMember)
        {
            throw new NotImplementedException();
        }

        void iToolLibrarySystem.returnTool(iMember aMember, iTool aTool)
        {
            throw new NotImplementedException();
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
    }
}
