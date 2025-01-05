using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/v1/finance")]
public class FinanceController : ControllerBase
{
    private readonly IFinanceService _financeService;

    public FinanceController(IFinanceService financeService)
    {
        _financeService = financeService;
    }

    [HttpGet]
    public IActionResult GetFinance()
    {
        return Ok(_financeService.GetFinances());
    }
    
    [HttpPost]
    public ActionResult<Finance> CreateFinance([FromBody] Finance financeInput)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var finance = new Finance
        {
            Date = financeInput.Date,
            Amount = financeInput.Amount,
            Currency = financeInput.Currency,
            UserId = financeInput.UserId,
            TransactionType = financeInput.TransactionType
        };

        var createdFinance = _financeService.CreateFinanceForUser(finance, financeInput.UserId);
        return CreatedAtAction(nameof(CreateFinance), new { id = createdFinance.Id }, createdFinance);
    }
    
    [HttpPut("{id}")]
    public IActionResult PutFinance(int id, Finance finance)
    {
        var financeData = _financeService.GetFinanceById(id);
        _financeService.UpdateFinance(financeData);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFinance(int id)
    {
        var financeData = _financeService.GetFinanceById(id);
        _financeService.DeleteFinance(financeData);
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetFinanceById(int id)
    {
        var financeData = _financeService.GetFinanceById(id);
        return Ok(financeData);
    }

    [HttpGet("{transactionType}")]
    public IActionResult GetFinanceByTransactionType(TransactionType transactionType)
    {
        return Ok(_financeService.GetFinancesByType(transactionType));
    }

    [HttpGet("{date}")]
    public IActionResult GetFinanceByDate(DateTime date)
    {
        return Ok(_financeService.GetTransactionsByDate(date));
    }
}