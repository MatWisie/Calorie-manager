using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menedzer_Kalorii
{
    class kcalDefining
    {

        public static double foodKcalDefine(string foodType)
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
                case "Ananas":
                    return 0.5;
                case "Awokado":
                    return 1.49;
                case "Banan":
                    return 0.89;
                case "Borówka":
                    return 0.57;
                case "Brzoskwinia":
                    return 0.39;
                case "Cytryna":
                    return 0.29;
                case "Czereśnie":
                    return 0.56;
                case "Figi":
                    return 0.65;
                case "Granat":
                    return 0.83;
                case "Grejpfrut":
                    return 0.35;
                case "Gruszka":
                    return 0.55;
                case "Boczek(smażony)":
                    return 5.04;
                case "Boczek(pieczony)":
                    return 5.48;
                case "Filet z kurczaka":
                    return 1.50;
                case "Jagnięcina":
                    return 2;
                case "Kiełbasa":
                    return 3;
                case "Kotlet schabowy":
                    return 1.96;
                case "Kotlet mielony":
                    return 2.07;
                case "Feta":
                    return 2.64;
                case "Kefir":
                    return 0.52;
                case "Majonez":
                    return 3.12;
                case "Margaryna":
                    return 6.84;
                case "Masło":
                    return 7.57;
                case "Maślanka":
                    return 0.53;
                case "Mleko":
                    return 0.50;
                case "Ser":
                    return 3.61;
                case "Twaróg":
                    return 0.97;
                case "Coca-cola":
                    return 0.40;
                case "Gin":
                    return 2.63;
                case "Herbata ziołowa":
                    return 0.01;
                case "Herbata cytrynowa":
                    return 0.02;
                case "Herbata cynamonowa":
                    return 0.01;
                case "Piwo":
                    return 0.43;
                case "Woda":
                    return 0.00;


                default:
                    return 0;

            }
                
        }
        public static double burnedKcalDefine(string exerciseType)
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
                case "Piłka nożna":
                    return 9;
                case "Piłka ręczna":
                    return 12;
                case "Siatkówka":
                    return 4;
                case "Rower":
                    return 4;
                case "Wiosłowanie":
                    return 4;
                default:
                    return 0;

            }

        }
    }
}
