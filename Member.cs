using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLibrary {
    public class Member : iMember {
        Hashtable users = new Hashtable();
        public string[] Tools => throw new NotImplementedException();
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContactNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PIN { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Member(String firstName, String lastName, string contactNumber, string PIN) {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            this.PIN = PIN;
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

        public bool login(String username, String password) {
            foreach (DictionaryEntry user in users)
            {
                if (user.Key.ToString() == username && user.Value.ToString() == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool staffLogin(String username, String password) {
            if ("staff" == username && "today123" == password)
            {
                return true;
            }
            return false;
        }

        public void registerMember(String firstName, String lastName, string contactNumber, string PIN) {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            this.PIN = PIN;
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