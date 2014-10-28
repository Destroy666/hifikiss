using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KissHiFi.Models;

namespace KissHiFi.DAL
{
    public interface IHirekRepository : IDisposable
    {
        IEnumerable<Hirek> GetHirek();
        Hirek GetHirById(int hirId);
        void InsertHir(Hirek hirek);
        void DeleteHir(int hirekId);
        void UpdateHir(Hirek hirek);
        void Save();
    }
}