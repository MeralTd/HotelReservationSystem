using Application.Features.ReservationHotels.Commands;
using Application.Features.ReservationHotels.Dtos;
using Application.Features.ReservationHotels.Queries;
using Application.Wrappers.Results;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]/[action]")]
public class ReservationHotelsController : BaseApiController
{
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<IEnumerable<ReservationHotelDto>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<IEnumerable<ReservationHotelDto>>))]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return GetResponse(await Mediator.Send(new GetAllReservationHotel()));
    }

    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<ReservationHotelDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<ReservationHotelDto>))]
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetReservationHotelById getReservationHotelById)
    {
        return GetResponse(await Mediator.Send(getReservationHotelById));
    }


    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IDataResult<ReservationHotelEntity>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IDataResult<ReservationHotelEntity>))]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateReservationHotel createReservationHotel)
    {
        return GetResponseOnlyResult(await Mediator.Send(createReservationHotel));
    }
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResponseResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResponseResult))]
    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateReservationHotel updateReservation)
    {
        return GetResponseOnlyResult(await Mediator.Send(updateReservation));
    }

    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IResponseResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResponseResult))]
    [HttpPost("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteReservation deleteReservation)
    {
        return GetResponseOnlyResult(await Mediator.Send(deleteReservation));
    }

}
