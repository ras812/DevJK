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
                char c = Handlers.InPutHandler();
                if (c == '1')
                {
                    ShowAllTypeInfo sati = new ShowAllTypeInfo();
                    sati.StartShowAllTypeInfo();
                    break;
                }
                else if (c == '2')
                {
                    SelectTypeInfo sti = new SelectTypeInfo();
                    sti.StartSelectTypeInfo();
                    break;
                }
                else if (c == '3')
                {
                    ConsoleView cv = new ConsoleView();
                    cv.StartChangeConsoleView();
                    break;
                }
                else if (c == '0')
                {
                    Console.Clear();
                    Console.WriteLine($"PROGRAM TERMINATED WITH ERROR [0]");
                    Environment.Exit(0);
                }
            }
        }

		private void DisplayMainMenu()
		{
            Console.Clear();
            Console.WriteLine($"=== WELLCOME ===\n"+
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

