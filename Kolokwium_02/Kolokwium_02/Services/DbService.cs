using Kolokwium_02.DTOs.Responses;
using Kolokwium_02.Exceptions;
using Kolokwium_02.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_02.Services
{
    public class DbService : IDbService
    {
        private readonly s17180Context dbContext;
        public DbService(s17180Context dbContext)
        {
            this.dbContext = dbContext;
        }

    

        public LabelResponse GetLabel(int id)
        {
            var label = dbContext.MusicLabel.Where(e => e.IdMusicLabel == id).FirstOrDefault();

            if(label == null)
            {
                throw new AppException("NIE MA TAKIEJ WYTWORNI O PODANYM ID!");
            }

            var albums = dbContext.Album
                .Where(a => a.IdMusicLabel == id)
                .OrderByDescending(d => d.PublishDate)
                .ToList();

            var labelResponse = new LabelResponse
            {
                IdMusicLabel = label.IdMusicLabel,
                Name = label.Name,
                Albums = albums
            };



            return labelResponse;
        }

        public string DeleteMusician(int id)
        {
            var muscian = dbContext.Musician.Where(e => e.IdMusician == id).FirstOrDefault();

            if(muscian == null)
            {
                throw new AppException("NIE MOZNA USUNAC MUZYKA PONIEWAZ NIE ISTNIEJE!!!");
            }

            var tracks = dbContext.MusicianTrack
                .Where(t => t.IdMusicianTrack == id)
                .Select(m => m.IdTrack)
                .ToList();
           
            if (tracks == null)
            {
                throw new AppException("NIE MA TAKICH TRACKOW");
            }

            foreach (int i2 in tracks)
            {
                var czywystepuje = dbContext.Track
                    .Where(t => t.IdTrack == i2).
                    Any(t => t.IdMusicAlbum == null);
                if (!czywystepuje)
                {
                    var musician = new Musician
                    {
                        IdMusician = id
                    };
                    dbContext.Attach(musician);
                    dbContext.Remove(musician);
                    dbContext.SaveChanges();
                    return "WSZYSTKO SIE POWIODLO!";


                }
            }
            return "NIE UDALO SIE!!!!!!";

        }

    }
}
