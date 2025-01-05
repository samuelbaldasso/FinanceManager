using WebApplication1.Entities;
using WebApplication1.repositories;

namespace WebApplication1.Services;

public class FinanceService : IFinanceService
{
    private readonly IFinanceRepository _financeRepository;
    
    public FinanceService(IFinanceRepository financeRepository)
    {
        _financeRepository = financeRepository;
    }
    
    public IEnumerable<Finance> GetFinances()
    {
        return _financeRepository.GetFinances();    
    }

    public Finance GetFinanceById(int id)
    {
        return _financeRepository.GetFinanceById(id);
    }

    public Finance AddFinance(Finance finance)
    {
        return _financeRepository.AddFinance(finance);
    }

    public void DeleteFinance(Finance finance)
    { 
        _financeRepository.DeleteFinance(finance);
    }

    public void UpdateFinance(Finance finance)
    {
        _financeRepository.UpdateFinance(finance);
    }

    public IEnumerable<Finance> GetTransactionsByDate(DateTime date)
    {
        return _financeRepository.GetTransactionsByDate(date);
    }

    public Finance CreateFinanceForUser(Finance finance, int userId)
    {
        finance.UserId = userId;
        return _financeRepository.AddFinance(finance);
    }
    
    public IEnumerable<Finance> GetFinancesByType(TransactionType type)
    {
        return _financeRepository.GetFinancesByType(type);
    }
}