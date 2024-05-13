using Domain.Entities;
using Domain.Repositories;
using TheatreManagement.Dto;
using Microsoft.AspNetCore.Mvc;

namespace TicketManagement.Controllers;

// Описание работы с web api https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio
[ApiController]
[Route("tickets")]
// http-протокол https://developer.mozilla.org/ru/docs/Web/HTTP
// методы http - https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods
public class TicketsController : ControllerBase
{
    private readonly ITicketRepository _ticketRepository;

    // DI-контейнер
    public TicketsController(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    // Http-метод GET
    // GET подразумевает что мы запрашиваем данные с сервера, не меняем состояние на нем
    // может содержать query-параметре в качестве метода фильтра/уточнения запроса данных
    [HttpGet("")]
    public IActionResult GetTickets()
    {
        IReadOnlyList<Ticket> tickets = _ticketRepository.GetAllTickets();

        return Ok(tickets);
    }

    // Http-метод POST
    // POST метод подразумевает изменение состояния на сервере, например, создание нового отеля
    // Также содержит body - тело запроса, в нем передаются данные
    [HttpPost("")]
    public IActionResult CreateTicket( /*Говорим что данные имеют формат CreateTicketRequest и лежат в теле http-запроса*/ [FromBody] CreateTicketRequest request)
    {
        Ticket ticket = new(request.Price, request.RoomType, request.PlaysNumber, request.StartingDate);
        _ticketRepository.Save(ticket);

        // возвращает http-ответ со статусом 200-ОК
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteTicket([FromRoute] int id)
    {
        _ticketRepository.Delete(id);

        return Ok();
    }
}


