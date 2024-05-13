using Domain.Entities;
using Domain.Repositories;
using TheatreManagement.Dto;
using Microsoft.AspNetCore.Mvc;

namespace PlayManagement.Controllers;

// Описание работы с web api https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio
[ApiController]
[Route("plays")]
// http-протокол https://developer.mozilla.org/ru/docs/Web/HTTP
// методы http - https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods
public class PlaysController : ControllerBase
{
    private readonly IPlayRepository _playRepository;

    // DI-контейнер
    public PlaysController(IPlayRepository playRepository)
    {
        _playRepository = playRepository;
    }

    // Http-метод GET
    // GET подразумевает что мы запрашиваем данные с сервера, не меняем состояние на нем
    // может содержать query-параметре в качестве метода фильтра/уточнения запроса данных
    [HttpGet("")]
    public IActionResult GetPlays()
    {
        IReadOnlyList<Play> plays = _playRepository.GetAllPlays();

        return Ok(plays);
    }

    // Http-метод POST
    // POST метод подразумевает изменение состояния на сервере, например, создание нового отеля
    // Также содержит body - тело запроса, в нем передаются данные
    [HttpPost("")]
    public IActionResult CreatePlay( /*Говорим что данные имеют формат CreatePlayRequest и лежат в теле http-запроса*/ [FromBody] CreatePlayRequest request)
    {
        Play play = new(request.Name, request.StageDirector, request.StartDate, request.EndDate);
        _playRepository.Save(play);

        // возвращает http-ответ со статусом 200-ОК
        return Ok();
    }

    // Http-метод PUT
    // PUT означает изменение состояние на сервере для сущ-их данных
    [HttpPut("{id:int}")]
    public IActionResult ModifyPlay([FromRoute] int id, [FromBody] ModifyPlayRequest request)
    {
        // нет валидации
        // создаем отель, когда на самом деле надо модифицировать
        // отделение методов по изменению - например изменить только адресс

        Play play = new(id, request.Name, request.StageDirector);
        _playRepository.Update(play);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeletePlay([FromRoute] int id)
    {
        _playRepository.Delete(id);

        return Ok();
    }
}


