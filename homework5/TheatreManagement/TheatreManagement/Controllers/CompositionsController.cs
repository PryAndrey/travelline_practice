using Domain.Entities;
using Domain.Repositories;
using TheatreManagement.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CompositionManagement.Controllers;

// Описание работы с web api https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio
[ApiController]
[Route("compositions")]
// http-протокол https://developer.mozilla.org/ru/docs/Web/HTTP
// методы http - https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods
public class CompositionsController : ControllerBase
{
    private readonly ICompositionRepository _compositionRepository;

    // DI-контейнер
    public CompositionsController(ICompositionRepository compositionRepository)
    {
        _compositionRepository = compositionRepository;
    }

    // Http-метод GET
    // GET подразумевает что мы запрашиваем данные с сервера, не меняем состояние на нем
    // может содержать query-параметре в качестве метода фильтра/уточнения запроса данных
    [HttpGet("")]
    public IActionResult GetCompositions()
    {
        IReadOnlyList<Composition> compositions = _compositionRepository.GetAllCompositions();

        return Ok(compositions);
    }

    // Http-метод POST
    // POST метод подразумевает изменение состояния на сервере, например, создание нового отеля
    // Также содержит body - тело запроса, в нем передаются данные
    [HttpPost("")]
    public IActionResult CreateComposition( /*Говорим что данные имеют формат CreateCompositionRequest и лежат в теле http-запроса*/ [FromBody] CreateCompositionRequest request)
    {
        Composition composition = new(request.Name, request.Author, request.Type);
        _compositionRepository.Save(composition);

        // возвращает http-ответ со статусом 200-ОК
        return Ok();
    }

    // Http-метод PUT
    // PUT означает изменение состояние на сервере для сущ-их данных
    [HttpPut("{id:int}")]
    public IActionResult ModifyComposition([FromRoute] int id, [FromBody] ModifyCompositionRequest request)
    {
        // нет валидации
        // создаем отель, когда на самом деле надо модифицировать
        // отделение методов по изменению - например изменить только адресс

        Composition composition = new(id, request.Name, request.Author, request.Type);
        _compositionRepository.Update(composition);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteComposition([FromRoute] int id)
    {
        _compositionRepository.Delete(id);

        return Ok();
    }
}


