using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppRepositorios;
//using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class ListVeterinariosModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        public IEnumerable<Veterinario> Veterinarios {get;set;}
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda {get;set;}

        public ListVeterinariosModel()
        {
            repositorioVeterinario = new RepositorioVeterinario(
                new MascotaFeliz.App.Persistencia.AppContext());
        }

        public void OnGet(string filtroBusqueda)
        {
            FiltroBusqueda = filtroBusqueda;
            Veterinarios = repositorioVeterinario.GetVeterinariosPorFiltro(
                filtroBusqueda);
            //Veterinarios = repositorioVeterinario.GetAllVeterinarios();
        }
        
    }
}
