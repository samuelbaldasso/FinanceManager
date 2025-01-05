using WebApplication1.Entities;

namespace WebApplication1.repositories;

public interface IFinanceRepository
{
    IEnumerable<Finance> GetFinances();
    Finance GetFinanceById(int id);
    Finance AddFinance(Finance finance);
    void DeleteFinance(Finance finance);
    void UpdateFinance(Finance finance);
 
    IEnumerable<Finance> GetTransactionsByDate(DateTime date);
    public IEnumerable<Finance> GetFinancesByType(TransactionType type);
}