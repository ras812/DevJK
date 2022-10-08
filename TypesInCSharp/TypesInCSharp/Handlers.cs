using System;
namespace TypesInCSharp
{
	class Handlers
	{
		public static char InPutHandler()
		{
			return char.ToLower(Console.ReadKey(true).KeyChar);
		}
	}
}

