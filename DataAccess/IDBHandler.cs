﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DataAccess
{
    public interface IDBHandler
    {
        string DBFilePath { get; set; }
        SQLiteConnection GetConnection();
    }
}
