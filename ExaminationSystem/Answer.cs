using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Answer :IEquatable<Answer>
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public bool Equals(Answer? other)
        {
            if(other is null) return false;
            return 
                this.AnswerId.Equals(other.AnswerId) 
                && 
                this.AnswerText.ToUpper().Equals(other.AnswerText.ToUpper());    
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.AnswerId, this.AnswerText);    
        }
    }
}
