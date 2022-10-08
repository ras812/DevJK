using System;
using System.Collections.Generic;
using System.Reflection;

namespace TypesInCSharp
{
    public class AssemblyInfo
    {
        private readonly List<Type> _ltypes = new List<Type>();

        public int AssemblyCounts { get; private set; }
        public int TypeCountsInAllAssemblies { get; private set; }
        public int ReferenceTypeCounts { get; private set; }
        public int ValueTypeCounts { get; private set; }
        public int InterfaceTypeCount { get; private set; }

        public string TypeWithMaxMethodsCount { get; private set; }
        public string LongestMethodsName { get; private set; }
        public string MethodNameWithMaxArguments { get; private set; }


        public AssemblyInfo()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            _ltypes = GetTypesList(assemblies);

            AssemblyCounts = GetAssemblyCounts();
            TypeCountsInAllAssemblies = GetTypeCountsInAllAssemblies();
            
            GetRefValInterTypesCount(out int refTCount, out int valTCount, out int interTCount);
            ReferenceTypeCounts = refTCount;
            ValueTypeCounts = valTCount;
            InterfaceTypeCount = interTCount;

            TypeWithMaxMethodsCount = GetTypeWithMaxMethodsCount();
            LongestMethodsName = GetLongestMethodsName();
            MethodNameWithMaxArguments = GetMethodNameWithMaxArguments();
        }


        #region Ctor FOR TEST
        public AssemblyInfo(Type t)
        {
            _ltypes.Add(t);

            AssemblyCounts = GetAssemblyCounts();
            TypeCountsInAllAssemblies = GetTypeCountsInAllAssemblies();

            GetRefValInterTypesCount(out int refTCount, out int valTCount, out int interTCount);
            ReferenceTypeCounts = refTCount;
            ValueTypeCounts = valTCount;
            InterfaceTypeCount = interTCount;

            TypeWithMaxMethodsCount = GetTypeWithMaxMethodsCount();
            LongestMethodsName = GetLongestMethodsName();
            MethodNameWithMaxArguments = GetMethodNameWithMaxArguments();
        }
        #endregion

        #region PROPERTIES_HANDLERS
        private List<Type> GetTypesList(Assembly[] assemblies)
        {
            List<Type> res = new List<Type>();

            foreach (Assembly asm in assemblies)
            {
                foreach (var item in asm.GetTypes())
                {
                    res.Add(item);
                }
            }

            return res;
        }

        private int GetAssemblyCounts()
        {
            var ass = AppDomain.CurrentDomain.GetAssemblies();
            return ass.Length;
        }

        private int GetTypeCountsInAllAssemblies()
        {
            return _ltypes.Count;
        }

        private void GetRefValInterTypesCount(out int refTCount, out int valTCount, out int interTCount)
        {
            refTCount = 0;
            valTCount = 0;
            interTCount = 0;

            foreach (var item in _ltypes)
            {
                if (item.IsClass)
                {
                    refTCount++;
                }
                else if (item.IsValueType)
                {
                    valTCount++;
                }
                else if (item.IsInterface)
                {
                    interTCount++;
                }
            }
        }

        private string GetTypeWithMaxMethodsCount()
        {
            Dictionary<string, int> methodsInTypeCount = new Dictionary<string, int>();

            foreach (var item in _ltypes)
            {
                if (!methodsInTypeCount.ContainsKey(item.Name))
                {
                    methodsInTypeCount.Add(item.Name, item.GetMethods().Length);
                }
            }

            int maxCount = 0;
            string res = "";

            foreach (var item in methodsInTypeCount)
            {
                if (item.Value >= maxCount)
                {
                    maxCount = item.Value;
                    res = item.Key;
                }
            }

            return res;
        }

        private string GetLongestMethodsName()
        {
            string res = "";
            List<string> methodsNameList = new List<string>();

            foreach (var type in _ltypes)
            {
                foreach (var method in type.GetMethods())
                {
                    if (method.Name.Length >= res.Length)
                    {
                        res = method.Name;
                    }
                }
            }

            return res;
        }

        private string GetMethodNameWithMaxArguments()
        {
            int maxArgs = 0;
            string res = "";

            foreach (var type in _ltypes)
            {
                foreach (var method in type.GetMethods())
                {
                    if (method.GetParameters().Length >= maxArgs)
                    {
                        maxArgs = method.GetParameters().Length;
                        res = method.Name;
                    }
                }
            }
            return res;
        }
        #endregion
    }

	public class ShowAllTypeInfo
	{

		public void StartShowAllTypeInfo()
        {
            DisplayShowAllTypeInfo(new AssemblyInfo());
            
            while (true)
            {
                char c = Handlers.InPutHandler();
                if (c == '0')
                {
                    MainMenu m = new MainMenu();
                    m.StartMainMenu();
                    break;
                }
            }
		}

		private void DisplayShowAllTypeInfo(AssemblyInfo asi)
		{
            Console.Clear();
            Console.WriteLine($"General info by types in assemblies\n" +
                              $"================\n" +
                              $"Assemblies: {asi.AssemblyCounts}\n" +
                              $"Types in all assemblies: {asi.TypeCountsInAllAssemblies}\n" +
                              $"References type: {asi.ReferenceTypeCounts}\n" +
                              $"Values type: {asi.ValueTypeCounts}\n" +
                              $"Interface type: {asi.InterfaceTypeCount}\n" +
                              $"Type with max methods count: {asi.TypeWithMaxMethodsCount}\n" +
                              $"Longest methods name: {asi.LongestMethodsName}\n" +
                              $"Method with max arguments: {asi.MethodNameWithMaxArguments}\n" +
                              $"================\n" +
                              $"[0] - [ MAIN MENU ]"
                             );
        }
    }
}

