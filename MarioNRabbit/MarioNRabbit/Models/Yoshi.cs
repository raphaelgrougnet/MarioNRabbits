﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioNRabbit.Models
{
    public class Yoshi : FamilleMario
    {
        public Yoshi(string pNom, int pPositionX, int pPositionY, int pNbCasesDeplacementMax, int pNbPointsVie) : base(pNom, pPositionX, pPositionY, pNbCasesDeplacementMax, pNbPointsVie)
        {
        }
    }
}