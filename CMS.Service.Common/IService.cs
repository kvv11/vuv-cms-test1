using CMS.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Service.Common
{
    public interface IService
    {
        IEnumerable<OsobaDomain> PrikaziSveOsobe();
        Task AddClanak(ClanakDomain clanak);
        IEnumerable<ClanakDomain> GetAllClanci();
        ClanakDomain GetClanakById(int id);
        Task AddKomentar(KomentarDomain komentar);
        IEnumerable<KomentarDomain> PrikaziKomentareZaClanak(int clanakId);
        OsobaDomain PrikaziOsobuPoId(string id);
        Task UpdateClanakAsync(ClanakDomain updatedClanak);

        Task<bool> DeleteSlikaAsync(int clanakId, int slikaId);

        Task<bool> DeleteClanakAsync(int id);


    }
}
