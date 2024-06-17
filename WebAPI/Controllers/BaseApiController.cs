using Application.Wrappers.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


[Route("[controller]")]
[ApiController]
public class BaseApiController : Controller
{
    private IMediator _mediator;

    /// <summary>
    /// It is for getting the Mediator instance creation process from the base controller.
    /// </summary>
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetResponse<T>(IDataResult<T> responseResult)
    {
        return responseResult.Success ? Ok(responseResult) : BadRequest(responseResult);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetResponseOnlyResultCreated(IResponseResult responseResult)
    {
        return responseResult.Success ? Created(string.Empty, responseResult) : BadRequest(responseResult);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetResponseOnlyResult(IResponseResult responseResult)
    {
        return responseResult.Success ? Ok(responseResult) : BadRequest(responseResult);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetResponseOnlyResultMessage(IResponseResult responseResult)
    {
        return responseResult.Success ? Ok(responseResult.Message) : BadRequest(responseResult.Message);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetResponseOnlyResultData<T>(IDataResult<T> responseResult)
    {
        return responseResult.Success ? Ok(responseResult.Data) : BadRequest(responseResult.Message);
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="internalMessage"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult Success<T>(string message, string internalMessage, T data)
    {
        return Success(new ApiResult<T> { Success = true, Message = message, InternalMessage = internalMessage, Data = data });
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult Success<T>(ApiResult<T> data)
    {
        return Ok(data);
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="internalMessage"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult Created<T>(string message, string internalMessage, T data)
    {
        return Created(new ApiResult<T> { Success = true, Message = message, InternalMessage = internalMessage, Data = data });
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult Created<T>(ApiResult<T> data)
    {
        return StatusCode(201, data);
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="internalMessage"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult NoContent<T>(string message, string internalMessage, T data)
    {
        return NoContent(new ApiResult<T> { Success = true, Message = message, InternalMessage = internalMessage, Data = data });
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult NoContent<T>(ApiResult<T> data)
    {
        return StatusCode(204, data);
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="internalMessage"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult BadRequest<T>(string message, string internalMessage, T data)
    {
        return BadRequest(new ApiResult<T> { Success = false, Message = message, InternalMessage = internalMessage, Data = data });
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult BadRequest<T>(ApiResult<T> data)
    {
        return StatusCode(400, data);
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="internalMessage"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult Unauthorized<T>(string message, string internalMessage, T data)
    {
        return Unauthorized(new ApiResult<T> { Success = false, Message = message, InternalMessage = internalMessage, Data = data });
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult Unauthorized<T>(ApiResult<T> data)
    {
        return StatusCode(401, data);
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="internalMessage"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult Forbidden<T>(string message, string internalMessage, T data)
    {
        return Forbidden(new ApiResult<T> { Success = false, Message = message, InternalMessage = internalMessage, Data = data });
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult Forbidden<T>(ApiResult<T> data)
    {
        return StatusCode(403, data);
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="internalMessage"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult NotFound<T>(string message, string internalMessage, T data)
    {
        return NotFound(new ApiResult<T> { Success = false, Message = message, InternalMessage = internalMessage, Data = data });
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult NotFound<T>(ApiResult<T> data)
    {
        return StatusCode(404, data);
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="internalMessage"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult Error<T>(string message, string internalMessage, T data)
    {
        return Error(new ApiResult<T> { Success = false, Message = message, InternalMessage = internalMessage, Data = data });
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    [NonAction]
    protected IActionResult Error<T>(ApiResult<T> data)
    {
        return StatusCode(500, data);
    }

    protected string? getIpAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
    }
}