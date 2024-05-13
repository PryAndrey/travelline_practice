using Domain.Entities;
using Domain.Repositories;
using TheatreManagement.Dto;
using Microsoft.AspNetCore.Mvc;

namespace TheaterManagement.Controllers;

// Описание работы с web api https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio
[ApiController]
[Route("theaters")]
// http-протокол https://developer.mozilla.org/ru/docs/Web/HTTP
// методы http - https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods
public class TheatersController : ControllerBase
{
    private readonly ITheaterRepository _theaterRepository;

    // DI-контейнер
    public TheatersController(ITheaterRepository theaterRepository)
    {
        _theaterRepository = theaterRepository;
    }

    // Http-метод GET
    // GET подразумевает что мы запрашиваем данные с сервера, не меняем состояние на нем
    // может содержать query-параметре в качестве метода фильтра/уточнения запроса данных
    [HttpGet("")]
    public IActionResult GetTheaters()
    {
        IReadOnlyList<Theater> theaters = _theaterRepository.GetAllTheaters();

        return Ok(theaters);
    }

    // Http-метод POST
    // POST метод подразумевает изменение состояния на сервере, например, создание нового отеля
    // Также содержит body - тело запроса, в нем передаются данные
    [HttpPost("")]
    public IActionResult CreateTheater( /*Говорим что данные имеют формат CreateTheaterRequest и лежат в теле http-запроса*/ [FromBody] CreateTheaterRequest request)
    {
        Theater theater = new(request.Name, request.Adress, request.PhoneNumber, request.Director, request.OpeningDate);
        _theaterRepository.Save(theater);

        // возвращает http-ответ со статусом 200-ОК
        return Ok();
    }

    // Http-метод PUT
    // PUT означает изменение состояние на сервере для сущ-их данных
    [HttpPut("{id:int}")]
    public IActionResult ModifyTheater([FromRoute] int id, [FromBody] ModifyTheaterRequest request)
    {
        // нет валидации
        // создаем отель, когда на самом деле надо модифицировать
        // отделение методов по изменению - например изменить только адресс

        Theater theater = new(id, request.Name, request.PhoneNumber, request.Director);
        _theaterRepository.Update(theater);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteTheater([FromRoute] int id)
    {
        _theaterRepository.Delete(id);

        return Ok();
    }
}


