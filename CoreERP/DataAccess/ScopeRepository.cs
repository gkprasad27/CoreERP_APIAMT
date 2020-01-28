﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using CoreERP.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreERP.DataAccess
{
    public class ScopeRepository: ERPContext
    {
        private readonly ERPContext _dbContext;

        public ScopeRepository()
        {
            _dbContext =new ERPContext();
        }
        public DbCommand CreateCommand()
        {
            return _dbContext.Database.GetDbConnection().CreateCommand();
        }
        public DataTable ExecuteParamerizedCommand(DbCommand command)
        {
            DataTable table = new DataTable();
            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    using (DbDataAdapter da = DbProviderFactories.GetFactory(command.Connection).CreateDataAdapter())
                    {
                        da.SelectCommand = command;
                        da.Fill(table);
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
                return table;
            }
        }
    }
}
