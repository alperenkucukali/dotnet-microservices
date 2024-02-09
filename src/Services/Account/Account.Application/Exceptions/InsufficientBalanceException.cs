﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Exceptions
{
    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(decimal currentBalance)
            : base($"Insufficient balance.Your current balance is {currentBalance}")
        {
        }
    }
}
