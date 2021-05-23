using BSTreeInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using ToolLibrary;

namespace ToolLibrary.UnitTests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void AddTool() { //Add tools to Tool Array
            //arrange
            Tool[] toolArray = new Tool[] { };
            ToolCollection toolCollection = new ToolCollection();
            Tool newTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5);
            Tool[] expectedArray = new Tool[] {newTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5)};
            ToolLibrarySystem TLS = new ToolLibrarySystem();

            //act
            toolCollection.add(newTool);

            //assert
            toolArray = toolCollection.getToolArray();
            Assert.AreEqual(toolArray[0], expectedArray[0]);
        }

        [TestMethod]
        public void AddMultipleOfSameTool() //Add multiple tools to Tool Array
        { 
            //arrange
            Tool[] toolArray = new Tool[] { };
            ToolCollection toolCollection = new ToolCollection();
            Tool[] expectedArray = new Tool[] {new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 10) };
            Tool newTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5);
            ToolLibrarySystem TLS = new ToolLibrarySystem();

            //act
            toolCollection.add(newTool);
            toolCollection.add(newTool);

            //assert
            toolArray = toolCollection.getToolArray();
            Console.WriteLine(toolArray[0].Quantity.ToString() + expectedArray[0].Quantity.ToString());
            Assert.AreEqual(toolArray[0].Quantity, expectedArray[0].Quantity);
        }

        [TestMethod]
        public void DeleteTool() //Delete tool from Array
        { 
            //arrange
            Tool tool = new Tool();
            Tool[] toolArray = new Tool[] { };
            ToolCollection toolCollection = new ToolCollection();
            Tool newTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5);
            Tool[] expectedArray = new Tool[] { };

            //act
            toolCollection.add(newTool);
            toolCollection.delete(newTool);

            //assert
            toolArray = toolCollection.getToolArray();
            Assert.AreEqual(toolArray.Length, expectedArray.Length);
        }

        [TestMethod]
        public void IncreaseQuantity() { //Increases quantity of specified Tool
            //arrange
            Tool tool = new Tool();
            ToolCollection toolCollection = new ToolCollection();
            ToolLibrarySystem TLS = new ToolLibrarySystem();
            Tool selectedTool, expectedTool;
            selectedTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5);
            Tool[] toolArray = new Tool[] { };
            Tool[] expectedArray = new Tool[] { expectedTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 10) };
            toolArray = toolCollection.toArray();

            //act
            toolCollection.add(selectedTool);
            toolArray = toolCollection.toArray();
            TLS.add(selectedTool, 5, toolArray);
            toolArray = toolCollection.toArray();

            //assert
            Assert.AreEqual(toolArray[0].Quantity, expectedArray[0].Quantity);
        }

        [TestMethod]
        public void DecreaseQuantity() { //Decreases quantity of specified Tool
            //arrange
            Tool tool = new Tool();
            ToolCollection toolCollection = new ToolCollection();
            ToolLibrarySystem TLS = new ToolLibrarySystem();
            Tool selectedTool, expectedTool;
            Tool[] toolArray = new Tool[] { selectedTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5) };
            Tool[] expectedArray = new Tool[] { expectedTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 2) };

            //act
            toolCollection.add(selectedTool);
            TLS.delete(selectedTool, 3, toolArray);
            toolArray = toolCollection.toArray();

            //assert
            Assert.AreEqual(toolArray[0].Quantity, expectedArray[0].Quantity);
        }

        [TestMethod]
        public void registerMember()
        {
            //arrange
            MemberCollection memberCollection = new MemberCollection();
            IBSTree BSTree = memberCollection.getBST();
            Member registeredMember = new Member("Fidel", "Seng", "0458938543", "1234");

            //act
            memberCollection.add(new Member("Fidel", "Seng", "0458938543", "1234"));

            //assert
            Assert.IsTrue(BSTree.Search(registeredMember));
        }

        [TestMethod]
        public void removeMember()
        {
            //arrange
            MemberCollection memberCollection = new MemberCollection();
            IBSTree BSTree = memberCollection.getBST();
            Member registeredMember = new Member("Fidel", "Seng", "0458938543", "1234");

            //act
            memberCollection.add(new Member("Fidel", "Seng", "0458938543", "1234"));
            memberCollection.delete(new Member("Fidel", "Seng", "0458938543", "1234"));

            //assert
            Assert.IsFalse(BSTree.Search(registeredMember));
        }

        [TestMethod]
        public void findContactNumber()
        {
            //arrange
            MemberCollection memberCollection = new MemberCollection();
            Member registeredMember = new Member("Fidel", "Seng", "0458938543", "1234");

            //act
            memberCollection.add(new Member("Fidel", "Seng", "0458938543", "1234"));

            //assert
            Assert.AreEqual(memberCollection.searchMember("Fidel", "Seng"), "0458938543");
        }

        [TestMethod]
        public void displayToolsOfToolType()
        {
            //arrange
            ToolLibrarySystem TLS = new ToolLibrarySystem();
            ToolCollection toolCollection = new ToolCollection();
            Tool[] toolArray = new Tool[] { };
            Tool tool = new Tool();

            Tool stool = new Tool(Tool.toolCategory.Painting, Tool.toolType.sanding, "Gardening Tool", 1);
            Tool ftool = new Tool(Tool.toolCategory.Painting, Tool.toolType.sanding, "Garden Tool", 2);
            Tool etool = new Tool(Tool.toolCategory.Painting, Tool.toolType.sanding, "Gardens Tool", 3);

            toolCollection.add(stool);
            toolCollection.add(ftool);
            toolCollection.add(etool);

            toolArray = toolCollection.toArray();
            //act

            TLS.displayTools("sanding", toolArray);

            //assert
            Assert.AreEqual(toolArray.Length, 3);
        }

        [TestMethod]
        public void borrowTool()
        {
            //arrange
            ToolLibrarySystem TLS = new ToolLibrarySystem();
            MemberCollection memberCollection = new MemberCollection();
            Member member = new Member();
            Hashtable toolHT = new Hashtable();
            Hashtable memberHT = new Hashtable();

            memberCollection.add(new Member("Fidel", "Seng", "0458938543", "1234"));
            Tool tool = new Tool(Tool.toolCategory.Automotive, Tool.toolType.airCompressors, "Test tool", 1);

            //act
            TLS.borrowTool(member, tool);

            //assert
            toolHT = TLS.ToToolLoanHT();
            memberHT = TLS.ToMemberLoanHT();
            Assert.IsTrue(toolHT.Count > 0 && memberHT.Count > 0);
        }

        [TestMethod]
        public void borrowMoreThan3Tools() // Member tries to borrow more than 3 tools but fails
        {
            //arrange
            ToolLibrarySystem TLS = new ToolLibrarySystem();
            MemberCollection memberCollection = new MemberCollection();
            Member member = new Member();
            Hashtable toolHT = new Hashtable();
            Hashtable memberHT = new Hashtable();

            memberCollection.add(new Member("Fidel", "Seng", "0458938543", "1234"));
            Tool atool = new Tool(Tool.toolCategory.Automotive, Tool.toolType.airCompressors, "Test tool 1", 1);
            Tool btool = new Tool(Tool.toolCategory.Automotive, Tool.toolType.airCompressors, "Test tool 2", 1);
            Tool ctool = new Tool(Tool.toolCategory.Automotive, Tool.toolType.airCompressors, "Test tool 3", 1);
            Tool dtool = new Tool(Tool.toolCategory.Automotive, Tool.toolType.airCompressors, "Test tool 4", 1);

            //act
            TLS.borrowTool(member, atool);
            TLS.borrowTool(member, btool);
            TLS.borrowTool(member, ctool);
            TLS.borrowTool(member, dtool);


            //assert
            toolHT = TLS.ToToolLoanHT();
            memberHT = TLS.ToMemberLoanHT();
            Assert.IsTrue(toolHT.Count == 3 && memberHT.Count == 3);
        }


        [TestMethod]
        public void returnTool()
        {
            //arrange
            ToolLibrarySystem TLS = new ToolLibrarySystem();
            MemberCollection memberCollection = new MemberCollection();
            Member member = new Member("Fidel", "Seng", "0479147960", "1234");
            Tool tool = new Tool(Tool.toolCategory.Automotive, Tool.toolType.airCompressors, "Test tool", 1);
            Hashtable toolHT = new Hashtable();
            toolHT.Add(1, tool);
            Hashtable memberHT = new Hashtable();
            memberHT.Add(1, member);

            //act
            TLS.borrowTool(member, tool);
            TLS.returnTool(member, tool);

            //assert
            toolHT = TLS.ToToolLoanHT();
            memberHT = TLS.ToMemberLoanHT();

            Assert.IsTrue(toolHT.Count == 0 && memberHT.Count == 0);
        }

        [TestMethod]
        public void listRentedToolsByMember()
        {
            //arrange
            ToolLibrarySystem TLS = new ToolLibrarySystem();
            MemberCollection memberCollection = new MemberCollection();
            Hashtable toolHT = new Hashtable();
            Hashtable memberHT = new Hashtable();
            Member member = new Member("Fidel", "Seng");
            Member secondMember = new Member("John", "Smith");

            Tool tool = new Tool(Tool.toolCategory.Automotive, Tool.toolType.airCompressors, "Test tool", 1);
            Tool ftool = new Tool(Tool.toolCategory.Electricity, Tool.toolType.batteryChargers, "Test tool", 1);
            Tool dtool = new Tool(Tool.toolCategory.Fencing, Tool.toolType.braking, "Test tool", 1);
            Tool etool = new Tool(Tool.toolCategory.Cleaning, Tool.toolType.carCleaning, "Test tool", 1);


            //act
            TLS.borrowTool(member, tool);
            TLS.borrowTool(member, ftool);
            TLS.borrowTool(secondMember, dtool);
            TLS.borrowTool(secondMember, etool);

            //assert
            //toolHT = TLS.getToolHT();
            //memberHT = TLS.getMemberHT();

        }

        [TestMethod]
        public void displayMostRentedTools()
        {

        }
    }
}
