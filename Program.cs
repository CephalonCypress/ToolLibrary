using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLibrary {
    class Program {
        static void Main(string[] args) {
            Tool tool = new Tool();
            ToolCollection toolCollection = new ToolCollection();
            Member member = new Member();
            MemberCollection memberCollection = new MemberCollection();
            Tool[] toolArray = new Tool[] { };

            //Add tools to Array and then list them all
            //Tool newTool = new Tool(Tool.toolCategory.gardening, Tool.toolType.sanding, "Gardening Tool", 5);
            //tool.addNewTool(newTool);
            //toolCollection.listAllTools(tool.getToolArray());

            //Increase quantity of tool
            //Tool newTool = new Tool(Tool.toolCategory.gardening, Tool.toolType.sanding, "Gardening Tool", 5);
            //tool.addNewTool(newTool);
            //toolCollection.listAllTools(tool.getToolArray());
            //tool.increaseQuantityOfTool(newTool, 5);
            //toolCollection.listAllTools(tool.getToolArray());


            //toolArray = tool.addNewTool(toolArray, Tool.toolCategory.gardening, Tool.toolType.sanding, "Gardening Tool", 5);
            //Tool newTool = new Tool(Tool.toolCategory.gardening, Tool.toolType.sanding, "Gardening Tool", 5);
            //toolCollection.listAllTools(toolArray);
            //tool.increaseQuantityOfTool(toolArray, newTool, 5);
            //toolCollection.listAllTools(toolArray);


            Console.ReadKey();
            // END TESTING

            //MAIN MENU
            Console.WriteLine("Welcome to the Tool Library");
            Console.WriteLine("===========Main Menu===========");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("3. Exit");
            Console.WriteLine("===============================\n");
            Console.WriteLine("Please make a selection (1-2, or 0 to exit):");
            Console.ReadKey();
            Console.Clear();

            if (Console.ReadKey().KeyChar == '1')
            {
                Console.Clear();
                Console.WriteLine("Enter staff login details please");
                Console.Write("User: ");
                String user = Console.ReadLine();
                Console.Write("Pass: ");
                String pass = Console.ReadLine();

                member.staffLogin(user, pass);
            }

            //STAFF MENU
            Console.WriteLine("Welcome to the Tool Library");
            Console.WriteLine("================Staff Menu================");
            Console.WriteLine("1. Add a new tool");
            Console.WriteLine("2. Add new pieces of an existing tool");
            Console.WriteLine("3. Remove some pieces of a tool");
            Console.WriteLine("4. Register a new member");
            Console.WriteLine("5. Remove a member");
            Console.WriteLine("6. Find a contact number of a member");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("==========================================\n");
            Console.WriteLine("Please make a selection (1-6, or 0 to return to main menu):");
            Console.ReadKey();
            Console.Clear();

            //MEMBER MENU
            Console.WriteLine("Welcome to the Tool Library");
            Console.WriteLine("===============Member Menu===============");
            Console.WriteLine("1. Display all the tools of a tool type");
            Console.WriteLine("2. Borrow a tool");
            Console.WriteLine("3. Return a tool");
            Console.WriteLine("4. List all the tools that I am renting");
            Console.WriteLine("5. Display top three (3) most frequently rented tools");
            Console.WriteLine("6. Return to main menu");
            Console.WriteLine("=========================================\n");
            Console.WriteLine("Please make a selection (1-5, or 0 to return to main menu):");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
