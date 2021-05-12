using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLibrary
{
    class ToolLibrarySystem : iToolLibrarySystem
    {
        public ToolLibrarySystem()
        {

        }

        public void borrowTool(Member member, Tool tool) 
        {

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
    }
}
