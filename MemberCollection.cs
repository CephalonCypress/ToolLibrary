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
        public string[] Tools;

        int iMemberCollection.Number { get; }

        //DEPRECATED METHOD
        public void registerMember(string firstName, string lastName, string contactNumber, string PIN)
        {
            BSTree.Insert(new Member(firstName, lastName, contactNumber, PIN));
        }

        //DEPRECATED METHOD
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

        //add a new member to this member collection, make sure there are no duplicates in the member collection
        public void add(Member member)
        {
            if (!BSTree.Search(member))
            {
                BSTree.Insert(member);
            } else
            {
                Console.WriteLine("The member is already registered");
            }
            //BSTree.Insert(new Member(firstName, lastName, contactNumber, PIN));
        }

        //delete a given member from this member collection, a member can be deleted only when the member currently is not holding any tool
        public void delete(Member member)
        {
            //if(Tools.Length == 0)
            //{
                BSTree.Delete(member);
            //}

        }

        //search a given member in this member collection. Return true if this memeber is in the member collection; return false otherwise.
        public bool search(Member member)
        {
            return BSTree.Search(member);
        }

        //output the members in this collection to an array of Member
        public Member[] toArray()
        {
            return BSTree.ToMemberArray();
        }
    }
}
