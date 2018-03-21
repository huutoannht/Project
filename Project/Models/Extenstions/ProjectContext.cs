using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Project.Models.EntitiesFramework
{
    public partial class ProjectContext : DbContext
    {
        public static IConfiguration Configuration { get; set; }
        public static ProjectParams dataSource;
        public override int SaveChanges()
        {
            try
            {
                var time = DateTime.Now;
                var entities = ChangeTracker.Entries();

                var addedEntities = entities.Where(o => o.State == EntityState.Added);

                foreach (var entity in addedEntities)
                {
                    UpdateRecordStamps(entity, true, time, dataSource);
                }

                var modifiedEntities = entities.Where(o => o.State == EntityState.Modified);

                foreach (var entity in modifiedEntities)
                {
                    UpdateRecordStamps(entity, false, time, dataSource);
                }

                return base.SaveChanges();
            }
            //
            catch (DbUpdateConcurrencyException Ex)
            {
                var entry = Ex.Entries.Single();
                var databaseEntry = entry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    throw new Exception("\n\rThe modified record(s) has been deleted in the database.", Ex);
                }
                //
                throw new Exception("\n\nWhile the record(s) is being modified by you it has been changed or modified in the database by other users since last read.", Ex);
            }
            //
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                var time = DateTime.Now;
                var entities = ChangeTracker.Entries();

                var addedEntities = entities.Where(o => o.State == EntityState.Added);

                foreach (var entity in addedEntities)
                {
                    UpdateRecordStamps(entity, true, time, dataSource);
                }

                var modifiedEntities = entities.Where(o => o.State == EntityState.Modified);

                foreach (var entity in modifiedEntities)
                {
                    UpdateRecordStamps(entity, false, time, dataSource);
                }
                int x = await base.SaveChangesAsync();
                return x;
            }
            //
            catch (DbUpdateConcurrencyException Ex)
            {
                var entry = Ex.Entries.Single();
                var databaseEntry = entry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    throw new Exception("\n\rThe modified record(s) has been deleted in the database.", Ex);
                }
                //
                throw new Exception("\n\nWhile the record(s) is being modified by you it has been changed or modified in the database by other users since last read.", Ex);
            }
            //
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        private void UpdateRecordStamps(EntityEntry dbEntry, bool isNew, DateTime time, ProjectParams dataSource)
        {
            foreach (var property in dbEntry.Entity.GetType().GetTypeInfo().DeclaredProperties)
            {
                var originalValue = dbEntry.Property(property.Name).OriginalValue;
                var currentValue = dbEntry.Property(property.Name).CurrentValue;
                Console.WriteLine($"{property.Name}: Original: {originalValue}, Current: {currentValue}");
            }

            if (isNew)
            {
                dbEntry.CurrentValues["CreatedBy"] = dataSource.UserId;
                dbEntry.CurrentValues["CreatedDt"] = time;
            }

            dbEntry.CurrentValues["LastUpdBy"] = dataSource.UserId;
            dbEntry.CurrentValues["LastUpdDt"] = time;

        }

    }
}
