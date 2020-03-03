﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abc.Data.Common;
using Abc.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain> 
        where TData: PeriodData, new()
        where TDomain: Entity<TData>, new()

    {
        protected internal DbContext db;
        protected internal DbSet<TData> dbSet;

        protected BaseRepository(DbContext c, DbSet<TData> s)
        { 
            db = c;
            dbSet = s;
        }
        public virtual async Task<List<TDomain>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<TDomain> Get(string id)
        {
            if (id is null) return new TDomain();

            var d = await dbSet.FirstOrDefaultAsync(m => IsThisRecord(m, id));

            var obj = new TDomain {Data = d};

            return obj;
        }

        protected virtual bool IsThisRecord(TData d, string id)
        {
            if (d is UniqueEntityData data) return data.Id == id;
            
            return true;
        }

        public async Task Delete(string id)
        {
            if (id is null) return;
            
            var v = await dbSet.FindAsync(id);

            if (v is null) return;
            dbSet.Remove(v);
            await db.SaveChangesAsync();
        }

        public async Task Add(TDomain obj)
        {
            if (obj?.Data is null) return;
            dbSet.Add(obj.Data);
            await db.SaveChangesAsync();
        }

        public async Task Update(TDomain obj)
        {
            db.Attach(obj.Data).State = EntityState.Modified;
            //var d = await db.Measures.FirstOrDefaultAsync(x => x.Id == obj.Data.Id);
            //d.Code = obj.Data.Code;
            //d.Name = obj.Data.Name;
            //d.Definition = obj.Data.Definition;
            //d.ValidFrom = obj.Data.ValidFrom;
            //d.ValidTo = obj.Data.ValidTo;
            //db.Measures.Update(d);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MeasureViewExists(MeasureView.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                throw;
                //}
            }
        }
    }
}