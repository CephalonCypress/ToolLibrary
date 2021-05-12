using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLibrary
{
    class ToolCategoryType
    {
        public static readonly ID gardening = 1;
        public static class gardeningTools
        {
            public static readonly ID LineTrimmers = gardening[0];
            public static readonly ID LawnMowers = gardening[1];
        }
        void ToolCategorise()
        {
            Console.WriteLine();
            
        }
    }

    public struct ID
    {
        public static ID none;

        public ID this[int childID]
        {
            get { return new ID((mID << 8) | (uint)childID); }
        }

        public ID super
        {
            get { return new ID(mID >> 8); }
        }

        public bool isa(ID super)
        {
            return (this != none) && ((this.super == super) || this.super.isa(super));
        }

        public static implicit operator ID(int id)
        {
            if (id == 0)
            {
                throw new System.InvalidCastException("top level id cannot be 0");
            }
            return new ID((uint)id);
        }

        public static bool operator ==(ID a, ID b)
        {
            return a.mID == b.mID;
        }

        public static bool operator !=(ID a, ID b)
        {
            return a.mID != b.mID;
        }

        public override bool Equals(object obj)
        {
            if (obj is ID)
                return ((ID)obj).mID == mID;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return (int)mID;
        }

        private ID(uint id)
        {
            mID = id;
        }

        private readonly uint mID;
    }
}
