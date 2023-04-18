using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lists.Services;
using Lists.Models;
using Microsoft.Extensions.Logging;

namespace Lists.Controllers;

[ApiController]
[Route("[controller]")]
public class ListController : ControllerBase
{
    private readonly ILogger<ListController> _logger;
    ListService<string> _listService;

    public ListController(ILogger<ListController> logger, ListService<string> listService)
    {
        _logger = logger;
        _listService = listService;
    }

    [HttpGet]
    public ActionResult<List<ListItem<string>>> Get([FromQuery] int? index)
    {
        if (index == null)
        {
            _logger.Log(LogLevel.Debug, "Returning list of items");
            return _listService.GetItems();
        }
        else
        {
            var item = _listService.GetItem((int)index);

            if (item == null)
            {
                _logger.Log(LogLevel.Error, $"No item at index: {index}");
                return BadRequest();
            }
            else
            {
                _logger.Log(LogLevel.Debug, "Returning list with single item");
                return new List<ListItem<string>> { item };
            }
        }
    }

    [HttpPost]
    public ActionResult<List<ListItem<string>>> Post(ListItem<string> item)
    {
        _listService.AddItemToList(item);
        
        return _listService.GetItems();
    }

    [Route("{index}")]
    [HttpDelete]
    public ActionResult<List<ListItem<string>>> DeleteByIndex(int index) {
        throw new NotImplementedException();
    }

}
