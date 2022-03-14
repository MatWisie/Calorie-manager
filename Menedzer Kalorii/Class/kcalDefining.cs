using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menedzer_Kalorii
{
    class kcalDefining
    {

        public static double define(string foodType)
        {
            switch (foodType)
            {
                case "Bakłażan":
                    return 0.60;
                case "Brokuł":
                    return 0.50;
                case "Brukselka":
                    return 0.4;
                case "Cebula":
                    return 0.35;
                case "Czosnek":
                    return 1.49;
                case "Dynia":
                    return 0.21;
                case "Fasola":
                    return 1.19;



                default:
                    return 0;

            }
                
        }
    }
}
