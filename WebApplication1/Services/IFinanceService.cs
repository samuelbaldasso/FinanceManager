using WebApplication1.Entities;

namespace WebApplication1.Services;

public interface IFinanceService
{
    IEnumerable<Finance> GetFinances();
    Finance GetFinanceById(int id);
    Finance AddFinance(Finance finance);
    void DeleteFinance(Finance finance);
    void UpdateFinance(Finance finance);
    
    Finance CreateFinanceForUser(Finance finance, int userId);
 
    IEnumerable<Finance> GetTransactionsByDate(DateTime date);
    public IEnumerable<Finance> GetFinancesByType(TransactionType type);
}