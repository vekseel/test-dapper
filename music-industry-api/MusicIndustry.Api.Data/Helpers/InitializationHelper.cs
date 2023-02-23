using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using MusicIndustry.Api.Data.Models;
using MusicIndustry.Api.Data.Procedures;

namespace MusicIndustry.Api.Data.Helpers
{
    public static class InitializationHelper
    {
        public static void MigrateProcedures(ApplicationDbContext context)
        {
            Assembly currentAssem = Assembly.GetExecutingAssembly();
            var procedures = currentAssem.GetTypes()
                .Where(s => s.CustomAttributes.Any(a => a.AttributeType == typeof(ProcedureAttribute)))
                .ToList();
            foreach (var procedure in procedures)
            {
                var name = (string)procedure.GetProperty("Name").GetValue(null);
                var version = (int)procedure.GetProperty("Version").GetValue(null);
                var text = (string)procedure.GetProperty("Text").GetValue(null);

                var procedureVersion = context.ProcedureVersions
                    .FirstOrDefault(pv => pv.ProcedureName == name);
                bool needToSave = true;
                if (procedureVersion != null)
                {
                    if (version > procedureVersion.Version)
                    {
                        string dropProcedure =
                            $@"IF EXISTS (select * from sysobjects where id = object_id(N'[{name}]')
                                    and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	                            DROP PROCEDURE [{name}]";
                        context.Database.ExecuteSqlRaw(dropProcedure);
                    }
                    else
                    {
                        needToSave = false;
                    }
                }
                else
                {
                    procedureVersion = new ProcedureVersion
                    {
                        ProcedureName = name,
                        Version = 0,
                        DateCreated = DateTimeOffset.Now,
                        DateModified = DateTimeOffset.Now
                    };
                    context.ProcedureVersions.Add(procedureVersion);
                    context.SaveChanges();
                }

                if (needToSave)
                {
                    context.Database.ExecuteSqlRaw(text);
                    procedureVersion.Version = version;
                    procedureVersion.DateModified = DateTimeOffset.Now;
                    context.SaveChanges();
                }
            }
        }
    }
}
