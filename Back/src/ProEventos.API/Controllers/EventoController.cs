using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

        private readonly DataContext context;

    public EventoController(DataContext context)
    {
            this.context = context;
    }


    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return context.Eventos;
    }


    [HttpGet("{id}")]
    public Evento GetById(int id)
    {
        return context.Eventos.FirstOrDefault(
            evento => evento.EventoId == id);
    }



}
