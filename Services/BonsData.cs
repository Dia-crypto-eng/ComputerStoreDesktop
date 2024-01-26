using ComputerStore.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.DATA
{
    class BonsData
    {
        public void addBons()
        {

        }
        public void deleteBons()
        {

        }
        public List<BonsEntity> bns = new List<BonsEntity>();
        public List<BonsElement> bnse = new List<BonsElement>();
        public List<BonsEntity> GetAllBons() {
            
            bns.Add( new BonsEntity(){ 
            Id = 001,
            Date = "13/12/2021",
            MONTANT=5500,
            NAMECLIENT = "Kamal Boualag",
            SOLD = "PAID",
           
            });

            bns.Add(new BonsEntity()
            {
                Id = 001,
                Date = "13/12/2021",
                MONTANT = 5500,
                NAMECLIENT = "Kamal Boualag",
                SOLD = "PAID",

            });

            bns.Add(new BonsEntity()
            {
                Id = 001,
                Date = "13/12/2021",
                MONTANT = 5500,
                NAMECLIENT = "Kamal Boualag",
                SOLD = "PAID",

            });

            bns.Add(new BonsEntity()
            {
                Id = 001,
                Date = "13/12/2021",
                MONTANT = 5500,
                NAMECLIENT = "Kamal Boualag",
                SOLD = "UNPAID",

            });

            bns.Add(new BonsEntity()
            {
                Id = 001,
                Date = "13/12/2021",
                MONTANT = 5500,
                NAMECLIENT = "Kamal Boualag",
                SOLD = "UNPAID",

            });

            bns.Add(new BonsEntity()
            {
                Id = 001,
                Date = "13/12/2021",
                MONTANT = 5500,
                NAMECLIENT = "Kamal Boualag",
                SOLD = "UNPAID",

            });
            return bns;
        }

        public List<BonsElement> GetBons()
        {
            bnse.Add(new BonsElement()
            {
                Id = 001,
                FamilyProduct = "Machine a Laver",
                CodeProduct = "XPB65SB",
                Product = "Machine a Laver 6.5 KG Sans Pompe",
                PriceSell = 9500,
                Quantity = 6,
                Amount = 9500 * 6,

            }) ;
            bnse.Add(new BonsElement()
            {
                Id = 001,
                FamilyProduct = "Machine a Laver",
                CodeProduct = "XPB65SB",
                Product = "Machine a Laver 6.5 KG Sans Pompe",
                PriceSell = 9500,
                Quantity = 6,
                Amount = 9500 * 6,

            });
            bnse.Add(new BonsElement()
            {
                Id = 001,
                FamilyProduct = "Machine a Laver",
                CodeProduct = "XPB65SB",
                Product = "Machine a Laver 6.5 KG Sans Pompe",
                PriceSell = 9500,
                Quantity = 6,
                Amount = 9500 * 6,

            });
            bnse.Add(new BonsElement()
            {
                Id = 001,
                FamilyProduct = "Machine a Laver",
                CodeProduct = "XPB65SB",
                Product = "Machine a Laver 6.5 KG Sans Pompe",
                PriceSell = 9500,
                Quantity = 6,
                Amount = 9500 * 6,

            });
            bnse.Add(new BonsElement()
            {
                Id = 001,
                FamilyProduct = "Machine a Laver",
                CodeProduct = "XPB65SB",
                Product = "Machine a Laver 6.5 KG Sans Pompe",
                PriceSell = 9500,
                Quantity = 6,
                Amount = 9500 * 6,

            });

            

            return bnse;

        }

    }
}
