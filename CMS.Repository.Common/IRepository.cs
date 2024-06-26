using CMS.DAL.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Repository.Common
{
    public interface IRepository
    {
        IEnumerable<Osobe> PrikaziSveOsobe();
        void AddClanak(Clanci clanak);
        Task SaveChangesAsync();
        IEnumerable<Clanci> GetAllClanci();
        Clanci GetClanakById(int id);
        void AddKomentar(Komentari komentar);
        IEnumerable<Komentari> PrikaziKomentareZaClanak(int clanakId);
        Osobe PrikaziOsobuPoId(string id);
        Task UpdateClanakAsync(Clanci clanak);

        Task<bool> DeleteSlikaAsync(int clanakId, int slikaId);
        Task<bool> DeleteClanakAsync(int id);

    }
}
