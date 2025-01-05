using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Entities;
using WebApplication1.repositories;

namespace WebApplication1.Repositories
{
    public class FinanceRepository : IFinanceRepository
    {
        private readonly AppDbContext _context;

        public FinanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Finance> GetFinances()
        {
            return _context.Finances.ToList();
        }

        public Finance GetFinanceById(int id)
        {
            return _context.Finances.Find(id);
        }

        public Finance AddFinance(Finance finance)
        {
            _context.Finances.Add(finance);
            _context.SaveChanges();
            return finance;
        }

        public void DeleteFinance(Finance finance)
        {
            _context.Finances.Remove(finance);
            _context.SaveChanges();
        }

        public void UpdateFinance(Finance finance)
        {
            _context.Finances.Update(finance);
            _context.SaveChanges();
        }

        public IEnumerable<Finance> GetTransactionsByDate(DateTime date)
        {
            return _context.Finances.Where(f => f.Date == date);
        }

        public IEnumerable<Finance> GetFinancesByType(TransactionType type)
        {
            return _context.Finances.Where(f => f.TransactionType == type).ToList();
        }
    }
}