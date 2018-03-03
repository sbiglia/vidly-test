﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels.Customers
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes;
        public Customer Customer;
    }
}