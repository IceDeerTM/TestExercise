﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercise.Services
{
    internal class ConsolePrintService : IPrintService
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
