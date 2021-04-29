using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassKeeper.PassLib.Models
{
    public class Word : IEquatable<Word>
    {
        public string NominativeM { get; set; }
        public string NominativeW { get; set; }
        public string GenetivePlural { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }


        public override bool Equals(object obj) => this.Equals(obj as Word);

        public bool Equals(Word other)
        {
            if (other is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != other.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (NominativeM == other.NominativeM) && (NominativeW == other.NominativeW) &&(GenetivePlural == other.GenetivePlural) && (PartOfSpeech == other.PartOfSpeech);
        }

        public override int GetHashCode() => (NominativeM, NominativeW, GenetivePlural, PartOfSpeech).GetHashCode();
    }

    public enum PartOfSpeech
    {
        Noun,
        Adjective,
        Verb
    }
}
