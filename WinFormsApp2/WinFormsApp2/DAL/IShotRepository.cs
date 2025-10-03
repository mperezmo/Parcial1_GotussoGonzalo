using System.Collections.Generic;
using WinFormsApp2.Domain;

namespace WinFormsApp2.DAL
{
    public interface IShotRepository
    {
        void Append(ShotRecord record);
        List<ShotRecord> GetAll();
    }
}