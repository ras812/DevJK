using System;

namespace TypesInCSharp
{
	public class MainMenu
	{
        public void StartMainMenu()
        {
            DisplayMainMenu();
            while (true)
            {
                char inputChar = Handlers.InPutHandler();

                switch (inputChar)
                {
                    case '1':
                        var showAllType = new ShowAllTypeInfo();
                        showAllType.StartShowAllTypeInfo();
                        break;
                    case '2':
                            var selectType = new SelectTypeInfo();
                            selectType.StartSelectTypeInfo();
                            break;
                    case '3':
                        var consoleView = new ConsoleView();
                        consoleView.StartChangeConsoleView();
                        break;
                    case '0':
                        Console.Clear();
                        Console.WriteLine($"PROGRAM TERMINATED WITH ERROR [0]");
                        Environment.Exit(0);
                        break;
                    //default:
                    //    continue;
                }

                //if (c == '1')
                //{
                //    var showAllType = new ShowAllTypeInfo();
                //    showAllType.StartShowAllTypeInfo();
                //    break;
                //}
                //else if (c == '2')
                //{
                //    var selectType = new SelectTypeInfo();
                //    selectType.StartSelectTypeInfo();
                //    break;
                //}
                //else if (c == '3')
                //{
                //    var consoleView = new ConsoleView();
                //    consoleView.StartChangeConsoleView();
                //    break;
                //}
                //else if (c == '0')
                //{
                //    Console.Clear();
                //    Console.WriteLine($"PROGRAM TERMINATED WITH ERROR [0]");
                //    Environment.Exit(0);
                //}
            }
        }

		private void DisplayMainMenu()
		{
            Console.Clear();
            Console.WriteLine($"=== WELLCOME ===\n" +
                              $"===    to    ===\n" +
                              $"=== TYPEINFO ===\n" +
                              $"================\n" +
                              $"[1] - [ Show all type info ]\n" +
                              $"[2] - [ Select by type ]\n" +
                              $"[3] - [ Change console view ]\n" +
                              $"================\n" +
                              $"[0] - [ Quit program ]"
                             );
        }
    }
}

