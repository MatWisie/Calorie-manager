using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menedzer_Kalorii.Class
{
    class burnedKcalDefining
    {
        public static double define(string exerciseType)
        {
            switch (exerciseType)
            {
                case "Bieganie":
                    return 8;
                case "Brzuszki":
                    return 2;
                case "Pompki":
                    return 3;
                case "Skakanka":
                    return 6;
                case "Pływanie":
                    return 4;
                case "Deska":
                    return 3;
                default:
                    return 0;

            }

        }
    }
}
