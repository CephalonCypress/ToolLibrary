﻿using BSTreeInterface;
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
            Tool[] toolArray = new Tool[] { selectedTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5) };
            Tool[] expectedArray = new Tool[] { expectedTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 10) };

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
            Tool[] toolArray = new Tool[] { selectedTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5) };
            Tool[] expectedArray = new Tool[] { expectedTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 2) };

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
            //arrange
            Hashtable HT = new Hashtable();
            Tool tool = new Tool();
            HT = tool.getHT();
            int Count = 0;

            //act
            foreach (DictionaryEntry element in HT)
            {
                if (element.Value.ToString() == "Gardening")
                {
                    Console.WriteLine(element.Key);
                    Count++;
                }
            }

            //assert
            Assert.AreEqual(Count, 5);
        }

        [TestMethod]
        public void borrowTool()
        {
            //arrange
            ToolLibrarySystem TLS = new ToolLibrarySystem();
            MemberCollection memberCollection = new MemberCollection();
            Member member = new Member();
            Hashtable toolHT;
            Hashtable memberHT;

            memberCollection.registerMember("Fidel", "Seng", "0479147960", "1234");
            Tool tool = new Tool(Tool.toolCategory.Automotive, Tool.toolType.airCompressors, 1);

            //act
            TLS.borrowTool(member, tool);

            //assert
            toolHT = TLS.getToolHT();
            memberHT = TLS.getMemberHT();
            Assert.IsTrue(toolHT.Count > 0 && memberHT.Count > 0);
        }

        [TestMethod]
        public void returnTool()
        {
            //arrange
            ToolLibrarySystem TLS = new ToolLibrarySystem();
            MemberCollection memberCollection = new MemberCollection();
            Member member = new Member();
            Hashtable toolHT;
            Hashtable memberHT;

            member = new Member("Fidel", "Seng", "0479147960", "1234");
            Tool tool = new Tool(Tool.toolCategory.Automotive, Tool.toolType.airCompressors, 1);

            //act
            TLS.borrowTool(member, tool);
            TLS.returnTool(member, tool);

            //assert
            toolHT = TLS.getToolHT();
            memberHT = TLS.getMemberHT();

            Console.WriteLine(toolHT.Count);
            Console.WriteLine(memberHT.Count);
            Assert.IsTrue(toolHT.Count == 0 && memberHT.Count == 0);
        }

        [TestMethod]
        public void listRentedToolsByMember()
        {
            //arrange
            ToolLibrarySystem TLS = new ToolLibrarySystem();
            MemberCollection memberCollection = new MemberCollection();
            Hashtable toolHT;
            Hashtable memberHT;
            Member member = new Member("Fidel", "Seng");
            Member secondMember = new Member("John", "Smith");

            Tool tool = new Tool(Tool.toolCategory.Automotive, Tool.toolType.airCompressors, 1);
            Tool ftool = new Tool(Tool.toolCategory.Electricity, Tool.toolType.batteryChargers, 1);
            Tool dtool = new Tool(Tool.toolCategory.Fencing, Tool.toolType.braking, 1);
            Tool etool = new Tool(Tool.toolCategory.Cleaning, Tool.toolType.carCleaning, 1);


            //act
            TLS.borrowTool(member, tool);
            TLS.borrowTool(member, ftool);
            TLS.borrowTool(secondMember, dtool);
            TLS.borrowTool(secondMember, etool);

            //assert
            toolHT = TLS.getToolHT();
            memberHT = TLS.getMemberHT();

        }

        [TestMethod]
        public void displayMostRentedTools()
        {

        }
    }
}
