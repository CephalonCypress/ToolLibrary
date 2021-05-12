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
        public void AddTool() { //Add tools to Array and then check if the expected output is the same
            //arrange
            Tool tool = new Tool();
            Tool[] toolArray = new Tool[] { };
            ToolCollection toolCollection = new ToolCollection();
            Tool newTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5);
            Tool[] expectedArray = new Tool[] {newTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5)};

            //act
            toolCollection.addNewTool(newTool);

            //assert
            toolArray = toolCollection.getToolArray();
            Assert.AreEqual(toolArray[0], expectedArray[0]);
        } 

        [TestMethod]
        public void IncreaseQuantity() { //Increases quantity of specified Tool
            //arrange
            Tool tool = new Tool();
            ToolCollection toolCollection = new ToolCollection();
            Tool selectedTool, expectedTool;
            Tool[] toolArray = new Tool[] { selectedTool = new Tool(Tool.toolCategory.gardening, Tool.toolType.sanding, "Gardening Tool", 5) };
            Tool[] expectedArray = new Tool[] { expectedTool = new Tool(Tool.toolCategory.gardening, Tool.toolType.sanding, "Gardening Tool", 10) };

            //act
            toolCollection.increaseQuantity(toolArray, selectedTool, 5);

            //assert
            Assert.AreEqual(toolArray[0].Quantity, expectedArray[0].Quantity);
        }

        [TestMethod]
        public void DecreaseQuantity() { //Decreases quantity of specified Tool
            //arrange
            Tool tool = new Tool();
            ToolCollection toolCollection = new ToolCollection();
            Tool selectedTool, expectedTool;
            Tool[] toolArray = new Tool[] { selectedTool = new Tool(Tool.toolCategory.gardening, Tool.toolType.sanding, "Gardening Tool", 5) };
            Tool[] expectedArray = new Tool[] { expectedTool = new Tool(Tool.toolCategory.gardening, Tool.toolType.sanding, "Gardening Tool", 2) };

            //act
            toolCollection.decreaseQuantity(toolArray, selectedTool, 3);

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
            memberCollection.registerMember("Fidel", "Seng", "0458938543", "1234");

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
            memberCollection.registerMember("Fidel", "Seng", "0458938543", "1234");
            memberCollection.removeMember("Fidel", "Seng", "0458938543", "1234");

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
            memberCollection.registerMember("Fidel", "Seng", "0458938543", "1234");

            //assert
            Assert.AreEqual(memberCollection.searchMember("Fidel", "Seng"), "0458938543");
        }

        [TestMethod]
        public void displayToolsOfToolType()
        {
            Hashtable HT = new Hashtable();
            Tool tool = new Tool();
            HT = tool.getHT();

            foreach (DictionaryEntry element in HT)
            {
                if (element.Value.ToString() == "Gardening")
                {
                    Console.WriteLine(element.Key);
                }
            }
        }

        [TestMethod]
        public void borrowTool()
        {

        }

        [TestMethod]
        public void returnTool()
        {

        }

        [TestMethod]
        public void listRentedToolsByMember()
        {

        }

        [TestMethod]
        public void displayMostRentedTools()
        {

        }
    }
}
