using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingLogic
{
    public class Greeting
    {
        public string GetString()
        {
            string greeting = "Why, Hello There!";
            int hour = DateTime.Now.Hour;
            if (hour < 12)
                greeting = "What a glourious morning!";
            else if (hour > 18)
                greeting = "What a glourious evening";
            return greeting;
        }
    }
}
   