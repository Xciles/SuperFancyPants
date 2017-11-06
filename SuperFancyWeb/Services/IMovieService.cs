using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperFancyWeb.Data;

namespace SuperFancyWeb.Services
{
    public interface IMovieService
    {
    }

    public class MovieService : IMovieService
    {

        public MovieService(SuperDbContext context)
        {
        }
    }
}
