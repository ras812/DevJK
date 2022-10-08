using System;
using System.Collections.Generic;

namespace TypesInCSharp
{
	public class ConsoleView
	{
		public string[] SystemConsoleColors { get; private set; }

		public ConsoleView()
		{
			SystemConsoleColors = GetSystemConsoleColors();
		}

		#region START Methods
		public void StartChangeConsoleView()
		{
			Console.Clear();

			DisplayMenuConsoleView();

			while (true)
			{
				char c = Handlers.InPutHandler();
				if (c == '1')
				{
					int menuSelector = Convert.ToInt32(c.ToString());
					StartMenuSelectColor(menuSelector);
					break;
				}
				else if (c == '2')
				{
					int menuSelector = Convert.ToInt32(c.ToString());
					StartMenuSelectColor(menuSelector);
                    break;
                }
                else if (c == '0')
				{
					MainMenu m = new MainMenu();
					m.StartMainMenu();
					break;
				}
            }
		}

        private void StartMenuSelectColor(int menuSelector)
        {
            Console.Clear();
            DisplayMenuSelectColor(menuSelector);
            int subMenuSelector = 1;

            while (true)
            {
                char c = Handlers.InPutHandler();
                if (c == '1' || c == '2' || c == '3' || c == '4' || c == '5'
                    || c == '6' || c == '7' || c == '8')
                {
                    int num = Convert.ToInt32(c.ToString()) - 1;
                    if (subMenuSelector == 2)
                    {
                        num += 8;
                    }
                    ChangeColor(menuSelector, num);
                    StartChangeConsoleView();
                    break;
                }

                else if (c == '9' && subMenuSelector == 1)
                {
                    subMenuSelector = 2;
                    DisplayMenuSelectColor(menuSelector, subMenuSelector);
                }

                else if (c == '9' && subMenuSelector == 2)
                {
                    subMenuSelector = 1;
                    DisplayMenuSelectColor(menuSelector, subMenuSelector);
                }

                else if (c == '0')
                {
					MainMenu m = new MainMenu();
					m.StartMainMenu();
                    break;
                }

            }
        }
		#endregion

		#region DISPLAY Methods
		private void DisplayMenuConsoleView()
		{
            Console.Clear();
            Console.WriteLine($"Select console view to change:\n" +
                              $"================\n" +
                              $"[1] - [ BACKGROUND COLOR ]\n" +
                              $"[2] - [ FOREGROUND COLOR ]\n" +
                              $"================\n" +
                              $"[0] - [ MAIN MENU ]"
                             );
        }

        private void DisplayMenuSelectColor(int menuSelector, int subMenuSelector=1)
		{
			Console.Clear();

			string selector = menuSelector == 1 ? "BACKGROUND" : "FOREGROUND";
			string nextPrevious = subMenuSelector == 1 ? "=>" : "<=";

			Console.WriteLine($"Select {selector} color:\n" +
							  $"================"
							 );

			ParseColors(subMenuSelector);

			Console.WriteLine($"================\n" +
							  $"[9] - [ {nextPrevious} ]\n" +
                              $"[0] - [ MAIN MENU ]"
                             );
        }
		#endregion

		#region ETC
		private void ChangeColor(int menuSelector, int colorNum)
		{
			if (menuSelector <= 1)
			{
				Console.BackgroundColor = (ConsoleColor)colorNum;
			}
			else
			{
				Console.ForegroundColor = (ConsoleColor)colorNum;
			}
		}

		private void ParseColors(int subMenuSelector)
		{
			if (subMenuSelector <= 1)
			{
				for (int i = 0; i < SystemConsoleColors.Length/2; i++)
				{
					Console.WriteLine($"[{i + 1}] - [ {SystemConsoleColors[i]} ]");
				}
			}
			else
			{
                for (int i = SystemConsoleColors.Length / 2; i < SystemConsoleColors.Length; i++)
                {
                    Console.WriteLine($"[{i - 7}] - [ {SystemConsoleColors[i]} ]");
                }

            }
        }

        private string[] GetSystemConsoleColors()
		{
			var temp = typeof(ConsoleColor).GetFields();

			List<string> LColors = new List<string>();

			for (int i = 0; i < temp.Length; i++)
			{
				if (char.IsUpper(temp[i].Name[0]))
				{
					LColors.Add(temp[i].Name);
				}
			}

			return LColors.ToArray();
		}
        #endregion
    }
}

