using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consumidor.api01.Model
{
    public class Item
    {
        public long Id { get; set; }

        public string? Nome { get; set; }

        public bool Finalizado { get; set; }

        public override string ToString()
        {
            return $"\b\b\bId: {Id}\nNome: {Nome}\nFinalizado: {Finalizado}\n";
        }
    }
}
