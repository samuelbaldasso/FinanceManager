using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Entities
{
    public class Finance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }
        
        public int UserId { get; set; }
        
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TransactionType TransactionType { get; set; }
        
        public Finance() { }

        public Finance(DateTime date, decimal amount, string currency, int userId, TransactionType transactionType)
        {
            Date = date;
            Amount = amount;
            Currency = currency;
            UserId = userId;
            TransactionType = transactionType;
        }
    }
}