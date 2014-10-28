using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KissHiFi.Models;

namespace KissHiFi.DAL
{
    public class UnitOfWork : IDisposable
    {
        private KissHifiContext context = new KissHifiContext();
        private GenericRepository<Hirek> hirekRepository;
        private GenericRepository<Bemutatkozas> bemutatkozasRepository;
        private GenericRepository<Szolgaltatas> szolgaltatasRepository;
        private GenericRepository<TermekKategoria> termekeKategoriaRepository;
        private GenericRepository<TermekMarka> termekMarkaRepository;
        private GenericRepository<TermekAdatlap> termekAdatlapRepository;
        private GenericRepository<Kepek> kepekRepository;
        private GenericRepository<Elerhetoseg> elerhetosegRepository;

        public GenericRepository<Hirek> HirekRepository
        {
            get
            {
                if (this.hirekRepository == null)
                {
                    this.hirekRepository = new GenericRepository<Hirek>(context);
                }
                return hirekRepository;
            }
        }

        public GenericRepository<Bemutatkozas> BemutatkozasRepository
        {
            get
            {
                if (this.bemutatkozasRepository == null)
                {
                    this.bemutatkozasRepository = new GenericRepository<Bemutatkozas>(context);
                }
                return bemutatkozasRepository;
            }
        }

        public GenericRepository<Szolgaltatas> SzolgaltatasRepository
        {
            get
            {
                if (this.szolgaltatasRepository == null)
                {
                    this.szolgaltatasRepository = new GenericRepository<Szolgaltatas>(context);
                }
                return szolgaltatasRepository;
            }
        }

        public GenericRepository<TermekKategoria> TermekKategoriaRepository
        {
            get
            {
                if (this.termekeKategoriaRepository == null)
                {
                    this.termekeKategoriaRepository = new GenericRepository<TermekKategoria>(context);
                }
                return termekeKategoriaRepository;
            }
        }

        public GenericRepository<TermekMarka> TermekMarkaRepository
        {
            get
            {
                if (this.termekMarkaRepository == null)
                {
                    this.termekMarkaRepository = new GenericRepository<TermekMarka>(context);
                }
                return termekMarkaRepository;
            }
        }

        public GenericRepository<TermekAdatlap> TermekAdatlapRepository
        {
            get
            {
                if (this.termekAdatlapRepository == null)
                {
                    this.termekAdatlapRepository = new GenericRepository<TermekAdatlap>(context);
                }
                return termekAdatlapRepository;
            }
        }

        public GenericRepository<Kepek> KepekRepository
        {
            get
            {
                if (this.kepekRepository == null)
                {
                    this.kepekRepository = new GenericRepository<Kepek>(context);
                }
                return kepekRepository;
            }
        }

        public GenericRepository<Elerhetoseg> ElerhetosegRepository
        {
            get
            {
                if (this.elerhetosegRepository == null)
                {
                    this.elerhetosegRepository = new GenericRepository<Elerhetoseg>(context);
                }
                return elerhetosegRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}