using CMS.DAL.DataModel;
using CMS.Model;
using CMS.Repository;
using CMS.Repository.AutoMapper;
using CMS.Repository.Common;
using CMS.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Service
{
    public class Service : IService
    {
        private readonly IRepository _repository;
        private readonly IRepositoryMappingService _mappingService;

        public Service(IRepository repository, IRepositoryMappingService mappingService)
        {
            _repository = repository;
            _mappingService = mappingService;
        }

        public IEnumerable<OsobaDomain> PrikaziSveOsobe()
        {
            var osobe = _repository.PrikaziSveOsobe();
            return _mappingService.Map<IEnumerable<OsobaDomain>>(osobe);
        }

        public async Task AddClanak(ClanakDomain clanak)
        {
            if (clanak.DatumKreiranja == default)
            {
                clanak.DatumKreiranja = DateTime.Now;
            }
            if (clanak.DatumIzmjene == default)
            {
                clanak.DatumIzmjene = DateTime.Now;
            }

            var clanakEntity = _mappingService.Map<Clanci>(clanak);

            if (clanak.Slike != null && clanak.Slike.Count > 0)
            {
                clanakEntity.Slike = new List<Slike>();
                foreach (var slikaDomain in clanak.Slike)
                {
                    var slikaEntity = new Slike
                    {
                        ClanakId = clanakEntity.Id,
                        Slika = slikaDomain.Slika 
                    };
                    clanakEntity.Slike.Add(slikaEntity);
                }
            }

            _repository.AddClanak(clanakEntity);
            await _repository.SaveChangesAsync();
        }

        public IEnumerable<ClanakDomain> GetAllClanci()
        {
            var clanci = _repository.GetAllClanci();
            return _mappingService.Map<IEnumerable<ClanakDomain>>(clanci);
        }

        public ClanakDomain GetClanakById(int id)
        {
            var clanak = _repository.GetClanakById(id);
            return _mappingService.Map<ClanakDomain>(clanak);
        }

        public async Task AddKomentar(KomentarDomain komentar)
        {
            if (komentar.DatumKreiranja == default)
            {
                komentar.DatumKreiranja = DateTime.Now;
            }

            var komentarEntity = _mappingService.Map<Komentari>(komentar);
            _repository.AddKomentar(komentarEntity);
            await _repository.SaveChangesAsync();
        }

        public IEnumerable<KomentarDomain> PrikaziKomentareZaClanak(int clanakId)
        {
            var komentari = _repository.PrikaziKomentareZaClanak(clanakId);
            return _mappingService.Map<IEnumerable<KomentarDomain>>(komentari);
        }

        public OsobaDomain PrikaziOsobuPoId(string id) 
        {
            var osoba = _repository.PrikaziOsobuPoId(id);
            return _mappingService.Map<OsobaDomain>(osoba);
        }

        public async Task UpdateClanakAsync(ClanakDomain updatedClanak)
        {
            var clanakEntity = _mappingService.Map<Clanci>(updatedClanak);
            await _repository.UpdateClanakAsync(clanakEntity);
        }

        public async Task<bool> DeleteSlikaAsync(int clanakId, int slikaId)
        {
            return await _repository.DeleteSlikaAsync(clanakId, slikaId);
        }

        public async Task<bool> DeleteClanakAsync(int id)
        {
            return await _repository.DeleteClanakAsync(id);
        }
    }
}
