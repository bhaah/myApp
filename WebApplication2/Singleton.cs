using WebApplication2.LogicLayer;

namespace WebApplication2
{
    public class Singleton
    {
        private static UserLogic _um;
        private Singleton() { }
        public static UserLogic UM
        {
            get
            {
                if(_um==null)
                {
                    _um = new UserLogic();
                    Console.WriteLine("const of singleton");
                }
                return _um;
            }
        }

    }
}
