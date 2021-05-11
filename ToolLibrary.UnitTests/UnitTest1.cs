using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            Tool newTool = new Tool(Tool.toolCategory.gardening, Tool.toolType.sanding, "Gardening Tool", 5);
            Tool[] expectedArray = new Tool[] {newTool = new Tool(Tool.toolCategory.gardening, Tool.toolType.sanding, "Gardening Tool", 5)};

            //act
            tool.addNewTool(newTool);

            //assert
            toolArray = tool.getToolArray();
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
            tool.increaseQuantity(toolArray, selectedTool, 5);

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
            tool.decreaseQuantity(toolArray, selectedTool, 3);

            //assert
            Assert.AreEqual(toolArray[0].Quantity, expectedArray[0].Quantity);
        }

        [TestMethod]

    }
}
