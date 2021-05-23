using BSTreeInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLibrary {
    public class Member : iMember, IComparable<Member> {
        public string[] Tools { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string PIN { get; set; }
        public int toolsBorrowed { get; set; }
        MemberCollection memberCollection = new MemberCollection();
        //IBSTree BSTree;

        // Create member object with all values 
        public Member(String firstName, String lastName, String contactNumber, String PIN) {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            this.PIN = PIN;
            String[] Tools = new String[] { };
            toolsBorrowed = 0;
        }

        //Create member object with first name, last name and PIN
        public Member(String firstName, string lastName, string PIN)
        {
            FirstName = firstName;
            LastName = lastName;
            this.PIN = PIN;
            String[] Tools = new String[] { };
        }

        //Create member object with first and last name only
        public Member(String firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            String[] Tools = new String[] { };
        }

        //Empty member object
        public Member() {
            String[] Tools = new String[] { };
        }

        //add a given tool to the list of tools that this member is currently holding
        public void addTool(Tool tool)
        {
            String[] Tools = new String[] { };
            Array.Resize<String>(ref Tools, Tools.Length + 1);
            Tools[Tools.Length - 1] = tool.Category.ToString() + tool.Type.ToString();
        }

        //delete a given tool from the list of tools that this member is currently holding
        public void deleteTool(Tool tool)
        {
            throw new NotImplementedException();
        }

        //return a string containing the first name, lastname, and contact phone number of this memeber
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " " + this.ContactNumber;
            //return base.ToString();
        }

        // Staff login
        public bool staffLogin(String username, String password)
        {
            if ("staff" == username && "today123" == password)
            {
                return true;
            }
            return false;
        }

        // Member login
        public bool login(String firstName, String lastName, String PIN, IBSTree BSTree)
        {
            return BSTree.SearchAndLogin(firstName, lastName, PIN);
        }

        // Compare method
        public int CompareTo(Member member)
        {
            Member another = (Member)member;
            if (this.LastName.CompareTo(another.LastName) < 0)
                return -1;
            else
                if (this.LastName.CompareTo(another.LastName) == 0)
                return this.FirstName.CompareTo(another.FirstName);
            else
                return 1;
        }
    }
}