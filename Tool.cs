using System;
using System.Collections.Generic;
using System.Linq;

namespace ToolLibrary {
    public class Tool : iTool {
        public enum toolCategory {
            gardening = 0,
            flooring = 1,
            fencing = 2,
            measuring = 3,
            cleaning = 4,
            painting = 5,
            electronic = 6,
            electricity = 7,
            automotive = 8
        }
        private toolCategory category;
        public toolCategory Category {
            get { return category; }
            set { category = value; }
        }
        public enum toolType {
            sanding = 0,
            brushes = 1,
            rollers = 2,
            paintRemoval = 3,
            paintScrapers = 4
        }
        private toolType type;
        public toolType Type {
            get { return type; }
            set { type = value; }
        }

        //public enum
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int NoBorrowings { get; set; }

        //public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public int Quantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public int AvailableQuantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public int NoBorrowings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        iMemberCollection iTool.GetBorrowers => throw new NotImplementedException();

        Tool[] toolArray = new Tool[] { };

        public Tool(toolCategory category, toolType toolType, String name, int quantity) {
            this.Category = category;
            this.Type = toolType;
            this.Name = name;
            this.Quantity = quantity;
        }

        public Tool() {

        }

        public void addNewTool(Tool newTool) {
            List<Tool> ToolList = new List<Tool>(toolArray);
            ToolList.Add(newTool);
            toolArray = ToolList.ToArray();
        }

        public void increaseQuantityOfTool(Tool selectedTool, int quantity) {
            List<Tool> ToolList = new List<Tool>(toolArray);
            int index = ToolList.BinarySearch(selectedTool);
            selectedTool.Quantity += quantity;
            ToolList[index] = new Tool(selectedTool.Category, selectedTool.Type, selectedTool.Name, selectedTool.Quantity + quantity);
        }

        public void decreaseQuantityOfTool(Tool selectedTool, int quantity) {
            selectedTool.Quantity -= quantity;
        }

        public Tool[] getToolArray() {
            return toolArray;
        }

        void iTool.addBorrower(iMember aMember) {
            throw new NotImplementedException();
        }

        void iTool.deleteBorrower(iMember aMember) {
            throw new NotImplementedException();
        }

        void iTool.toolDetails() {
            throw new NotImplementedException();
        }
    }
}

