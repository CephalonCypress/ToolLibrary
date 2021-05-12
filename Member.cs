using BSTreeInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLibrary {
    public class Member : iMember, IComparable<Member> {
        //public string[] Tools => throw new NotImplementedException();
        //public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string ContactNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string PIN { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string[] Tools { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string PIN { get; set; }
        MemberCollection memberCollection = new MemberCollection();
        IBSTree BSTree;

        public Member(String firstName, String lastName, string contactNumber, string PIN) {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            this.PIN = PIN;
        }

        public Member(String firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Member() {

        }

        public void rentTool() {

        }

        public void returnTool() {

        }

        public void listRentedToolsByMember() {

        }

        public void removeMember() {

        }

        public void findContactNumber() {

        }

        public bool login(String firstName, String lastName, String PIN, IBSTree BSTree) {
            return BSTree.SearchAndLogin(firstName, lastName, PIN);
        }

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


        public bool staffLogin(String username, String password) {
            if ("staff" == username && "today123" == password)
            {
                return true;
            }
            return false;
        }

        void iMember.addTool(iTool aTool) {
            throw new NotImplementedException();
        }

        void iMember.deleteTool(iTool aTool) {
            throw new NotImplementedException();
        }

        string iMember.memberDetails() {
            throw new NotImplementedException();
        }
    }
}