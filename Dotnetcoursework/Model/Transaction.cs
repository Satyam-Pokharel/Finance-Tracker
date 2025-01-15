using System.ComponentModel.DataAnnotations;


namespace Dotnetcoursework.Model
{
        public class TransactionModel
        {
            
            public Guid TransactionId { get; set; }

            [Required]
            public string TransactionName { get; set; }

        [Required]
        public string TransactionType { get; set; } = "Credit";

            [Required]
            public double TransactionAmount { get; set; }

            [Required]
            public DateTime TransactionTime { get; set; }

            [Required]
            public string TransactionSource { get; set; }
 
            public string TransactionNotes { get; set; }

            [Required]
            public string TransactionDefaultTag { get; set; } 

            public string TransactionCustomTags { get; set; }
        }
    
}
