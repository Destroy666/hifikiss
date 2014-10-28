using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using KissHiFi.Models;

namespace KissHiFi.DAL
{
    public class HirekRepository : IHirekRepository, IDisposable
    {
        private KissHifiContext context;
        private bool disposed = false;

        public HirekRepository(KissHifiContext context)
        {
            this.context = context;
        }

        public IEnumerable<Hirek> GetHirek()
        {
            return context.Hireks.ToList();
        }

        public Hirek GetHirById(int id)
        {
            return context.Hireks.Find(id);
        }

        public void InsertHir(Hirek hirek)
        {
            context.Hireks.Add(hirek);
        }

        public void DeleteHir(int id)
        {
            Hirek hirek = context.Hireks.Find(id);
            context.Hireks.Remove(hirek);
        }

        public void UpdateHir(Hirek hirek)
        {
            context.Entry(hirek).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}