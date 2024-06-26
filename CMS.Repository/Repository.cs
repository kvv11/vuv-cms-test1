using CMS.DAL.DataModel;
using CMS.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Repository
{
    public class Repository : IRepository
    {
        private readonly CMSContext _context;
        public Repository(CMSContext context)
        {
            _context = context;
        }

        public IEnumerable<Osobe> PrikaziSveOsobe()
        {
            return _context.Osobe.ToList();
        }

        public void AddClanak(Clanci clanak)
        {
            _context.Clanci.Add(clanak);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Clanci> GetAllClanci()
        {
            return _context.Clanci.Include(c => c.Slike).ToList();
        }

        public Clanci GetClanakById(int id)
        {
            return _context.Clanci.Include(c => c.Slike).FirstOrDefault(c => c.Id == id);
        }

        public void AddKomentar(Komentari komentar)
        {
            _context.Komentari.Add(komentar);
        }

        public IEnumerable<Komentari> PrikaziKomentareZaClanak(int clanakId)
        {
            return _context.Komentari.Where(k => k.ClanakId == clanakId).ToList();
        }
        public Osobe PrikaziOsobuPoId(string id) // Implementacija nove metode
        {
            return _context.Osobe.FirstOrDefault(o => o.Id == id);
        }

        public async Task UpdateClanakAsync(Clanci clanak)
        {
            _context.Clanci.Update(clanak);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteSlikaAsync(int clanakId, int slikaId)
        {
            var clanak = await _context.Clanci.Include(c => c.Slike).FirstOrDefaultAsync(c => c.Id == clanakId);
            if (clanak == null) return false;

            var slika = clanak.Slike.FirstOrDefault(s => s.Id == slikaId);
            if (slika == null) return false;

            clanak.Slike.Remove(slika);
            _context.Slike.Remove(slika);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClanakAsync(int id)
        {
            var clanak = await _context.Clanci.Include(c => c.Slike).Include(c => c.Komentari).FirstOrDefaultAsync(c => c.Id == id);
            if (clanak == null) return false;

            // Brisanje slika
            foreach (var slika in clanak.Slike)
            {
                _context.Slike.Remove(slika);
            }

            // Brisanje komentara
            foreach (var komentar in clanak.Komentari)
            {
                _context.Komentari.Remove(komentar);
            }

            // Brisanje članka
            _context.Clanci.Remove(clanak);

            await _context.SaveChangesAsync();
            return true;
        }



    }
}
