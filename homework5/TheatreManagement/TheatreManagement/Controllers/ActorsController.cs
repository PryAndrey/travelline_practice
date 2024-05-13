using Domain.Entities;
using Domain.Repositories;
using TheatreManagement.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ActorManagement.Controllers;

// Описание работы с web api https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio
[ApiController]
[Route("actors")]
// http-протокол https://developer.mozilla.org/ru/docs/Web/HTTP
// методы http - https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods
public class ActorsController : ControllerBase
{
    private readonly IActorRepository _actorRepository;

    // DI-контейнер
    public ActorsController(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }

    // Http-метод GET
    // GET подразумевает что мы запрашиваем данные с сервера, не меняем состояние на нем
    // может содержать query-параметре в качестве метода фильтра/уточнения запроса данных
    [HttpGet("")]
    public IActionResult GetActors()
    {
        IReadOnlyList<Actor> actors = _actorRepository.GetAllActors();

        return Ok(actors);
    }

    // Http-метод POST
    // POST метод подразумевает изменение состояния на сервере, например, создание нового отеля
    // Также содержит body - тело запроса, в нем передаются данные
    [HttpPost("")]
    public IActionResult CreateActor( /*Говорим что данные имеют формат CreateActorRequest и лежат в теле http-запроса*/ [FromBody] CreateActorRequest request)
    {
        Actor actor = new(request.Name, request.Surname, request.PhoneNumber, request.DateOfBirth);
        _actorRepository.Save(actor);

        // возвращает http-ответ со статусом 200-ОК
        return Ok();
    }

    // Http-метод PUT
    // PUT означает изменение состояние на сервере для сущ-их данных
    [HttpPut("{id:int}")]
    public IActionResult ModifyActor([FromRoute] int id, [FromBody] ModifyActorRequest request)
    {
        // нет валидации
        // создаем отель, когда на самом деле надо модифицировать
        // отделение методов по изменению - например изменить только адресс

        Actor actor = new(id, request.Name, request.Surname, request.PhoneNumber);
        _actorRepository.Update(actor);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteActor([FromRoute] int id)
    {
        _actorRepository.Delete(id);

        return Ok();
    }
}


