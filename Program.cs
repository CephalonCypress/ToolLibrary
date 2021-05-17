using BSTreeInterface;
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
            Member[] members = new Member[0];
            Tool[] toolArray = new Tool[] { };
            ToolCollection toolCollection = new ToolCollection();
            Member member = new Member();
            MemberCollection memberCollection = new MemberCollection();
            ToolLibrarySystem TLS = new ToolLibrarySystem();
            IBSTree BSTree = memberCollection.getBST();
            Member currentMember;
            //Hashtable memberLoanHT;
            //Hashtable toolLoanHT;


            TLS.borrowTool(member, tool);

            //act
            //TLS.borrowTool(member, tool);
            TLS.returnTool(member, tool);
            Console.ReadKey();

            //Tool selectedTool, expectedTool;
            //Tool stool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5);
            //Tool ftool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Garden Tool", 5);
            //Tool etool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardens Tool", 5);
            //selectedTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5);

            //Tool[] toolArray = new Tool[] { };
            //Tool[] expectedArray = new Tool[] { expectedTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 10) };

            ////act
            //toolCollection.add(stool);
            //toolCollection.add(ftool);
            //toolCollection.add(etool);

            Char charInput;
            String strInput;
            Char input;


            ////TLS.listTools(member);
            ////foreach (String stringInArray in TLS.listTools(member))
            ////{
            ////    Console.WriteLine(stringInArray);
            ////}
            ////TLS.add(ftool, 5);
            ////toolArray = toolCollection.toArray();
            ////Console.WriteLine(toolArray[1].Quantity);
            ////Console.WriteLine(expectedArray[0].Quantity);
            ////memberCollection.add(new Member("asdasdd", "asdasd", "0458asdaasd", "1234"));
            ////memberCollection.add(new Member("Fidel", "Seng", "0458938543", "1234"));
            ////members = memberCollection.toArray();
            ////foreach (Member test in members)
            ////{
            ////    Console.WriteLine(test.FirstName + test.LastName);
            ////}
            //Console.ReadKey();

            //MAIN MENU
            Console.WriteLine("Welcome to the Tool Library");
            Console.WriteLine("===========Main Menu===========");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("===============================\n");
            Console.WriteLine("Please make a selection (1-2, or 0 to exit):\n\n\t");



            //char input = Console.ReadKey().KeyChar;
            while (!Char.TryParse(Console.ReadLine(), out charInput))
            {
                Console.WriteLine("Invalid input, try again");
                Console.ReadKey();
            }

            input = Console.ReadKey().KeyChar;
            if (input == '1') // Staff Login
            {
                Console.Clear();
                Console.WriteLine("Enter staff login details");
                Console.Write("Username: ");
                String user = Console.ReadLine();
                Console.Write("Password: ");
                String pass = Console.ReadLine();

                if (member.staffLogin(user, pass) == true)
                {
                    //STAFF MENU
                    Console.Clear();
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
                }
            } else if (charInput == '2') // Member login
            {
                Console.Clear();
                Console.WriteLine("Enter member login details");
                Console.Write("First Name: ");
                String firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                String lastName = Console.ReadLine();
                Console.Write("Password: ");
                String PIN = Console.ReadLine();

                if(true)
                //if(member.login(firstName, lastName, PIN, BSTree) == true)
                {
                    currentMember = new Member(firstName, lastName);
                    //MEMBER MENU
                    Console.Clear();
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
                    input = Console.ReadKey().KeyChar;
                    if (input == '1') // Display tools of a tool type
                    {
                        Console.Clear();
                        Console.WriteLine("Please make a selection (1-9, or 0 to return to main menu):");
                        string[] enumarray = Enum.GetNames(typeof(Tool.toolCategory));
                        int index = 1;
                        foreach (string element in enumarray)
                        {
                            Console.WriteLine(index + ". " + element);
                            index++;
                        }
                        input = Console.ReadKey().KeyChar;

                        Console.Clear();
                        switch(input)
                        {
                            case '1':
                                toolArray = toolCollection.toArray();
                                TLS.displayTools("Gardening", toolArray);
                                //toolCollection.displayToolsOfToolType("Gardening");
                                break;
                            case '2':
                                toolArray = toolCollection.toArray();
                                TLS.displayTools("Sanding", toolArray);
                                //toolCollection.displayToolsOfToolType("Flooring");
                                break;
                            case '3':
                                toolArray = toolCollection.toArray();
                                TLS.displayTools("Sanding", toolArray);
                                //toolCollection.displayToolsOfToolType("Fencing");
                                break;
                            case '4':
                                toolArray = toolCollection.toArray();
                                TLS.displayTools("Sanding", toolArray);
                                //toolCollection.displayToolsOfToolType("Measuring");
                                break;
                            case '5':
                                toolArray = toolCollection.toArray();
                                TLS.displayTools("Sanding", toolArray);
                                //toolCollection.displayToolsOfToolType("Cleaning");
                                break;
                            case '6':
                                toolArray = toolCollection.toArray();
                                TLS.displayTools("Sanding", toolArray);
                                //toolCollection.displayToolsOfToolType("Painting");
                                break;
                            case '7':
                                toolArray = toolCollection.toArray();
                                TLS.displayTools("Sanding", toolArray);
                                //toolCollection.displayToolsOfToolType("Electronic");
                                break;
                            case '8':
                                toolArray = toolCollection.toArray();
                                TLS.displayTools("Sanding", toolArray);
                                //toolCollection.displayToolsOfToolType("Electricity");
                                break;
                            case '9':
                                toolArray = toolCollection.toArray();
                                TLS.displayTools("Sanding", toolArray);
                                //toolCollection.displayToolsOfToolType("Automotive");
                                break;
                        }
                        Console.ReadKey();
                    } else if (input == '2') //Borrow a tool
                    {
                        Console.Clear();

                        Console.WriteLine("Please make a selection (1-9):");
                        string[] enumarray = Enum.GetNames(typeof(Tool.toolCategory));
                        int index = 1;
                        foreach (string element in enumarray)
                        {
                            Console.WriteLine(index + ". " + element);
                            index++;
                        }

                        int selectedCategory = Console.ReadKey().KeyChar;
                        int selectedType;
                        Tool.toolCategory selectedCategoryEnum = Tool.toolCategory.Automotive;
                        Tool.toolType selectedTypeEnum = Tool.toolType.airCompressors;

                        Console.Clear();
                        switch (selectedCategory)
                        {
                            case '1': // Gardening Category
                                Console.WriteLine("Please make a selection (1-5):");
                                toolCollection.displayToolsOfToolType("Gardening");
                                selectedCategoryEnum = Tool.toolCategory.Gardening;
                                selectedType = Console.ReadKey().KeyChar;
                                switch (selectedType)
                                {
                                    case '1':
                                        selectedTypeEnum = Tool.toolType.lineTrimmers;
                                        break;
                                    case '2':
                                        selectedTypeEnum = Tool.toolType.lawnMowers;
                                        break;
                                    case '3':
                                        selectedTypeEnum = Tool.toolType.handTools;
                                        break;
                                    case '4':
                                        selectedTypeEnum = Tool.toolType.wheelbarrows;
                                        break;
                                    case '5':
                                        selectedTypeEnum = Tool.toolType.gardenPowerTools;
                                        break;
                                }
                                break;
                            case '2': // Flooring Category
                                Console.WriteLine("Please make a selection (1-6):");
                                toolCollection.displayToolsOfToolType("Flooring");
                                selectedCategoryEnum = Tool.toolCategory.Flooring;
                                selectedType = Console.ReadKey().KeyChar;
                                switch (selectedType)
                                {
                                    case '1':
                                        selectedTypeEnum = Tool.toolType.scrapers;
                                        break;
                                    case '2':
                                        selectedTypeEnum = Tool.toolType.floorLasers;
                                        break;
                                    case '3':
                                        selectedTypeEnum = Tool.toolType.floorLevellingTools;
                                        break;
                                    case '4':
                                        selectedTypeEnum = Tool.toolType.floorLevellingMaterials;
                                        break;
                                    case '5':
                                        selectedTypeEnum = Tool.toolType.floorHandTools;
                                        break;
                                    case '6':
                                        selectedTypeEnum = Tool.toolType.tilingTools;
                                        break;
                                }
                                break;
                            case '3': //Fencing Tools
                                Console.WriteLine("Please make a selection (1-5):");
                                toolCollection.displayToolsOfToolType("Fencing");
                                selectedCategoryEnum = Tool.toolCategory.Fencing;
                                selectedType = Console.ReadKey().KeyChar;
                                switch (selectedType)
                                {
                                    case '1': 
                                        selectedTypeEnum = Tool.toolType.fencingHandTools;
                                        break;
                                    case '2':
                                        selectedTypeEnum = Tool.toolType.electricFencing;
                                        break;
                                    case '3':
                                        selectedTypeEnum = Tool.toolType.steelFencingTools;
                                        break;
                                    case '4':
                                        selectedTypeEnum = Tool.toolType.powerTools;
                                        break;
                                    case '5':
                                        selectedTypeEnum = Tool.toolType.fencingAccessories;
                                        break;
                                }
                                break;
                            case '4': //Measuring Tools
                                Console.WriteLine("Please make a selection (1-6):");
                                toolCollection.displayToolsOfToolType("Measuring");
                                selectedCategoryEnum = Tool.toolCategory.Measuring;
                                selectedType = Console.ReadKey().KeyChar;
                                switch (selectedType)
                                {
                                    case '1':
                                        selectedTypeEnum = Tool.toolType.distanceTools;
                                        break;
                                    case '2':
                                        selectedTypeEnum = Tool.toolType.laserMeasurer;
                                        break;
                                    case '3':
                                        selectedTypeEnum = Tool.toolType.measuringJugs;
                                        break;
                                    case '4':
                                        selectedTypeEnum = Tool.toolType.temperatureHumidityTools;
                                        break;
                                    case '5':
                                        selectedTypeEnum = Tool.toolType.floorLevellingTools;
                                        break;
                                    case '6':
                                        selectedTypeEnum = Tool.toolType.markers;
                                        break;
                                }
                                break;
                            case '5': //Cleaning Tools
                                Console.WriteLine("Please make a selection (1-6):");
                                toolCollection.displayToolsOfToolType("Cleaning");
                                selectedCategoryEnum = Tool.toolCategory.Cleaning;
                                selectedType = Console.ReadKey().KeyChar;
                                switch (selectedType)
                                {
                                    case '1':
                                        selectedTypeEnum = Tool.toolType.draining;
                                        break;
                                    case '2':
                                        selectedTypeEnum = Tool.toolType.carCleaning;
                                        break;
                                    case '3':
                                        selectedTypeEnum = Tool.toolType.vacuum;
                                        break;
                                    case '4':
                                        selectedTypeEnum = Tool.toolType.pressureCleaners;
                                        break;
                                    case '5':
                                        selectedTypeEnum = Tool.toolType.poolCleaning;
                                        break;
                                    case '6':
                                        selectedTypeEnum = Tool.toolType.floorCleaning;
                                        break;
                                }
                                break;
                            case '6': //Painting Tools
                                Console.WriteLine("Please make a selection (1-6):");
                                toolCollection.displayToolsOfToolType("Painting");
                                selectedCategoryEnum = Tool.toolCategory.Painting;
                                selectedType = Console.ReadKey().KeyChar;
                                switch (selectedType)
                                {
                                    case '1':
                                        selectedTypeEnum = Tool.toolType.sanding;
                                        break;
                                    case '2':
                                        selectedTypeEnum = Tool.toolType.brushes;
                                        break;
                                    case '3':
                                        selectedTypeEnum = Tool.toolType.rollers;
                                        break;
                                    case '4':
                                        selectedTypeEnum = Tool.toolType.paintRemoval;
                                        break;
                                    case '5':
                                        selectedTypeEnum = Tool.toolType.paintScrapers;
                                        break;
                                    case '6':
                                        selectedTypeEnum = Tool.toolType.sprayers;
                                        break;
                                }
                                break;
                            case '7': // Electronic tools
                                Console.WriteLine("Please make a selection (1-5):");
                                toolCollection.displayToolsOfToolType("Electronic");
                                selectedCategoryEnum = Tool.toolCategory.Electronic;
                                selectedType = Console.ReadKey().KeyChar;
                                switch (selectedType)
                                {
                                    case '1':
                                        selectedTypeEnum = Tool.toolType.voltageTester;
                                        break;
                                    case '2':
                                        selectedTypeEnum = Tool.toolType.oscilloscopes;
                                        break;
                                    case '3':
                                        selectedTypeEnum = Tool.toolType.thermalImaging;
                                        break;
                                    case '4':
                                        selectedTypeEnum = Tool.toolType.dataTestTool;
                                        break;
                                    case '5':
                                        selectedTypeEnum = Tool.toolType.insulationTesters;
                                        break;
                                }
                                break;
                            case '8': // Electricity tools
                                Console.WriteLine("Please make a selection (1-5):");
                                toolCollection.displayToolsOfToolType("Electricity");
                                selectedCategoryEnum = Tool.toolCategory.Electricity;
                                selectedType = Console.ReadKey().KeyChar;
                                switch (selectedType)
                                {
                                    case '1':
                                        selectedTypeEnum = Tool.toolType.testEquipment;
                                        break;
                                    case '2':
                                        selectedTypeEnum = Tool.toolType.safetyEquipment;
                                        break;
                                    case '3':
                                        selectedTypeEnum = Tool.toolType.basicHandTools;
                                        break;
                                    case '4':
                                        selectedTypeEnum = Tool.toolType.circuitProtection;
                                        break;
                                    case '5':
                                        selectedTypeEnum = Tool.toolType.cableTools;
                                        break;
                                }
                                break;
                            case '9': //Automotive tools
                                Console.WriteLine("Please make a selection (1-6):");
                                toolCollection.displayToolsOfToolType("Automotive");
                                selectedCategoryEnum = Tool.toolCategory.Automotive;
                                selectedType = Console.ReadKey().KeyChar;
                                switch (selectedType)
                                {
                                    case '1':
                                        selectedTypeEnum = Tool.toolType.jacks;
                                        break;
                                    case '2':
                                        selectedTypeEnum = Tool.toolType.airCompressors;
                                        break;
                                    case '3':
                                        selectedTypeEnum = Tool.toolType.batteryChargers;
                                        break;
                                    case '4':
                                        selectedTypeEnum = Tool.toolType.socketTools;
                                        break;
                                    case '5':
                                        selectedTypeEnum = Tool.toolType.braking;
                                        break;
                                    case '6':
                                        selectedTypeEnum = Tool.toolType.drivetrain;
                                        break;
                                }
                                break;
                        }

                        Console.WriteLine("What is the name of the tool?");
                        string toolName = Console.ReadLine();
                        Tool desiredTool = new Tool(selectedCategoryEnum, selectedTypeEnum, toolName, 1);
                        TLS.borrowTool(currentMember, desiredTool);
                        Console.ReadKey();
                    } else if (input == '3') //Returning a tool
                    {
                        Console.WriteLine("What tool would you like to return?");
                        Console.Write("Category: ");
                        Console.Write("Type: ");
                    }
                }
            } else
            {

            }
            Console.Clear();
            Console.WriteLine("FINAL WINDOW");
            Console.ReadKey();
        }
    }
}
