﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Management_System.Models
{
    public class Transaction
    {
        public int TransactionId {  get; set; }
        public int AccountId { get; set; } 
        public DateTime Date { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
 

    }
}