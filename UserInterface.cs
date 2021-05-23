using BSTreeInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLibrary
{
    public class UserInterface
    {
        Tool tool = new Tool();
        ToolCollection toolCollection = new ToolCollection();
        Member member = new Member();
        MemberCollection memberCollection = new MemberCollection();
        ToolLibrarySystem TLS = new ToolLibrarySystem();
        Member[] members = new Member[0];
        Tool[] toolArray = new Tool[] { };

        //IBSTree BSTree = memberCollection.getBST();
        //Member currentMember;

        //int selectedCategory;
        //int selectedType;
        Tool.toolCategory selectedCategoryEnum = Tool.toolCategory.Gardening;
        Tool.toolType selectedTypeEnum = Tool.toolType.airCompressors;
        (Tool.toolCategory, Tool.toolType) selectedCategoryAndType = (Tool.toolCategory.Automotive, Tool.toolType.airCompressors);

        string firstName = "";
        string lastName = "";

        Char charInput = '0';
        //Char input;

        string PIN;
        string contactNumber;

        public UserInterface()
        {
            //TESTING ONLY
            Tool dtool = new Tool(Tool.toolCategory.Painting, Tool.toolType.sanding, "Gardening Tool", 1);
            Tool ftool = new Tool(Tool.toolCategory.Painting, Tool.toolType.sanding, "Garden Tool", 2);
            Tool etool = new Tool(Tool.toolCategory.Painting, Tool.toolType.sanding, "Gardens Tool", 3);
            toolCollection.add(dtool);
            toolCollection.add(ftool);
            toolCollection.add(etool);
        }

        public Char takeCharInput(int finalInput)
        {
            Char charinput;

            while (!Char.TryParse(Console.ReadLine(), out charinput))
            {
                Console.WriteLine("Invalid input, try again.");
                Console.WriteLine("Please enter a number between 0-{0}\n", finalInput);
            }

            return charinput;
        }

        public int intInput()
        {
            int intInput;

            while (!Int32.TryParse(Console.ReadLine(), out intInput))
            {
                Console.WriteLine("Invalid input, try again.");
            }

            return intInput;
        }

        // Allows the user to choose a tool type and returns the tool category and type as an enum
        public (Tool.toolCategory, Tool.toolType) chooseToolType(char input)
        {
            char selectedType;

            switch (input)
            {
                case '1':
                    Console.WriteLine("Select the type of the tool (1-5 or 0 to return to main menu)");
                    selectedCategoryEnum = Tool.toolCategory.Gardening;
                    displayToolTypes("Gardening");
                    selectedType = takeCharInput(5);
                    switch (selectedType)
                    {
                        case '1':
                            selectedTypeEnum = Tool.toolType.gardenPowerTools;
                            break;
                        case '2':
                            selectedTypeEnum = Tool.toolType.handTools;
                            break;
                        case '3':
                            selectedTypeEnum = Tool.toolType.lawnMowers;
                            break;
                        case '4':
                            selectedTypeEnum = Tool.toolType.lineTrimmers;
                            break;
                        case '5':
                            selectedTypeEnum = Tool.toolType.wheelbarrows;
                            break;
                    }
                    break;
                case '2':
                    Console.WriteLine("Select the type of the tool (1-6 or 0 to return to main menu)");
                    selectedCategoryEnum = Tool.toolCategory.Flooring;
                    displayToolTypes("Flooring");
                    selectedType = takeCharInput(5);
                    switch (selectedType)
                    {
                        case '1':
                            selectedTypeEnum = Tool.toolType.floorHandTools;
                            break;
                        case '2':
                            selectedTypeEnum = Tool.toolType.floorLasers;
                            break;
                        case '3':
                            selectedTypeEnum = Tool.toolType.floorLevellingMaterials;
                            break;
                        case '4':
                            selectedTypeEnum = Tool.toolType.floorLevellingTools;
                            break;
                        case '5':
                            selectedTypeEnum = Tool.toolType.scrapers;
                            break;
                        case '6':
                            selectedTypeEnum = Tool.toolType.tilingTools;
                            break;
                    }
                    break;
                case '3':
                    Console.WriteLine("Select the type of the tool (1-5 or 0 to return to main menu)");
                    selectedCategoryEnum = Tool.toolCategory.Fencing;
                    displayToolTypes("Fencing");
                    selectedType = takeCharInput(5);
                    switch (selectedType)
                    {
                        case '1':
                            selectedTypeEnum = Tool.toolType.electricFencing;
                            break;
                        case '2':
                            selectedTypeEnum = Tool.toolType.fencingAccessories;
                            break;
                        case '3':
                            selectedTypeEnum = Tool.toolType.fencingHandTools;
                            break;
                        case '4':
                            selectedTypeEnum = Tool.toolType.powerTools;
                            break;
                        case '5':
                            selectedTypeEnum = Tool.toolType.steelFencingTools;
                            break;
                    }
                    break;
                case '4':
                    Console.WriteLine("Select the type of the tool (1-6 or 0 to return to main menu)");
                    selectedCategoryEnum = Tool.toolCategory.Measuring;
                    displayToolTypes("Measuring");
                    selectedType = takeCharInput(6);
                    switch (selectedType)
                    {
                        case '1':
                            selectedTypeEnum = Tool.toolType.distanceTools;
                            break;
                        case '2':
                            selectedTypeEnum = Tool.toolType.floorLevellingTools;
                            break;
                        case '3':
                            selectedTypeEnum = Tool.toolType.laserMeasurer;
                            break;
                        case '4':
                            selectedTypeEnum = Tool.toolType.markers;
                            break;
                        case '5':
                            selectedTypeEnum = Tool.toolType.measuringJugs;
                            break;
                        case '6':
                            selectedTypeEnum = Tool.toolType.temperatureHumidityTools;

                            break;
                    }
                    break;
                case '5':
                    Console.WriteLine("Select the type of the tool (1-6 or 0 to return to main menu)");
                    selectedCategoryEnum = Tool.toolCategory.Cleaning;
                    displayToolTypes("Cleaning");
                    selectedType = takeCharInput(6);
                    switch (selectedType)
                    {
                        case '1':
                            selectedTypeEnum = Tool.toolType.carCleaning;
                            break;
                        case '2':
                            selectedTypeEnum = Tool.toolType.draining;
                            break;
                        case '3':
                            selectedTypeEnum = Tool.toolType.floorCleaning;
                            break;
                        case '4':
                            selectedTypeEnum = Tool.toolType.poolCleaning;
                            break;
                        case '5':
                            selectedTypeEnum = Tool.toolType.pressureCleaners;
                            break;
                        case '6':
                            selectedTypeEnum = Tool.toolType.vacuum;
                            break;
                    }
                    break;
                case '6':
                    Console.WriteLine("Select the type of the tool (1-6 or 0 to return to main menu)");
                    selectedCategoryEnum = Tool.toolCategory.Painting;
                    displayToolTypes("Painting");
                    selectedType = takeCharInput(6);
                    switch (selectedType)
                    {
                        case '1':
                            selectedTypeEnum = Tool.toolType.brushes;
                            break;
                        case '2':
                            selectedTypeEnum = Tool.toolType.paintRemoval;
                            break;
                        case '3':
                            selectedTypeEnum = Tool.toolType.paintScrapers;
                            break;
                        case '4':
                            selectedTypeEnum = Tool.toolType.rollers;
                            break;
                        case '5':
                            selectedTypeEnum = Tool.toolType.sanding;
                            break;
                        case '6':
                            selectedTypeEnum = Tool.toolType.sprayers;
                            break;
                    }
                    break;
                case '7':
                    Console.WriteLine("Select the type of the tool (1-5 or 0 to return to main menu)");
                    selectedCategoryEnum = Tool.toolCategory.Electronic;
                    displayToolTypes("Electronic");
                    selectedType = takeCharInput(5);
                    switch (selectedType)
                    {
                        case '1':
                            selectedTypeEnum = Tool.toolType.dataTestTool;
                            break;
                        case '2':
                            selectedTypeEnum = Tool.toolType.insulationTesters;
                            break;
                        case '3':
                            selectedTypeEnum = Tool.toolType.oscilloscopes;
                            break;
                        case '4':
                            selectedTypeEnum = Tool.toolType.thermalImaging;
                            break;
                        case '5':
                            selectedTypeEnum = Tool.toolType.voltageTester;
                            break;
                    }
                    break;
                case '8':
                    Console.WriteLine("Select the type of the tool (1-5 or 0 to return to main menu)");
                    selectedCategoryEnum = Tool.toolCategory.Electricity;
                    displayToolTypes("Electricity");
                    selectedType = takeCharInput(5);
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
                case '9':
                    Console.WriteLine("Select the type of the tool (1-6 or 0 to return to main menu)");
                    selectedCategoryEnum = Tool.toolCategory.Automotive;
                    displayToolTypes("Automotive");
                    selectedType = takeCharInput(6);
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
            return (selectedCategoryEnum, selectedTypeEnum);
        }

        // displays the Tool categories
        public void displayToolCategories()
        {
            string[] enumarray = Enum.GetNames(typeof(Tool.toolCategory));
            int index = 1;
            foreach (string element in enumarray)
            {
                Console.WriteLine(index + ". " + element);
                index++;
            }
            Console.WriteLine();
        }

        // output the tool types in a string array
        public void displayToolTypes(string category)
        {
            int index = 1;

            String[] strArray = new String[0] { };
            Hashtable toolHT = tool.getHT();
            SortedDictionary<string, string> toolSD = tool.getSD();

            foreach (KeyValuePair<string, string> toolInArray in toolSD)
            {
                if (toolInArray.Value.ToString() == category)
                {
                    Console.WriteLine(index + ". " + toolInArray.Key);
                    index++;
                }
            }
            Console.WriteLine();
        }

        public bool StaffMenuInterface() //Staff Menu
        {
            Tool[] toolsOfSpecifiedTypeArray = new Tool[0];

            //STAFF MENU
            Console.Clear();
            Console.WriteLine("\tWelcome to the Tool Library");
            Console.WriteLine("\t================Staff Menu================");
            Console.WriteLine("\t1. Add a new tool");
            Console.WriteLine("\t2. Add new pieces of an existing tool");
            Console.WriteLine("\t3. Remove some pieces of a tool");
            Console.WriteLine("\t4. Register a new member");
            Console.WriteLine("\t5. Remove a member");
            Console.WriteLine("\t6. Find a contact number of a member");
            Console.WriteLine("\t0. Return to main menu");
            Console.WriteLine("==========================================");
            Console.WriteLine("Please make a selection (1-6, or 0 to return to main menu): \n");

            charInput = takeCharInput(2);
            Console.Clear();

            switch (charInput)
            {
                case '1': // Add new tool to the system
                    Console.WriteLine("\t================Staff Menu================");
                    Console.WriteLine("Select the category of the tool (1-9 or 0 to return to main menu)");
                    displayToolCategories();
                    charInput = takeCharInput(9);
                    //Console.Clear();

                    selectedCategoryAndType = chooseToolType(charInput);
                    selectedCategoryEnum = selectedCategoryAndType.Item1;
                    selectedTypeEnum = selectedCategoryAndType.Item2;
                    //Console.Clear();

                    Console.WriteLine("What is the name of the tool?");
                    String toolName = Console.ReadLine();
                    Console.WriteLine("How many would you like to add?");
                    int toolQuantity = intInput();

                    toolCollection.add(new Tool(selectedCategoryEnum, selectedTypeEnum, toolName, toolQuantity));

                    return true;
                case '2': // INCREASE QUANTITY
                    Console.WriteLine("\t================Staff Menu================");
                    Console.WriteLine("Select the category of the tool (1-9 or 0 to return to main menu)");
                    displayToolCategories();
                    charInput = takeCharInput(9);
                    toolsOfSpecifiedTypeArray = new Tool[0];
                    int quantityToAdd;

                    selectedCategoryAndType = chooseToolType(charInput);
                    selectedCategoryEnum = selectedCategoryAndType.Item1;
                    selectedTypeEnum = selectedCategoryAndType.Item2;

                    toolArray = toolCollection.toArray();
                    int index = 0;
                    foreach (Tool toolInArray in toolArray)
                    {
                        if (toolInArray.Type == selectedTypeEnum)
                        {
                            Array.Resize<Tool>(ref toolsOfSpecifiedTypeArray, toolsOfSpecifiedTypeArray.Length + 1);
                            toolsOfSpecifiedTypeArray[toolsOfSpecifiedTypeArray.Length - 1] = toolInArray;
                            index++;
                        }
                    }

                    TLS.displayTools(selectedTypeEnum.ToString(), toolsOfSpecifiedTypeArray);
                    Console.WriteLine("Select a tool to update");
                    int intinput = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("How many would you like to add?");
                    quantityToAdd = intInput();

                    Tool desiredTool = new Tool(selectedCategoryEnum, selectedTypeEnum, toolArray[intinput - 1].Name, toolArray[intinput - 1].Quantity); 

                    TLS.add(desiredTool, quantityToAdd, toolsOfSpecifiedTypeArray);
                    return true;
                case '3': // DECREASE QUANTITY
                    Console.WriteLine("\t================Staff Menu================");
                    Console.WriteLine("Select the category of the tool (1-9 or 0 to return to main menu)");
                    displayToolCategories();
                    charInput = takeCharInput(9);
                    toolsOfSpecifiedTypeArray = new Tool[0];
                    int quantityToRemove;

                    selectedCategoryAndType = chooseToolType(charInput);
                    selectedCategoryEnum = selectedCategoryAndType.Item1;
                    selectedTypeEnum = selectedCategoryAndType.Item2;

                    toolArray = toolCollection.toArray();
                    index = 0;
                    foreach (Tool toolInArray in toolArray)
                    {
                        if (toolInArray.Type == selectedTypeEnum)
                        {
                            Array.Resize<Tool>(ref toolsOfSpecifiedTypeArray, toolsOfSpecifiedTypeArray.Length + 1);
                            toolsOfSpecifiedTypeArray[toolsOfSpecifiedTypeArray.Length - 1] = toolInArray;
                            index++;
                        }
                    }

                    TLS.displayTools(selectedTypeEnum.ToString(), toolsOfSpecifiedTypeArray);
                    Console.WriteLine("Select a tool to update");
                    intinput = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("How many would you like to remove?");
                    quantityToRemove = intInput();

                    desiredTool = new Tool(selectedCategoryEnum, selectedTypeEnum, toolArray[intinput - 1].Name, toolArray[intinput - 1].Quantity);

                    TLS.delete(desiredTool, quantityToRemove, toolsOfSpecifiedTypeArray);
                    return true;
                case '4': //Register a member
                    Console.WriteLine("\t================Staff Menu================");
                    Console.WriteLine("Details of the member to be added");
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    Console.Write("Phone number: ");
                    contactNumber = Console.ReadLine();
                    Console.Write("PIN number: ");
                    PIN = Console.ReadLine();

                    memberCollection.add(new Member(firstName, lastName, contactNumber, PIN));
                    return true;

                case '5': // Remove a member
                    Console.WriteLine("\t================Staff Menu================");
                    Console.WriteLine("Details of the member to be removed");
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    Console.Write("Phone number: ");
                    contactNumber = Console.ReadLine();
                    Console.Write("PIN number: ");
                    PIN = Console.ReadLine();

                    memberCollection.delete(new Member(firstName, lastName, contactNumber, PIN));
                    return true;

                case '6': //Find the contact number of a member
                    Console.WriteLine("\t================Staff Menu================");
                    Console.WriteLine("Details of the member to be searched");
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();

                    if (memberCollection.searchMember(firstName, lastName) == "-1")
                    {
                        Console.WriteLine("Member not found");
                    } else
                    {
                        Console.WriteLine(firstName + " " + lastName + "'s contact number is " + memberCollection.searchMember(firstName, lastName));
                    }

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    return true;
                case '0': // Return to main menu
                    return false;
            }
            return false;
        }
        public bool MemberMenuInterface(Member currentMember) // Member Menu
        {
            //MEMBER MENU
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library");
            Console.WriteLine("===============Member Menu===============");
            Console.WriteLine("1. Display all the tools of a tool type");
            Console.WriteLine("2. Borrow a tool");
            Console.WriteLine("3. Return a tool");
            Console.WriteLine("4. List all the tools that I am renting");
            Console.WriteLine("5. Display top three (3) most frequently rented tools");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("=========================================\n");
            Console.WriteLine("Please make a selection (1-5, or 0 to return to main menu):");

            //input = Console.ReadKey().KeyChar;
            charInput = takeCharInput(5);

            switch (charInput)
            {
                case '1': // Display tools of a tool type
                    Console.Clear();
                    Console.WriteLine("Please make a selection (1-9, or 0 to return to main menu):");
                    displayToolCategories();
                    charInput = takeCharInput(9);
                    //Console.Clear();

                    selectedCategoryAndType = chooseToolType(charInput);
                    selectedCategoryEnum = selectedCategoryAndType.Item1;
                    selectedTypeEnum = selectedCategoryAndType.Item2;
                    toolArray = toolCollection.toArray();
                    TLS.displayTools(selectedTypeEnum.ToString(), toolArray);

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    
                    return true;

                case '2': // Borrow a tool
                    Console.Clear();

                    Tool[] toolsOfSpecifiedTypeArray = new Tool[] { };
                    Console.WriteLine("Please make a selection (1-9):");
                    displayToolCategories();
                    charInput = takeCharInput(9);
                    int selectedToolIndex = -1;
                    selectedCategoryAndType = chooseToolType(charInput);
                    selectedCategoryEnum = selectedCategoryAndType.Item1;
                    selectedTypeEnum = selectedCategoryAndType.Item2;


                    toolArray = toolCollection.toArray();
                    int index = 0;

                    foreach (Tool toolInArray in toolArray)
                    {
                        if (toolInArray.Type == selectedTypeEnum)
                        {
                            Array.Resize<Tool>(ref toolsOfSpecifiedTypeArray, toolsOfSpecifiedTypeArray.Length + 1);
                            toolsOfSpecifiedTypeArray[toolsOfSpecifiedTypeArray.Length - 1] = toolInArray;
                            index++;
                        }
                    }

                    TLS.displayTools(selectedTypeEnum.ToString(), toolsOfSpecifiedTypeArray);
                    charInput = takeCharInput(toolArray.Length);
                    
                    if(Convert.ToInt32(charInput.ToString()) - 1 > toolsOfSpecifiedTypeArray.Length)
                    {
                        Console.WriteLine("Invalid input, try a lower number");
                    } else
                    {
                        selectedToolIndex = Convert.ToInt32(charInput.ToString()) - 1;
                    }
                    Tool desiredTool = new Tool(selectedCategoryEnum, 
                        selectedTypeEnum, 
                        toolsOfSpecifiedTypeArray[selectedToolIndex].Name,
                        toolsOfSpecifiedTypeArray[selectedToolIndex].Quantity,
                        toolsOfSpecifiedTypeArray[selectedToolIndex].AvailableQuantity,
                        toolsOfSpecifiedTypeArray[selectedToolIndex].timesBorrowed++
                        );
                    TLS.borrowTool(currentMember, desiredTool);
                    Console.ReadKey();
                    return true;

                case '3': // Returning a tool
                    Console.WriteLine("Which tool would you like to return?");
                    TLS.displayBorrowingTools(currentMember);

                    Console.ReadKey();

                    return true;
                case '4': // List all the tools that I am renting
                    TLS.displayBorrowingTools(currentMember);

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(); 
                    return true;
                case '5': // Display top three (3) most frequently rented tools
                    toolArray = toolCollection.toArray();
                    TLS.displayTopThree(toolArray);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    return true;
                case '0':
                    return false;
            }

            return false;
        }
    }
}