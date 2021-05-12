using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSTreeInterface;

namespace ToolLibrary {
    public class MemberCollection : iMemberCollection
    {
        IBSTree BSTree = new BSTree();
        public int Number { get; set; }

        int iMemberCollection.Number => throw new NotImplementedException();

        //public int Number => throw new NotImplementedException();

        public void registerMember(string firstName, string lastName, string contactNumber, string PIN)
        {
            BSTree.Insert(new Member(firstName, lastName, contactNumber, PIN));
        }

        public void removeMember(string firstName, string lastName, string contactNumber, string PIN)
        {
            BSTree.Delete(new Member(firstName, lastName, contactNumber, PIN));
        }

        public string searchMember(string firstName, string lastName)
        {
            return BSTree.Search(firstName, lastName);
        }

        public IBSTree getBST()
        {
            return BSTree;
        }

        void iMemberCollection.add(iMember aMember)
        {
            throw new NotImplementedException();
        }

        void iMemberCollection.delete(iMember aMember)
        {
            throw new NotImplementedException();
        }

        bool iMemberCollection.search(iMember aMember)
        {
            throw new NotImplementedException();
        }

        iMember[] iMemberCollection.toArray()
        {
            throw new NotImplementedException();
        }
    }
}
