using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.ENTITY
{
    class BonsEntity
    {
        private byte IDBON;
        private string BnDate;
        private float MONTANTB;
        private string NameClient;
        private string Sold;
        private List<BonsElement> BonsElements;


       

        public byte Id { get => IDBON; set => IDBON = value; }
        
        public string Date { get => BnDate; set => BnDate = value; }
        
        public float MONTANT{ get => MONTANTB; set => MONTANTB = value; }

        public string NAMECLIENT { get => NameClient; set => NameClient = value; }

        public string SOLD { get => Sold; set => Sold = value; }

        internal List<BonsElement> BONSELEMENT { get => BonsElements; set => BonsElements = value; }

    }
}
