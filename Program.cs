using MovieDatabaseA11.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseA11
{
    public class Program
    {
    public static void Main(string[] args)
        {
            IMainService mainService = new MainService();
            mainService.Invoke();
        }
    }
}
