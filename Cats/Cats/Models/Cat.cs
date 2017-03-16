﻿using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats
{
    [DataTable("Cats")]
    public class Cat
    {
        [Version]
        public string AzureVersion { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string WebSite { get; set; }

        public string Image { get; set; }

    }
}
