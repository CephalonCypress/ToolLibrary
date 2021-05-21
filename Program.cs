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
            ToolCollection toolCollection = new ToolCollection();
            Member member = new Member();
            MemberCollection memberCollection = new MemberCollection();
            ToolLibrarySystem TLS = new ToolLibrarySystem();

            Member[] members = new Member[0];
            Tool[] toolArray = new Tool[] { };

            IBSTree BSTree = memberCollection.getBST();
            Member currentMember;
            UserInterface UI = new UserInterface();

            //int selectedCategory;
            //int selectedType;
            //Tool.toolCategory selectedCategoryEnum = Tool.toolCategory.Gardening;
            //Tool.toolType selectedTypeEnum = Tool.toolType.airCompressors;
            //var selectedCategoryAndType = (Tool.toolCategory.Automotive, Tool.toolType.airCompressors);

            String firstName = "";
            String lastName = "";

            Char charInput = '0';
            //String strInput;
            //Char input;


            //Hashtable memberLoanHT;
            //Hashtable toolLoanHT;
            bool StaffLoggedIn = false;
            bool MemberLoggedIn = false;

            //TLS.borrowTool(member, tool);

            //act
            //TLS.borrowTool(member, tool);
            //TLS.returnTool(member, tool);

            //Tool selectedTool, expectedTool;
            //Tool stool = new Tool(Tool.toolCategory.Painting, Tool.toolType.sanding, "Gardening Tool", 1);
            //Tool ftool = new Tool(Tool.toolCategory.Painting, Tool.toolType.sanding, "Garden Tool", 2);
            //Tool etool = new Tool(Tool.toolCategory.Painting, Tool.toolType.sanding, "Gardens Tool", 3);

            //toolCollection.add(stool);
            //toolCollection.add(ftool);
            //toolCollection.add(etool);
            //assert


            //selectedTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 5);

            //Tool[] toolArray = new Tool[] { };
            //Tool[] expectedArray = new Tool[] { expectedTool = new Tool(Tool.toolCategory.Gardening, Tool.toolType.sanding, "Gardening Tool", 10) };

            ////act
            //toolCollection.add(stool);
            //toolCollection.add(ftool);
            //toolCollection.add(etool);

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
            while (true)
            {
                if (StaffLoggedIn == false || MemberLoggedIn == false)
                {
                    Console.Clear();
                    Console.WriteLine("\tWelcome to the Tool Library");
                    Console.WriteLine("\t===========Main Menu=============");
                    Console.WriteLine("\t1. Staff Login");
                    Console.WriteLine("\t2. Member Login");
                    Console.WriteLine("\t0. Exit");
                    Console.WriteLine("\t=================================\n");
                    Console.WriteLine("Please make a selection (1-2, or 0 to exit):\n\n\t");
                    charInput = UI.takeCharInput(0);

                    switch (charInput)
                    {
                        case '1':
                            Console.Clear();
                            Console.WriteLine("\tWelcome to the Tool Library");
                            Console.WriteLine("\t===========Main Menu=============\n");
                            Console.WriteLine("\tEnter staff login details");
                            Console.Write("Username: ");
                            String user = Console.ReadLine();
                            Console.Write("Password: ");
                            String pass = Console.ReadLine();

                            if (member.staffLogin(user, pass))
                            {
                                StaffLoggedIn = true;
                            }

                            //Staff logged in successfully
                            if (StaffLoggedIn)
                            {
                                while (true)
                                {
                                    if (!UI.StaffMenuInterface())
                                    {
                                        StaffLoggedIn = false;
                                        Main(new string[1]);
                                        break;
                                    }
                                    else
                                    {
                                        UI.StaffMenuInterface();
                                    }
                                }
                            }

                            break;
                        case '2':
                            Console.Clear();
                            Console.WriteLine("\tEnter member login details");
                            Console.Write("\tFirst Name: ");
                            firstName = Console.ReadLine();
                            Console.Write("\tLast Name: ");
                            lastName = Console.ReadLine();
                            Console.Write("\tPassword: ");
                            String PIN = Console.ReadLine();

                            currentMember = new Member(firstName, lastName, PIN);
                            if (member.login(firstName, lastName, PIN, BSTree))
                            {
                                MemberLoggedIn = true;
                            }
                            MemberLoggedIn = true; //TESTING ONLY

                            //Member logged in successfully
                            if (MemberLoggedIn)
                            {
                                while (true)
                                {
                                    if (!UI.MemberMenuInterface(currentMember))
                                    {
                                        MemberLoggedIn = false;
                                        Main(new string[1]);
                                        break;
                                    }
                                    else
                                    {
                                        UI.MemberMenuInterface(currentMember);
                                    }
                                }
                            }

                            break;
                        case '0':
                            break;
                    }

                    Console.Clear();
                    Console.WriteLine("FINAL WINDOW");
                    Console.ReadKey();
                }
            }
            
        } 
    }
}
