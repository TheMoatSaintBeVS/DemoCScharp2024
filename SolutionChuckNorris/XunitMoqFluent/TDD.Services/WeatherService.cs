using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Services
{
    public class WeatherService
    {

       public  int GetTemperature( int temperature, int year )
        {
            int yearDifference = (year - DateTime.Now.Year);
            int decade = 0; 
            if (yearDifference > 10)
            {
                decade = (yearDifference % 10);
            }
            return yearDifference * 2 + decade + temperature ;
        }
    }
}
