using System;
using System.Reflection;

namespace HasASecret
{
    class HasASecret
    {
        // this class has a secret field. Does the private keyword make it secure?
        private string secret = "xyzzy";
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            HasASecret keeper = new HasASecret();

            // uncommenting this Console.WriteLine statement causes a compiler error:
            // 'HasASecret.secret' is inaccessible due to its protection level
            // Console.WriteLine(keeper.secret);

            // But we can still use reflection to get the value of the secret field
            FieldInfo[] fields = keeper.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            // this foreach loop will cause "xyzzy" to be printed to the console
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field.GetValue(keeper));
            }
        }
    }
}
