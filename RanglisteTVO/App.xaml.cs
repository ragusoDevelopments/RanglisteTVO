﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Services;
using NavigationEngine;

namespace RanglisteTVO
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static LocalDBService dbService = new LocalDBService(Environment.CurrentDirectory + "\\TestDB.sqlite");
        public static NavigationController navEngine = new NavigationController();
    }
}
